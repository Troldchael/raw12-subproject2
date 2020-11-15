﻿using System;
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

        //framework
        public DbSet<Users> Users { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<RatingHistory> RatingHistory { get; set; }
        public DbSet<TitleBookmarking> TitleBook { get; set; }
        public DbSet<ActorBookmarking> ActorBook { get; set; }

        //Moviedata
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Details> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

            // nico local database
            //optionsBuilder.UseNpgsql("host=localhost;;db=imdb;uid=postgres;pwd=Kiwikatte2");
            
            // rawdata remote database
            optionsBuilder.UseNpgsql("host=rawdata.ruc.dk;port=5432;db=raw12;uid=raw12;pwd=uWISa4yb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // framework entities///////

            // users table 
            modelBuilder.Entity<Users>().ToTable("users").HasKey(x => x.UserId);
            modelBuilder.Entity<Users>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Users>().Property(x => x.Username).HasColumnName("username");
            modelBuilder.Entity<Users>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<Users>().Property(x => x.Password).HasColumnName("password");

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


            // Movie data entities ////////////

            //actors table
            modelBuilder.Entity<Actors>().ToTable("name").HasKey(x => x.Nconst);
            modelBuilder.Entity<Actors>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<Actors>().Property(x => x.PrimaryName).HasColumnName("primaryname");

            //movies table
            modelBuilder.Entity<Movies>().ToTable("title").HasKey(x => x.TitleId);
            modelBuilder.Entity<Movies>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Movies>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Movies>().Property(x => x.TitleType).HasColumnName("titletype");

            //genres table
            modelBuilder.Entity<Genres>().ToTable("genres").HasKey(x => x.TitleId);
            modelBuilder.Entity<Genres>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Genres>().Property(x => x.Genre).HasColumnName("genre");

            //details table
            modelBuilder.Entity<Details>().ToTable("details").HasKey(x => x.TitleId);
            modelBuilder.Entity<Details>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Details>().Property(x => x.Startyear).HasColumnName("startyear");
            modelBuilder.Entity<Details>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<Details>().Property(x => x.RunTimeMinutes).HasColumnName("runtimeminutes");
        }
    }

    
}