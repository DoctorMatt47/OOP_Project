﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextWave.Models
{
    public class MatchHistory
    {
        public IEnumerable<Match> Matches { get; set; }
        public int TotalGames { get; set; }
    }
}
