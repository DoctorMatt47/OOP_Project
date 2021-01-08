using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NextWave.Models;
using NextWave.Services;

namespace NextWave.Domain.RiotWebApi
{
    public class RiotWebApi : IRiotWebApi
    {
        public Summoner GetSummonerByName(string name, string region)
        {
            var uri = new Uri("https://"+ region + ".api.riotgames.com/lol/summoner/v4/summoners/by-name/" + name +
                              "?api_key=" + Config.ApiKey);
            Summoner response = null;
            try
            {
                response = new HttpClient().GetFromJsonAsync<Summoner>(uri).Result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return response;
        }

        public IEnumerable<League> GetLeaguesById(string id, string region)
        {
            var uri = new Uri("https://" + region + ".api.riotgames.com/lol/league/v4/entries/by-summoner/" + id +
                              "?api_key=" + Config.ApiKey);
            List<League> leagues = null;
            try
            {
                leagues = new HttpClient().GetFromJsonAsync<List<League>>(uri).Result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return leagues;
        }

        public MatchHistory GetMatchesById(string id, string region)
        {
            var uri = new Uri("https://" + region + ".api.riotgames.com/lol/match/v4/matchlists/by-account/" + id +
                              "?api_key=" + Config.ApiKey);
            MatchHistory matchHistory = null;
            try
            {
                matchHistory = new HttpClient().GetFromJsonAsync<MatchHistory>(uri).Result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return matchHistory;
        }
    }
}
