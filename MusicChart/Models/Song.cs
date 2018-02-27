﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class Song
    {
        [Key]
        public string SongId { get; set; }
        public string Name { get; set; }
        public string SingerId { get; set; }
    }
}
