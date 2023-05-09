using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace Entity.Data;

public partial class PizzaDbContext : DbContext
{
    public PizzaDbContext()
    {
    }

    public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PizzaInfo> PizzaInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    
       => optionsBuilder.UseSqlServer("Server=PCA167\\SQL2017;User=sa;Password=Tatva@123;Database=PizzaDb;TrustServerCertificate=True;");
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PizzaInfo>(entity =>
        {
            entity.ToTable("PizzaInfo");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
