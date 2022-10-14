
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCrud.Models;

namespace PruebaTecnicaCrud.DataContext
{
    public class PruebaTecnicaCrudDbContext : DbContext
    {

        public PruebaTecnicaCrudDbContext(DbContextOptions<PruebaTecnicaCrudDbContext> options)
           : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
