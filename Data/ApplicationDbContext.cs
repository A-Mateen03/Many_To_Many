using E_CommerceSite.Models;
using Microsoft.EntityFrameworkCore;
using RelationShip_Many_Many.Models;

namespace RelationShip_Many_Many.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Buyer> buyers { get; set; }
        public DbSet<Products> Products { get; set; }

        public DbSet<BuyerProducts> BuyerProduct { get; set; }
    }
}
