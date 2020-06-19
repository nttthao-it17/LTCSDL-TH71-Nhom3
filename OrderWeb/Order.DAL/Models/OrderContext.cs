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

        public virtual DbSet<LoaiThucAn> LoaiThucAn { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ThongTinHoaDon> ThongTinHoaDon { get; set; }
        public virtual DbSet<ThucAn> ThucAn { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDetail> UserDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\THANHSANG;Initial Catalog=Order;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiThucAn>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.Property(e => e.MaLoai).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.TenLoaiThucAn).HasMaxLength(50);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.MaOrder)
                    .HasName("PK_Order");

                entity.Property(e => e.MaOrder).HasMaxLength(50);

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaNguoiDung).HasMaxLength(50);

                entity.Property(e => e.NgayDatMon).HasColumnType("date");

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_Order_User1");
            });

            modelBuilder.Entity<ThongTinHoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaOrder, e.MaThucAn });

                entity.Property(e => e.MaOrder).HasMaxLength(50);

                entity.Property(e => e.MaThucAn).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.HasOne(d => d.MaOrderNavigation)
                    .WithMany(p => p.ThongTinHoaDon)
                    .HasForeignKey(d => d.MaOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThongTinHoaDon_Order");

                entity.HasOne(d => d.MaThucAnNavigation)
                    .WithMany(p => p.ThongTinHoaDon)
                    .HasForeignKey(d => d.MaThucAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThongTinHoaDon_ThucAn");
            });

            modelBuilder.Entity<ThucAn>(entity =>
            {
                entity.HasKey(e => e.MaThucAn);

                entity.Property(e => e.MaThucAn).HasMaxLength(50);

                entity.Property(e => e.ChiChu).HasMaxLength(50);

                entity.Property(e => e.MaLoai).HasMaxLength(50);

                entity.Property(e => e.TenThucAn).HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.ThucAn)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_ThucAn_LoaiThucAn");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung)
                    .HasName("PK_Login");

                entity.Property(e => e.MaNguoiDung).HasMaxLength(50);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.MaLoai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SoDienThoai).HasMaxLength(50);

                entity.Property(e => e.TenNguoiDung)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.MaLoaiLogin)
                    .HasName("PK_LoaiLogin");

                entity.Property(e => e.MaLoaiLogin).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.MaNguoiDung).HasMaxLength(50);

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.UserDetail)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_LoaiLogin_Login");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
