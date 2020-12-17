using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib.Framework;
using DataServiceLib.Moviedata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataServiceLib
{
    public class Raw12Context : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Users> Users { get; set; }

        public DbSet<Details> Details { get; set; }

        public DbSet<Actors> Actors { get; set; }

        public DbSet<Genres> Genres { get; set; }

        public DbSet<Ratings> Ratings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

            //optionsBuilder.UseNpgsql("host=localhost;db=imdb;uid=postgres;pwd=Morten23801701#");

            //optionsBuilder.UseNpgsql("host=localhost;;db=imdb.2;uid=postgres;pwd=1234");


            // rawdata raw12 server
            optionsBuilder.UseNpgsql("host=rawdata.ruc.dk;port=5432;db=raw12;uid=raw12;pwd=uWISa4yb");

            //optionsBuilder.UseNpgsql("host=localhost;db=IMDB;uid=postgres;pwd=KaffeKop+1");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("users").HasKey(x => x.user_id);
            modelBuilder.Entity<Users>().Property(x => x.user_id).HasColumnName("user_id");
            modelBuilder.Entity<Users>().Property(x => x.username).HasColumnName("username");
            modelBuilder.Entity<Users>().Property(x => x.email).HasColumnName("email");
            modelBuilder.Entity<Users>().Property(x => x.password).HasColumnName("password");
            modelBuilder.Entity<Users>().Property(x => x.salt).HasColumnName("salt");

            modelBuilder.Entity<Details>().ToTable("title").HasKey(x => x.Tconst);
            modelBuilder.Entity<Details>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<Details>().Property(x => x.TitleType).HasColumnName("titletype");
            modelBuilder.Entity<Details>().Property(x => x.OriginalTitle).HasColumnName("originaltitle");

            modelBuilder.Entity<Actors>().ToTable("name").HasKey(x => x.Nconst);
            modelBuilder.Entity<Actors>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<Actors>().Property(x => x.PrimaryName).HasColumnName("primaryname");

            modelBuilder.Entity<Genres>().ToTable("genres").HasKey(x => x.Tconst);
            modelBuilder.Entity<Genres>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<Genres>().Property(x => x.Genre).HasColumnName("genre");

            modelBuilder.Entity<Ratings>().ToTable("ratings").HasKey(x => x.Tconst);
            modelBuilder.Entity<Ratings>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<Ratings>().Property(x => x.Averagerating).HasColumnName("averagerating");
            modelBuilder.Entity<Ratings>().Property(x => x.Numvotes).HasColumnName("numvotes");



        }
    }

    //Hej

}