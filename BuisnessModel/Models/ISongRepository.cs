using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public interface ISongRepository
    {
        Task<List<Song>> GetTopSongsAsync(string singerName);
    }
}
