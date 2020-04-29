using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CouponManagementDBEntity.Models
{
    public partial class CouponManagementContext : DbContext
    {
        public CouponManagementContext()
        {
        }

        public CouponManagementContext(DbContextOptions<CouponManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CouponDetails> CouponDetails { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KJSLJO5\\SQLEXPRESS;Database=CouponManagement;User Id=sa; Password=sravani;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CouponDetails>(entity =>
            {
                entity.HasKey(e => e.CouponId)
                    .HasName("PK__CouponDe__384AF1BA1B25FEAF");

                entity.Property(e => e.CouponExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.CouponNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CouponStartDate).HasColumnType("datetime");

                entity.Property(e => e.CouponStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CouponDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CouponDet__UserI__300424B4");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__1788CC4C367E4FCF");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__UserDeta__C9F284560F09F1D9")
                    .IsUnique();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddr)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
