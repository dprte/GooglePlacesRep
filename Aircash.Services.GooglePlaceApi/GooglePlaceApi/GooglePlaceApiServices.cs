using Aircash.Data.Model.GooglePlacesModel;
using Aircash.Data.Repository.GooglePlacesRep;
using Aircash.Interface.GooglePlaceInterface;
using Aircash.Shared.Components;
using Aircash.Utils.AOP;
using GoogleApi;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Aircash.Services.GooglePlaceApi.GooglePlaceApi
{
    public class GooglePlaceApiServices
    {
        #region variables
        public static GooglePlaceApiServices _serviceGoolePlace = null;
        private IGooglePlaceApiRepository<GooglePlace> _googlePlaceRepository;
        #endregion

        #region Ctor
    
        private GooglePlaceApiServices()
        {
            _googlePlaceRepository = RootFactory<IGooglePlaceApiRepository<GooglePlace>, GooglePlaceApiRepository>.CreateInstance();
        }
        public static GooglePlaceApiServices Instance()
        {
            if (_serviceGoolePlace == null)
            {
                _serviceGoolePlace = new GooglePlaceApiServices();
            }
            return _serviceGoolePlace;
        }
        #endregion

        [TimingAspect]
        [RunInTransactionAspect]
        [LoggerAspect]
        public PlacesNearbySearchResponse NearbySearch(double lat, double lgn)
        {
            var response = new PlacesNearbySearchResponse();
            try
            {
                var AppKey = new ConfigurationBuilder().AddJsonFile("application.default.json").Build().GetSection("AppSettings")["ApiKey"];

                var request = new PlacesNearBySearchRequest
                {
                    Key = AppKey.ToString(),//this.ApiKey,
                    Location = new Location() { Latitude = lat, Longitude = lgn },
                    Radius = 1000
                };

                HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse> httpResponse
                    = new HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>();

                response = httpResponse.Query(request);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception during geting places data: " +
                ex.ToString());
            }
            return response;
        }
        

    }
}
