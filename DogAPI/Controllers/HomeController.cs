using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DogAPI.Controllers
{
    public abstract class Enumeration
    {
        public string Name { get; private set; }
        public int Id { get; private set; }

        protected Enumeration(int id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;
    }
    public class Words : Enumeration
    {
        public Words(int id, string name) : base(id, name) { }
        public static Words BaseURL = new Words(1, "https://dog.ceo/api");
        public static Words List = new Words(2, "/list");
        public static Words Random = new Words(3, "/random");
        public static Words Breed = new Words(5, "/breed");
        public static Words Images = new Words(6, "/images");
        public static Words All = new Words(7, "/all");
        public static Words Random_Dog = new Words(8, "/breeds/image/random");
    }
    public class DogBreedList
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public string[] Subreeds { get; set; }
        public DogBreedList() { }
    }
    public class DogImage
    {
        public string Status { get; set; }
        public string[] Message { get; set; }
        public DogImage() { }
    }

    public static class CallAPI
    {
       public static async void GetDogs()
        {
            DogImage dog = new DogImage();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Words.BaseURL.Name);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync(Words.Random_Dog.Name);
                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    dog = JsonConvert.DeserializeObject<DogImage>(result);
                }
            }
        }
    }

    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            CallAPI.GetDogs();
            ViewBag.Message = "Hallo World";
            return View();
        }

        static HttpClient client = new HttpClient();
    }
}