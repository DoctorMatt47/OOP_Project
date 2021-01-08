using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NextWave.Domain.RiotWebApi;
using NextWave.Models;
using NextWave.Services;

namespace NextWave.Controllers
{
    public class SummonerController : Controller
    {
        private readonly IRiotWebApi _riotWebApi;

        public SummonerController(IRiotWebApi riotWebApi)
        {
            _riotWebApi = riotWebApi;
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Find(string name, string region)
        {
            var summoner = _riotWebApi.GetSummonerByName(name, region);
            var leagues = _riotWebApi.GetLeaguesById(summoner.Id, region);
            var matchHistory = _riotWebApi.GetMatchesById(summoner.AccountId, region);
            ViewBag.Summoner = summoner;
            ViewBag.Leagues = leagues;
            ViewBag.MatchHistory = matchHistory;
            return View();
        }
    }
}
