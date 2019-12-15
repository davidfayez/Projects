using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forecast.Models
{
    public class WeatherInfoViewModel
    {
        public string city { get; set; }
        public string description { get; set; }
        public string min { get; set; }
        public string max { get; set; }
        public int humidity { get; set; }
        public string temperature { get; set; }
        public string pressure { get; set; }
        public string Wind_Speed { get; set; }

    }
}