using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NextWave.Domain.Extensions;
using NextWave.Models;

namespace NextWave.Domain.StatsParser
{
    public class ChampionGgStatsParser
    {
        public IEnumerable<ChampionStats> GetChampionsStats()
        {
            var client = new HttpClient();
            var doc = new HtmlDocument();
            var htmlResult = client.GetStringAsync(new Uri("https://www.leagueofgraphs.com/champions/builds")).Result;
            doc.LoadHtml(htmlResult);
            var trNodes = doc.GetElementbyId("mainContent").ChildNodes[1].ChildNodes[1].ChildNodes[1]
                .ChildNodes[1].ChildNodes.Where(x => x.Name == "tr");
            var trNodeaebeab = trNodes.Count();

            return (
                from trNode in trNodes
                select trNode.ChildNodes.Where(x => x.Name == "td").ToArray()
                into tdNodes where tdNodes.Length >= 3
                let name = tdNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes[3].ChildNodes[1].InnerText.Trim()
                let pickRate = float.Parse(tdNodes[2].InnerHtml.Trim()
                    .Substring(25, 6).CleanOfNonDigits(), new CultureInfo("en-US"))
                let winRate = float.Parse(tdNodes[3].InnerHtml.Trim()
                    .Substring(25, 6).CleanOfNonDigits(), new CultureInfo("en-US"))
                let banRate = float.Parse(tdNodes[4].InnerHtml.Trim()
                    .Substring(25, 6).CleanOfNonDigits(), new CultureInfo("en-US"))
                select new ChampionStats {
                    Name = name,
                    PickRate = pickRate,
                    WinRate = winRate,
                    BanRate = banRate

                }).ToList();
        }
    }
}
