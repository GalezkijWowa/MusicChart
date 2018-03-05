using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public interface IRemoteSingerRepository
    {
        Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20);
        Task<List<Singer>> GetSimiliarSingersAsync(string singerName);
        Task<Singer> GetSingerInfoAsync(string singerName);
        Task<Singer> GetFullSingerInfoAsync(string singerName);
        Task<string> GetSingerDescription(string singerName);
    }
}
