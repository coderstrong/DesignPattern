using Microsoft.EntityFrameworkCore;
using Repository.Domain;
namespace Repository.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext()
           : base("name=ProductAppConnectionString")
        {
        }
        public DbSet Products { get; set; }
    }
}

