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

        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<LoaiThucAn> LoaiThucAn { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<ThongTin_HoaDon> ThongTinHoaDon { get; set; }
        public virtual DbSet<ThongTin_TaiKhoan> ThongTinTaiKhoan { get; set; }
        public virtual DbSet<ThucAn> ThucAn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\HANHLTM;Initial Catalog=Order;Persist Security Info=True;User ID=sa;Password=sen18081976;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon);

                entity.Property(e => e.MaHoaDon).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.MaNguoiMua)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaNguoiTao)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ThoiGianIn).HasColumnType("date");

                entity.Property(e => e.ThoiGianTao).HasColumnType("date");

                entity.HasOne(d => d.MaNguoiMuaNavigation)
                    .WithMany(p => p.HoaDonMaNguoiMuaNavigation)
                    .HasForeignKey(d => d.MaNguoiMua)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_ThongTin_TaiKhoan");

                entity.HasOne(d => d.MaNguoiTaoNavigation)
                    .WithMany(p => p.HoaDonMaNguoiTaoNavigation)
                    .HasForeignKey(d => d.MaNguoiTao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_ThongTin_TaiKhoan1");
            });

            modelBuilder.Entity<LoaiThucAn>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.Property(e => e.MaLoai).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.TenLoaiThucAn).HasMaxLength(50);
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTk);

                entity.Property(e => e.MaTk)
                    .HasColumnName("MaTK")
                    .HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.LoaiTk).HasColumnName("LoaiTK");

                entity.Property(e => e.MaTttk)
                    .HasColumnName("MaTTTK")
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenTk)
                    .IsRequired()
                    .HasColumnName("TenTK")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaTttkNavigation)
                    .WithMany(p => p.TaiKhoan)
                    .HasForeignKey(d => d.MaTttk)
                    .HasConstraintName("FK_TaiKhoan_ThongTin_TaiKhoan");
            });

            modelBuilder.Entity<ThongTin_HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaTthoaDon);

                entity.ToTable("ThongTin_HoaDon");

                entity.Property(e => e.MaTthoaDon)
                    .HasColumnName("MaTTHoaDon")
                    .HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.MaHoaDon)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaThucAn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.ThongTinHoaDon)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThongTin_HoaDon_HoaDon");

                entity.HasOne(d => d.MaThucAnNavigation)
                    .WithMany(p => p.ThongTinHoaDon)
                    .HasForeignKey(d => d.MaThucAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThongTin_HoaDon_ThucAn1");
            });

            modelBuilder.Entity<ThongTin_TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTttk)
                    .HasName("PK_ThongTin_TaiKhoan_1");

                entity.ToTable("ThongTin_TaiKhoan");

                entity.Property(e => e.MaTttk)
                    .HasColumnName("MaTTTK")
                    .HasMaxLength(50);

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.HovaTen)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ThucAn>(entity =>
            {
                entity.HasKey(e => e.MaThucAn)
                    .HasName("PK_ThucAn_1");

                entity.Property(e => e.MaThucAn).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.GiamGia).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaLoai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenThucAn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.ThucAn)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThucAn_LoaiThucAn1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
