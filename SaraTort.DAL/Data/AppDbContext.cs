using Microsoft.EntityFrameworkCore;
using SaraTort.Domain.Entities.Catalog;
using SaraTort.Domain.Entities.Orders;
namespace SaraTort.DAL.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Catalog
    public DbSet<Category> Category { get; set; }
    public DbSet<Cake> Cakes { get; set; }
    public DbSet<CakeOption> CakeOptions { get; set; }
    public DbSet<CakeReview> CakeReviews { get; set; }

    // Orders
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CakeOption>().Property(o => o.Price).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasPrecision(18, 2);
        modelBuilder.Entity<OrderItem>().Property(i => i.PriceAtPurchase).HasPrecision(18, 2);
    }
}