using Forecast.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Forecast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string appId = "01477878eamshdf97cfc909aea0cp12e539jsn0a0b9f976e7d";
            string url = string.Format("https://restcountries.eu/rest/v1/all");
            //HttpClient client = new HttpClient();

            ////client.DefaultRequestHeaders.Add("x-rapidapi-key", appId);
            //var responce = JsonConvert.DeserializeObject(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();

                var jsonContent = serializer.Deserialize<dynamic>(json);
                List<string> Countries = new List<string>();
                for (int i = 0; i <250;i++)
                {
                    Countries.Add(jsonContent[i]["name"]);
                }
                //IEnumerable<SelectListItem> countries = Countries.Select(x => new SelectListItem() { Value });


                ViewBag.Countries = new SelectList(Countries);
            }
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public JsonResult GetWeatherInfo(string CityName)
        {

            string appId = "d987a71c9530144cb1f504ebc92f81e8";
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + CityName + "&appid=" + appId);
            WeatherInfoViewModel weatherInfoViewModel = new WeatherInfoViewModel();


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();


                var jsonContent = serializer.Deserialize<dynamic>(json);
                WeatherInfo weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);
                weatherInfoViewModel.pressure =Convert.ToString(jsonContent["main"]["pressure"]);
                weatherInfoViewModel.temperature = Convert.ToString(jsonContent["main"]["temp"]);
                //weatherInfoViewModel.description =Convert.ToString(jsonContent["weather"]["main"]);
                weatherInfoViewModel.Wind_Speed = Convert.ToString(jsonContent["wind"]["speed"]);
                weatherInfoViewModel.city = Convert.ToString(jsonContent["name"]);
                weatherInfoViewModel.min = string.Format("{0}°С", Math.Round(jsonContent["main"]["temp_min"], 1));
                weatherInfoViewModel.max = string.Format("{0}°С", Math.Round(jsonContent["main"]["temp_max"], 1));
                weatherInfoViewModel.humidity = jsonContent["main"]["humidity"]; 
            }
            return Json(new { data = weatherInfoViewModel }, JsonRequestBehavior.AllowGet);
        }
    }
}