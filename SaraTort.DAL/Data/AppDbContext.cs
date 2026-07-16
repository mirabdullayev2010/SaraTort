using Microsoft.EntityFrameworkCore;
using SaraTort.Domain.Entities;
using SaraTort.Domain.Entities.Catalog;
using SaraTort.Domain.Entities.Orders;
namespace SaraTort.DAL.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Category { get; set; }
    public DbSet<Cake> Cakes { get; set; }
    public DbSet<CakeReview> CakeReviews { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<orderItem> OrderItems { get; set; } 
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasPrecision(18, 2);
        modelBuilder.Entity<orderItem>().Property(i => i.PriceAtPurchase).HasPrecision(18, 2);
    }
}