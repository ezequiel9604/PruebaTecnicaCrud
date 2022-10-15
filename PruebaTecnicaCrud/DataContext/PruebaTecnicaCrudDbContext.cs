
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCrud.Models;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;
using System;

namespace PruebaTecnicaCrud.DataContext
{
    public class PruebaTecnicaCrudDbContext : DbContext
    {

        public PruebaTecnicaCrudDbContext(DbContextOptions<PruebaTecnicaCrudDbContext> options)
           : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Client>()
            .HasIndex(x => x.Email)
            .IsUnique();

        }


        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
