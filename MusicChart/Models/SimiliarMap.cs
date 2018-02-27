using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class SimiliarMap
    {
        [Key]
        public string SimiliarMapId { get; set; }
        public string SingerId { get; set; }
        public string SimiliarSingerId { get; internal set; }
    }
}
