using Microsoft.EntityFrameworkCore;
using Prueba.Infraestructure.Models;

namespace Prueba.Infraestructure.Context;

public class PruebaDBContext : DbContext
{
    public PruebaDBContext()
    {
        
    }
    public PruebaDBContext(DbContextOptions<PruebaDBContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Snapshot> Snapshots{ get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=UPC@intranet_17;Database=freezer", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>().ToTable("products");
        builder.Entity<Product>().HasKey(p => p.id);
        builder.Entity<Product>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.serialNumber).IsRequired();
        builder.Entity<Product>().Property(p => p.brand).IsRequired();
        builder.Entity<Product>().Property(p => p.model).IsRequired();
        builder.Entity<Product>().Property(p => p.monitoringLevel).IsRequired();
        
        
        builder.Entity<Snapshot>().ToTable("snapshots");
        builder.Entity<Snapshot>().HasKey(s => s.id);
        builder.Entity<Snapshot>().Property(s => s.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Snapshot>().Property(s => s.temperature).IsRequired();
        builder.Entity<Snapshot>().Property(s => s.energy);
        builder.Entity<Snapshot>().Property(s => s.leakage);
        
    }
}