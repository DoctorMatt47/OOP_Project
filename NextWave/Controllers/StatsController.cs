using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NextWave.Domain.StatsParser;

namespace NextWave.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Champions()
        {
            var parser = new ChampionGgStatsParser();
            ViewBag.ChampionsStats = parser.GetChampionsStats();
            return View();
        }
    }
}
