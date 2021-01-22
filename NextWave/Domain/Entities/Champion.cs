using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextWave.Domain.Entities;

namespace NextWave.Models
{
    public class Champion
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
    }
}
