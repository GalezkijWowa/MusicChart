﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public interface ISingerRepository
    {
        IEnumerable<Singer> Singers { get; }
    }
}
