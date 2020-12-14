using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Data.Model.GooglePlacesModel
{
    public class AppSettings
    {

        [JsonProperty("ApiKey")]
        public string ApiKey { get; set; }
    }

}
