using Microservice.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Order.Persistence.Contexts
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-52A7HE5, InıtialCatelog = MultiShopOrderDb; integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orders {  get; set; }
    }
}