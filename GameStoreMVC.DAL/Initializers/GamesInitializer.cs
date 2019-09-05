using GameStoreMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreMVC.DAL.Initializers
{
    public class GamesInitializer : DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            Producer producer1 = new Producer()
            {
                Name = "Cd Project Red"
            };

            Producer producer2 = new Producer()
            {
                Name = "Bethesda"
            };

            Game[] games = new Game[]
            {
                new Game {Name = "The Witcher 3", Producer = producer1, Year=2015},
                new Game {Name = "Cyberpank 2077", Producer = producer1, Year = 2077},
                new Game {Name = "Skyrim 2", Producer = producer2,Year = 2022},
                new Game {Name = "Morrowind", Producer = producer2,Year = 2003},
                new Game {Name = "The Witcher 3", Producer = producer1, Year=2015},
                new Game {Name = "Cyberpank 2077", Producer = producer1, Year = 2077},
                new Game {Name = "Skyrim 2", Producer = producer2,Year = 2022},
                new Game {Name = "Morrowind", Producer = producer2,Year = 2003},
                new Game {Name = "The Witcher 3", Producer = producer1, Year=2015},
                new Game {Name = "Cyberpank 2077", Producer = producer1, Year = 2077},
                new Game {Name = "Skyrim 2", Producer = producer2,Year = 2022},
                new Game {Name = "Morrowind", Producer = producer2,Year = 2003},
                new Game {Name = "The Witcher 3", Producer = producer1, Year=2015},
                new Game {Name = "Cyberpank 2077", Producer = producer1, Year = 2077},
                new Game {Name = "Skyrim 2", Producer = producer2,Year = 2022},
                new Game {Name = "Morrowind", Producer = producer2,Year = 2003},
                new Game {Name = "The Witcher 3", Producer = producer1, Year=2015},
                new Game {Name = "Cyberpank 2077", Producer = producer1, Year = 2077},
                new Game {Name = "Skyrim 2", Producer = producer2,Year = 2022},
                new Game {Name = "Morrowind", Producer = producer2,Year = 2003},
                new Game {Name = "The Witcher 3", Producer = producer1, Year=2015},
                new Game {Name = "Cyberpank 2077", Producer = producer1, Year = 2077},
                new Game {Name = "Skyrim 2", Producer = producer2,Year = 2022},
                new Game {Name = "Morrowind", Producer = producer2,Year = 2003},
                new Game {Name = "The Witcher 3", Producer = producer1, Year=2015},
                new Game {Name = "Cyberpank 2077", Producer = producer1, Year = 2077},
                new Game {Name = "Skyrim 2", Producer = producer2,Year = 2022},
                new Game {Name = "Morrowind", Producer = producer2,Year = 2003},
                new Game {Name = "The Witcher 3", Producer = producer1, Year=2015},
                new Game {Name = "Cyberpank 2077", Producer = producer1, Year = 2077},
                new Game {Name = "Skyrim 2", Producer = producer2,Year = 2022},
                new Game {Name = "Morrowind", Producer = producer2,Year = 2003},
                new Game {Name = "The Witcher 3", Producer = producer1, Year=2015},
                new Game {Name = "Cyberpank 2077", Producer = producer1, Year = 2077},
                new Game {Name = "Skyrim 2", Producer = producer2,Year = 2022},
                new Game {Name = "Morrowind", Producer = producer2,Year = 2003}
            };

            context.Games.AddRange(games);

            context.SaveChanges();
        }
    }
}
