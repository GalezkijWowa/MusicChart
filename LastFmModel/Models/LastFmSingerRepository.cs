﻿using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastFmModel.Models
{
    public class LastFmSingerRepository : ISingerRepository
    {
        private ILastAuth _lastAuth;
        private IAlbumRepository _albumRepo;
        private ISongRepository _songRepo;

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
                    SingerId = artist.Name,
                    Name = artist.Name,
                    Photo = new Image ( artist.MainImage.ExtraLarge ),
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
                Photo = new Image(singerResp.Content.MainImage.ExtraLarge),
                Description = singerResp.Content.Bio.Summary,
            };
            return singer;
        }

        public async Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20)
        {
            PageResponse<LastArtist> _resp = await new ChartApi(_lastAuth).GetTopArtistsAsync(pageSize, PageInfo.PageSize);
            List<Singer> singers = new List<Singer>();
            Singer topSinger;
            foreach (var artist in _resp.Content.Skip((pageSize - 1) * PageInfo.PageSize).Take(PageInfo.PageSize).ToList())
            {
                topSinger = await GetSingerInfoAsync(artist.Name);
                topSinger.IsTop = 1;
                singers.Add(topSinger);
            }
            return singers;
        }
    }
}
