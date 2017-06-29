using Infnet.Azure.Assessment.Entities;
using System.Data.Entity;

namespace Infnet.Azure.Assessment.Data
{
    public class Database : DbContext
    {
        public Database() : base("DefaultConnection") {}

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
