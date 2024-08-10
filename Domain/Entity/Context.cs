using Microsoft.EntityFrameworkCore;

namespace api_produtos.Domain.Entity;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Products> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.InclusionUserId).IsRequired();
            entity.Property(e => e.InclusionDate).IsRequired();
            entity.Property(e => e.LastChangedUserId);
            entity.Property(e => e.LastChangedDate);
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.ExclusionUserId);
            entity.Property(e => e.ExclusionDate);
        });
    }
}
