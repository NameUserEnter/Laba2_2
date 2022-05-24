using Microsoft.EntityFrameworkCore;
namespace Confectionery.Models
{
    public class ConfectioneryAPIContext:DbContext
    {
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Dessert> Desserts { get; set; } = null!;
        public virtual DbSet<ConfectionersDessert> ConfectionersDesserts { get; set; } = null!;
        public virtual DbSet<Confectioner> Confectioners { get; set; } = null!;
        public virtual DbSet<Factory> Factories { get; set; } = null!;
        public ConfectioneryAPIContext(DbContextOptions<ConfectioneryAPIContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
