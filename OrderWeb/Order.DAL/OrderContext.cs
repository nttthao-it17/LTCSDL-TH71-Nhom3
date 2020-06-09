using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Order.DAL.Models
{
    public partial class OrderContext : DbContext
    {
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoaiLogin> LoaiLogin { get; set; }
        public virtual DbSet<LoaiThucAn> LoaiThucAn { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<ThucAn> ThucAn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8CB76R1\\HUEJH;Initial Catalog=Order;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiLogin>(entity =>
            {
                entity.HasKey(e => e.MaLoaiLogin);

                entity.Property(e => e.MaLoaiLogin)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaNguoiDung)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.LoaiLogin)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_LoaiLogin_Login");
            });

            modelBuilder.Entity<LoaiThucAn>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TenLoaiThucAn).HasMaxLength(50);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung);

                entity.Property(e => e.MaNguoiDung)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.MaLoai)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.MaOrder);

                entity.Property(e => e.MaOrder)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Gia).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GiamGia).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MaThucAn)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TenThucAn).HasMaxLength(50);

                entity.HasOne(d => d.MaThucAnNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.MaThucAn)
                    .HasConstraintName("FK_Order_ThucAn");
            });

            modelBuilder.Entity<ThucAn>(entity =>
            {
                entity.HasKey(e => e.MaThucAn);

                entity.Property(e => e.MaThucAn)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Gia).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GiamGia).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TenThucAn).HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.ThucAn)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_ThucAn_LoaiThucAn");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
