using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextWave.Models
{
    public class ChampionStats
    {
        public string Name { get; set; }
        public float PickRate { get; set; }
        public float WinRate { get; set; }
        public float BanRate { get; set; }
    }
}
