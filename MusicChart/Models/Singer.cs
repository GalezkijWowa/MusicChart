﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class Singer
    {
        public int SingerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Song> Songs { get; set; }
    }
}
