using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Interviews.Models;

public partial class MobylabAppContext : DbContext
{
    public MobylabAppContext()
    {
    }

    public MobylabAppContext(DbContextOptions<MobylabAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString: "Server=localhost;Port=5432;Database=mobylab-app;User Id=mobylab-app;Password=mobylab-app;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.CId)
                .ValueGeneratedOnAdd()
                .HasColumnName("c_id");
            entity.Property(e => e.CName)
                .HasMaxLength(20)
                .HasColumnName("c_name");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("companies_pkey");

            entity.ToTable("companies");

            entity.Property(e => e.CompId)
                .ValueGeneratedOnAdd()
                .HasColumnName("comp_id");
            entity.Property(e => e.CompName)
                .HasMaxLength(20)
                .HasColumnName("comp_name");
            entity.Property(e => e.CompPositionId).HasColumnName("comp_position_id");

            entity.HasOne(d => d.CompPosition).WithMany(p => p.Companies)
                .HasForeignKey(d => d.CompPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comp_pos_fk");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LId).HasName("levels_pkey");

            entity.ToTable("levels");

            entity.Property(e => e.LId)
                .ValueGeneratedOnAdd()
                .HasColumnName("l_id");
            entity.Property(e => e.LDescription)
                .HasMaxLength(100)
                .HasColumnName("l_description");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.Property(e => e.PId)
                .ValueGeneratedOnAdd()
                .HasColumnName("p_id");
            entity.Property(e => e.PName)
                .HasMaxLength(20)
                .HasColumnName("p_name");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("resources_pkey");

            entity.ToTable("resources");

            entity.Property(e => e.RId)
                .ValueGeneratedOnAdd()
                .HasColumnName("r_id");
            entity.Property(e => e.RCategoryId).HasColumnName("r_category_id");
            entity.Property(e => e.RCompanyId).HasColumnName("r_company_id");
            entity.Property(e => e.RLevelId).HasColumnName("r_level_id");
            entity.Property(e => e.RName)
                .HasMaxLength(20)
                .HasColumnName("r_name");
            entity.Property(e => e.RUrl)
                .HasMaxLength(100)
                .HasColumnName("r_url");

            entity.HasOne(d => d.RCategory).WithMany(p => p.Resources)
                .HasForeignKey(d => d.RCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("r_cat_fk");

            entity.HasOne(d => d.RCompany).WithMany(p => p.Resources)
                .HasForeignKey(d => d.RCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("r_comp_fk");

            entity.HasOne(d => d.RLevel).WithMany(p => p.Resources)
                .HasForeignKey(d => d.RLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("r_lvl_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");
            
            entity.ToTable("user");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.PasswordHash).HasColumnName("passwordhash");
            entity.Property(e => e.PasswordSalt).HasColumnName("passwordsalt");
            entity.Property(e => e.Username)
                .HasMaxLength(15)
                .HasColumnName("username");
            entity.Property(e => e.Role)
                .HasMaxLength(15)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
