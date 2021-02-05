using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextWave.Models.Entities
{
    public class QueueType
    {
        [Key]
        public int QueueId { get; set; }
        public string Map { get; set; }
        public string Description { get; set; }
    }
}
