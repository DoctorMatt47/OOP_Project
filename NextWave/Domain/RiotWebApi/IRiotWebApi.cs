using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextWave.Models;

namespace NextWave.Domain.RiotWebApi
{
    public interface IRiotWebApi
    {
        Summoner GetSummonerByName(string name, string region);
        IEnumerable<League> GetLeaguesById(string id, string region);
        MatchHistory GetMatchesById(string id, string region);
    }
}
