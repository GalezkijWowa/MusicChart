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
                    Name = "LOBODA",
                    Description = "Светла́на Серге́евна Лобода́ (укр. Світла́на Сергі́ївна Лобода́), также известная как LOBODA (род. 18 октября 1982, Киев, УССР, СССР) — украинская певица, ведущая, автор песен. Заслуженная артистка Украины (2013)[1]. Бывшая солистка группы «ВИА Гра» (2004).",
                    Photo="https://upload.wikimedia.org/wikipedia/commons/thumb/7/7f/LOBODA_%284%29_%D0%BD%D0%B0_Big_Love_Show_2018_%D0%B2_%D0%A1%D0%9F%D0%B1.jpg/267px-LOBODA_%284%29_%D0%BD%D0%B0_Big_Love_Show_2018_%D0%B2_%D0%A1%D0%9F%D0%B1.jpg"
                },
                new Singer()
                {
                    SingerId="2",
                    Name = "Eminem",
                    Description="Ма́ршалл Брюс Мэ́терс III (англ. Marshall Bruce Mathers III; 17 октября 1972, Сент-Джозеф, Миссури, США)[2], более известный под сценическим псевдонимом Эмине́м (англ. Eminem; стилизовано как EMINƎM) и альтер-эго Слим Шейди (англ. Slim Shady) — американский рэпер, музыкальный продюсер, композитор и актёр. Помимо сольной карьеры, Маршалл также состоит в группе D12 и хип-хоп-дуэте Bad Meets Evil. Эминем является одним из самых продаваемых музыкальных артистов в мире, а также самым продаваемым артистом 2000-х[3]. ", 
                    Photo=@"https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Eminem_-_Concert_for_Valor_in_Washington%2C_D.C._Nov._11%2C_2014_%282%29_%28Cropped%29.jpg/267px-Eminem_-_Concert_for_Valor_in_Washington%2C_D.C._Nov._11%2C_2014_%282%29_%28Cropped%29.jpg"
                },
                new Singer()
                {
                    SingerId="3",
                    Name="Lady Gaga",
                    Description="Ле́ди Га́га (англ. Lady Gaga; настоящее имя — Сте́фани Джоа́нн Анджели́на Джермано́тта (англ. Stefani Joanne Angelina Germanotta[4]), род. 28 марта 1986, Нью-Йорк[5]) — американская певица, автор песен, продюсер, филантроп, дизайнер и актриса. Начинала свою карьеру с выступлений в клубах, а к концу 2007 года продюсер Винсент Херберт подписал певицу на лейбл Streamline Records, который является ответвлением Interscope Records. Изначально Гага работала в качестве штатного автора Interscope, но после того, как вокальные данные Гаги привлекли рэпера Эйкона, с ней был подписан контракт на запись альбома.",
                    Photo=@"https://upload.wikimedia.org/wikipedia/commons/thumb/b/b3/Lady_Gaga_Toronto_Film_Festival_2017_%28cropped2%29.jpg/300px-Lady_Gaga_Toronto_Film_Festival_2017_%28cropped2%29.jpg"
                }
            };
        }
    }
}
