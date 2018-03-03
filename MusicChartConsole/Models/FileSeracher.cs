using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace MusicChartConsole.Models
{
    class FileSeracher
    {
        public static string[] SearchFiles(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}
