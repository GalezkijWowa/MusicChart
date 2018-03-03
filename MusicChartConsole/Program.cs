using System;
using MusicChartConsole.Models;
using TagLib;
using TagLib.Mpeg;

namespace MusicChartConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioFile audio; 
            foreach (string s in FileSeracher.SearchFiles(@"c:\Users\v.galetsky\AppData\Local\Google\Chrome\User Data\Default\"))
            {
                audio = new AudioFile(s, ReadStyle.Average);

            }
            Console.ReadLine();
        }
    }
}
