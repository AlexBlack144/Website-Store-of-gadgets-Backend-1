using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Models;


namespace DataAccessEF.Data
{
    public partial class asp_tablesContext : IdentityDbContext<IdentityUser>
    {
        protected readonly IConfiguration Configuration;
        public asp_tablesContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Gadget> Gadgets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
            });

            modelBuilder.Entity<Gadget>(entity =>
            {
                entity.ToTable("Gadget");

                entity.Property(e => e.IdCategory).HasColumnName("Id_Category");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Gadgets)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Gadget__Id_Categ__30F848ED");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.IdGadget).HasColumnName("Id_Gadget");

                entity.HasOne(d => d.IdGadgetNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdGadget)
                    .HasConstraintName("FK__User__Id_Gadget__3B75D760");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}
