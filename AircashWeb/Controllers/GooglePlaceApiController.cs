using Aircash.Services.GooglePlaceApi.GooglePlaceApi;
using Aircash.Shared.Components;
using Aircash.Utils.AOP;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AircashWeb.ClientApp.src.controller
{
    [ApiController]
    [Route("api/GooglePlace")]
    public class GooglePlaceApiController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [TimingAspect]
        [RunInTransactionAspect]
        [LoggerAspect]
        public IEnumerable<NearByResult> Get(string lat, string lng)
        {
            IEnumerable<NearByResult> result = new List<NearByResult>();
            try
            {
               //get instance
                var api = GooglePlaceApiServices.Instance();
                result = api.NearbySearch(double.Parse(lat, NumberFormat.GetFormat()), 
                    double.Parse(lng, NumberFormat.GetFormat())).Results.ToArray();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception during geting places data: " +
                ex.ToString());
            }
            return result;
        }
    }
}
