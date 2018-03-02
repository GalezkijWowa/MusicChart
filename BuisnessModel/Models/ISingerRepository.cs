using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public interface ISingerRepository
    {
        Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20);
        Task<List<Singer>> GetSimiliarSingersAsync(string singerName);
        Task<Singer> GetSingerInfoAsync(string singerName);
        Task<Singer> GetFullSingerInfoAsync(string singerName);
        Task<string> GetSingerDescription(string singerName);
    }
}
