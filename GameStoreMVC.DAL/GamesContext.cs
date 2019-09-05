namespace GameStoreMVC.DAL
{
    using GameStoreMVC.DAL.Entities;
    using GameStoreMVC.DAL.Initializers;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    public class GamesContext : IdentityDbContext<AppUser>
    {
       
        public GamesContext()
            : base("name=GamesContext")
        {
            Database.SetInitializer(new GamesInitializer());
            Database.Log = (s=>
            {
                Debug.Write(s);
            });
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Producer> Producers { get; set; }


        public static GamesContext Create()
        {
            return new GamesContext();
        }
    }
}