﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forecast.Models
{
    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
    }
}