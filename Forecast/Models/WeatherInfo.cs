using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forecast.Models
{
    public class WeatherInfo
    {
        public City city { get; set; }
        public List<List> list { get; set; }
    }
}