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
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<RatingHistory> RatingHistory { get; set; }
        public DbSet<TitleBookmarking> TitleBook { get; set; }
        public DbSet<ActorBookmarking> ActorBook { get; set; }

        public DbSet<Details> Details { get; set; }

        public DbSet<Actors> Actors { get; set; }

        public DbSet<Genres> Genres { get; set; }

        public DbSet<Ratings> Ratings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

<<<<<<< HEAD
            optionsBuilder.UseNpgsql("host=localhost;;db=imdb;uid=postgres;pwd=Kiwikatte2");

            optionsBuilder.UseNpgsql("host=localhost;;db=imdb.2;uid=postgres;pwd=1234");


            // rawdata raw12 server
=======
            // nico local database
            optionsBuilder.UseNpgsql("host=localhost;;db=imdb;uid=postgres;pwd=Kiwikatte2");
            
            // rawdata remote database
>>>>>>> nicobranch1
            //optionsBuilder.UseNpgsql("host=rawdata.ruc.dk;port=5432;db=raw12;uid=raw12;pwd=uWISa4yb");

            optionsBuilder.UseNpgsql("host=localhost;db=IMDB;uid=postgres;pwd=KaffeKop+1");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // framework entities
            // users table 
            modelBuilder.Entity<Users>().ToTable("users").HasKey(x => x.UserId);
            modelBuilder.Entity<Users>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Users>().Property(x => x.Username).HasColumnName("username");
            modelBuilder.Entity<Users>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<Users>().Property(x => x.Password).HasColumnName("password");

<<<<<<< HEAD
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



=======
            // search_history table
            modelBuilder.Entity<SearchHistory>().ToTable("search_history").HasKey(x => x.UserId);
            modelBuilder.Entity<SearchHistory>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Timestamp).HasColumnName("timestamp");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Keyword).HasColumnName("keyword");

            // rating_history table
            modelBuilder.Entity<RatingHistory>().ToTable("rating_history").HasKey(x => x.UserId);
            modelBuilder.Entity<RatingHistory>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<RatingHistory>().Property(x => x.Rating).HasColumnName("rating");
            modelBuilder.Entity<RatingHistory>().Property(x => x.TitleId).HasColumnName("title_id");

            // actor_bookmarking table
            modelBuilder.Entity<ActorBookmarking>().ToTable("actor_bookmarking").HasKey(x => x.UserId);
            modelBuilder.Entity<ActorBookmarking>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<ActorBookmarking>().Property(x => x.Nconst).HasColumnName("nconst");

            // title_bookmarking table
            modelBuilder.Entity<TitleBookmarking>().ToTable("title_bookmarking").HasKey(x => x.UserId);
            modelBuilder.Entity<TitleBookmarking>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<TitleBookmarking>().Property(x => x.TitleId).HasColumnName("title_id");

            // Movie data entities
            //make diz
>>>>>>> nicobranch1
        }
    }

    //Hej

}