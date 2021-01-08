using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextWave.Models
{
    public class Match
    {
        public long GameId { get; set; }
        public int Champion { get; set; }
        public int Queue { get; set; }
        public int Season { get; set; }
        public string Role { get; set; }
        public string Lane { get; set; }
    }
}
