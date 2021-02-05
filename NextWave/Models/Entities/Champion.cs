using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NextWave.Models.Entities
{
    public class Champion
    {
        public string Key { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public Image Image { get; set; }
    }
}
