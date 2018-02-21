using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class FakeSingerRepository : ISingerRepository
    {
        public IEnumerable<Singer> Singers {
            get => new List<Singer>(){
                new Singer()
                {
                    Name = "Loboda",
                    Description = "Russian Singer Angelina Loboda"
                },
                new Singer()
                {
                    Name = "Eminem",
                    Description="White nigger"
                },
                new Singer()
                {
                    Name="Lady Gaga",
                    Description="Most titled American singer"
                }
            }
            ;
            set => throw new NotImplementedException(); }
    }
}
