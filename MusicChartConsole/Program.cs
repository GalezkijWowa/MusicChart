using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuisnessModel.Models;
using DatabaseModel.Data;
using EntityModel.Models;
using MusicChartConsole.Models;
using TagLib;
using TagLib.Mpeg;

namespace MusicChartConsole
{
    class Program
    {
        private static string _path = @"d:\songs\";

        public static async Task Main(string[] args)
        {
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                DbPathWriter pathWriter = new DbPathWriter(context);
                AudioFile audio;
                string fullPath;
                foreach (string s in FileSeracher.SearchFiles(_path))
                {
                    audio = new AudioFile(s, ReadStyle.Average);
                    fullPath = audio.Name;
                    await pathWriter.AddPath(audio.Tag.Performers[0], audio.Tag.Title, fullPath);
                }
            }
        }
    }
}
