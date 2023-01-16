using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace DogAPI.Controllers
{
    public class DogBreedList
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public string[] Subreeds { get; set; }
    }
    public class DogImage
    {
        public DogImage(string json)
        {
            JObject jObject = o["high"].bJObject.Parse(json);
            Status = (string)jObject["status"];
            Message = (string)jObject["message"].ToArray();
        }

        public string Status { get; set; }
        public string[] Message { get; set; }
    }

    public class CallAPI
    {
       
    }

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Hallo World";
            return View();
        }
    }
}