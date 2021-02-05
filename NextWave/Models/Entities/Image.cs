using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NextWave.Models.Entities
{
    [Owned]
    public class Image
    {
        public string Full { get; set; }
        public string Sprite { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
    }
}
