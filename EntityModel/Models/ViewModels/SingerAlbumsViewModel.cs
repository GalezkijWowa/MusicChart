﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityModel.Models.ViewModels
{
    public class SingerAlbumsViewModel
    {
        public Singer Singer { get; set; }
        public IEnumerable<Album> Albums { get; set; }
    }
}
