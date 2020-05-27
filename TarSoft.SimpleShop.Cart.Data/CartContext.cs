using Microsoft.EntityFrameworkCore;
using System.Linq;
using TarSoft.SimpleShop.Cart.Domain;

namespace TarSoft.SimpleShop.Cart.Data
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<NewCart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS;database=SimpleShop;user id=SimpleShop;password=SimpleShop");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Cart");
            modelBuilder.Entity<NewCart>().HasKey(c => c.Id);
            modelBuilder.Ignore<RevisitedCart>();
            //modelBuilder.Types<IStateObject>().Configure(c => c.Ignore(p => p.State));

            var entityTypes = modelBuilder.Model.GetEntityTypes()
                .Where(t => typeof(IStateObject).IsAssignableFrom(t.ClrType));
            foreach (var entityType in entityTypes)
            {
                var entityTypeBuilder = modelBuilder.Entity(entityType.ClrType);
                entityTypeBuilder.Ignore("State");
            }


            base.OnModelCreating(modelBuilder);
        }


    }
}
