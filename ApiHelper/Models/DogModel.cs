using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiHelper.Models
{
    public class DogModel
    {
        [JsonProperty("message")]
        public List<string> imglist { get; set; }

        [JsonProperty("status")]
        public string validation { get; set; }
    }
}
