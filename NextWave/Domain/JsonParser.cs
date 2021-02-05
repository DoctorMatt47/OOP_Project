using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NextWave.Models.Entities;

namespace NextWave.Domain
{
    public static class JsonParser
    {
        public static IEnumerable<QueueType> GetQueueTypesFromJson(string path = "wwwroot/json/queues.json")
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            using var createStream = System.IO.File.OpenRead(path);
            var queueTypes = JsonSerializer.DeserializeAsync<List<QueueType>>(createStream, options).Result;
            return queueTypes;
        }

        public static IEnumerable<Champion> GetChampionsFromJson(string path = "wwwroot/json/champion.json")
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            using var createStream = System.IO.File.OpenRead(path);
            var dictionary = JsonSerializer.DeserializeAsync<Dictionary<string, Champion>>(createStream, options)
                .Result;
            return dictionary.Values.ToList();
        }

        public static IEnumerable<ProfileIcon> GetIconsFromJson(string path = "wwwroot/json/profileicon.json")
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            using var createStream = System.IO.File.OpenRead(path);
            var dictionary = JsonSerializer.DeserializeAsync<Dictionary<string, ProfileIcon>>(createStream, options)
                .Result;
            var dictList = dictionary.Values.ToList();
            return dictList;
        }
    }
}
