using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class CharacterController : Controller
    {

        public IActionResult Index()
        {
            using (var client = new HttpClient())
            {
                string url = "https://rickandmortyapi.com/api/character";
                client.DefaultRequestHeaders.Clear();

                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;

                var apiresponse = JsonConvert.DeserializeObject<Characters>(res);

                return View(apiresponse);

            }
        }
    }
}
