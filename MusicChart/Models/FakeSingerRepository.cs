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
                    SingerId="1",
                    Name = "Loboda",
                    Description = "Russian Singer Angelina Loboda"
                },
                new Singer()
                {
                    SingerId="2",
                    Name = "Eminem",
                    Description="White nigger"
                },
                new Singer()
                {
                    SingerId="3",
                    Name="Lady Gaga",
                    Description="Most titled American singer"
                }
            };
            set => throw new NotImplementedException(); }
    }
}
