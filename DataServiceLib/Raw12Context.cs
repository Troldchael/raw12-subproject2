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

        public DbSet<Users> Users { get; set; }

        public DbSet<Details> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseNpgsql("host=localhost;db=imdb.2;uid=postgres;pwd=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("users").HasKey(x => x.UserId);
            modelBuilder.Entity<Users>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Users>().Property(x => x.Username).HasColumnName("username");
            modelBuilder.Entity<Users>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<Users>().Property(x => x.Password).HasColumnName("password");

            modelBuilder.Entity<Details>().ToTable("title").HasKey(x => x.Tconst);
            modelBuilder.Entity<Details>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<Details>().Property(x => x.TitleType).HasColumnName("titletype");
            modelBuilder.Entity<Details>().Property(x => x.OriginalTitle).HasColumnName("originaltitle");



        }
    }

    
}