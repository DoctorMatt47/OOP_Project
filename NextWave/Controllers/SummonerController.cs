using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NextWave.Models;
using NextWave.Services;

namespace NextWave.Controllers
{
    public class SummonerController : Controller
    {
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Find(string id)
        {
            var uri = new Uri("https://ru.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + id +
                              "?api_key=" + Config.ApiKey);
            try
            {
                var response = new HttpClient().GetFromJsonAsync<Summoner>(uri);
                ViewBag.Summoner = response.Result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return View();
        }
    }
}
