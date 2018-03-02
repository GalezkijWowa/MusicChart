using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessModel.Models.ViewModels
{
    public class SingerListViewModel
    {
        public IEnumerable<Singer> Singers { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
