using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class LastFmSingerRepository : ISingerRepository
    {
        private ILastAuth _lastAuth;
        public LastFmSingerRepository()
        {
            _lastAuth = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
        }
        public async Task<List<Singer>> GetSimiliarSingersAsync(string singerName)
        {
            PageResponse<LastArtist> resp = await new ArtistApi(_lastAuth).GetSimilarArtistsAsync(singerName);
            List<Singer> singers = new List<Singer>();
            foreach (var artist in resp.Content)
            {
                singers.Add(new Singer
                {
                    Name = artist.Name,
                    Photo = artist.MainImage.ExtraLarge
                }
                );
            }
            return singers;
        }

        public async Task<Singer> GetSingerInfoAsync(string singerName)
        {
            LastResponse<LastArtist> singerResp = await new ArtistApi(_lastAuth).GetArtistInfoAsync(singerName);
            Singer singer = new Singer
            {
                SingerId = singerResp.Content.Name,
                Name = singerResp.Content.Name,
                Photo = singerResp.Content.MainImage.ExtraLarge,
                Description = singerResp.Content.Bio.Summary
            };
            return singer;
        }

        public async Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20)
        {
            PageResponse<LastArtist> _resp = await new ChartApi(_lastAuth).GetTopArtistsAsync(pageSize, PageInfo.PageSize);
            List<Singer> singers = new List<Singer>();
            foreach (var artist in _resp.Content)
            {
                singers.Add(new Singer
                {
                    Name = artist.Name,
                    Photo = artist.MainImage.ExtraLarge
                }
                );
            }
            return singers.Skip((pageSize - 1) * PageInfo.PageSize).Take(PageInfo.PageSize).ToList();
        }

        public async Task<int> TotalSingers()
        {
            PageResponse<LastArtist> _resp = await new ChartApi(_lastAuth).GetTopArtistsAsync();
            //return _resp.Content.Count;
            return 50;
        }
    }
}
