using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public class PageInfo
    {
        public static int PageSize { get; set; } = 10;
        public static int TotalItems { get; set; } = 50;
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
