using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public class Singer
    {
        [Key]
        public string SingerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Photo { get; set; }
        public int IsTop { get; set; } = 0; // 1- true, 0 - false
        public string ImageId { get; set; }
    }
}
