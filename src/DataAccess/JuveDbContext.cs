﻿using DataAccess.Domain;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess
{
    public class JuveDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PlayerType> PlayerTypes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JuveV;Integrated Security=True";

            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}