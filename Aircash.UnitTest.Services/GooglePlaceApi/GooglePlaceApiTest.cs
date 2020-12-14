using GoogleApi;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Aircash.UnitTest.Services
{
    [TestClass()]
    public class GooglePlaceApiTest
    {
        [TestMethod()]
        public PlacesNearbySearchResponse NearbySearchTest()
        {
            //Arrange
            var response = new PlacesNearbySearchResponse();
                var request = new PlacesNearBySearchRequest
                {
                    Key = "AIzaSyB_4x15ATP7Br_fRJpb215UGhsL519cwPA",
                    Location = new Location() { Latitude = 45.8057017, Longitude = 15.9205017 },
                    Radius = 1000
                };

                HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse> httpResponse
                    = new HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>();

            // Act
            response =  httpResponse.Query(request);

            // Assert
            Assert.IsNotNull(response);

          
            return response;
        }
    }
}

