using CouponAPI.Models.Coupon;
using Microsoft.EntityFrameworkCore;

namespace CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }
        public DbSet<Coupon> Coupons { get; set; }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            // Get all the entities that are being added or modified
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity);

            // Update the updateDate property for each entity
            foreach (var entity in entities)
            {
                var property = entity.GetType().GetProperty("UpdatedDate");
                if (property != null)
                {
                    property.SetValue(entity, DateTime.Now, null);
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
