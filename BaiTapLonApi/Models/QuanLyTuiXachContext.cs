using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class QuanLyTuiXachContext : DbContext
    {
        public QuanLyTuiXachContext()
        {
        }

        public QuanLyTuiXachContext(DbContextOptions<QuanLyTuiXachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GiaBan> GiaBans { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiTuiXach> LoaiTuiXaches { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<TuiXach> TuiXaches { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=QuanLyTuiXach;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<BaiViet>(entity =>
            {
                entity.HasKey(e => e.MaBaiViet)
                    .HasName("PK__BaiViet__AEDD5647B659D885");

                entity.ToTable("BaiViet");

                entity.Property(e => e.NguoiDang).HasMaxLength(100);

                entity.Property(e => e.NoiDung).HasMaxLength(1000);

                entity.Property(e => e.ThoiGianDang).HasColumnType("datetime");

                entity.Property(e => e.TieuDe).HasMaxLength(100);
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.MaCtdonHang)
                    .HasName("PK__ChiTietD__B9F4AB6C4710A43F");

                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.MaCtdonHang).HasColumnName("MaCTDonHang");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ChiTietDo__MaDon__59063A47");

                entity.HasOne(d => d.MaTuiXachNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaTuiXach)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ChiTietDo__MaTui__59FA5E80");
            });

            modelBuilder.Entity<ChiTietGioHang>(entity =>
            {
                entity.HasKey(e => e.MaCtgioHang)
                    .HasName("PK__ChiTietG__CE448473EF1C6029");

                entity.ToTable("ChiTietGioHang");

                entity.Property(e => e.MaCtgioHang).HasColumnName("MaCTGioHang");

                entity.HasOne(d => d.MaGioHangNavigation)
                    .WithMany(p => p.ChiTietGioHangs)
                    .HasForeignKey(d => d.MaGioHang)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ChiTietGi__MaGio__5165187F");

                entity.HasOne(d => d.MaTuiXachNavigation)
                    .WithMany(p => p.ChiTietGioHangs)
                    .HasForeignKey(d => d.MaTuiXach)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ChiTietGi__MaTui__52593CB8");
            });

            modelBuilder.Entity<ChiTietHoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaCthoaDonNhap)
                    .HasName("PK__ChiTietH__A2AE208A7804E2DC");

                entity.ToTable("ChiTietHoaDonNhap");

                entity.Property(e => e.MaCthoaDonNhap).HasColumnName("MaCTHoaDonNhap");

                entity.Property(e => e.DonViTinh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HanSuDung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaHoaDonNhapNavigation)
                    .WithMany(p => p.ChiTietHoaDonNhaps)
                    .HasForeignKey(d => d.MaHoaDonNhap)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ChiTietHo__MaHoa__48CFD27E");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDonHang)
                    .HasName("PK__DonHang__129584ADADD21329");

                entity.ToTable("DonHang");

                entity.Property(e => e.DiaChiGiaoHang).HasMaxLength(1000);

                entity.Property(e => e.GhiChu).HasMaxLength(255);

                entity.Property(e => e.NgayDatHang).HasColumnType("datetime");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TrangThaiDonHang).HasMaxLength(255);

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DonHang__MaKhach__5535A963");

                entity.HasOne(d => d.MaNhaVienNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaNhaVien)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DonHang__MaNhaVi__5629CD9C");
            });

            modelBuilder.Entity<GiaBan>(entity =>
            {
                entity.HasKey(e => e.MaTuiXach)
                    .HasName("PK__GiaBan__6B41F52A747FEC80");

                entity.ToTable("GiaBan");

                entity.Property(e => e.MaTuiXach).ValueGeneratedNever();

                entity.Property(e => e.GiaBan1)
                    .HasColumnName("GiaBan")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NgayHetHieuLuc).HasColumnType("datetime");

                entity.Property(e => e.NgayHieuLuc).HasColumnType("datetime");

                entity.HasOne(d => d.MaTuiXachNavigation)
                    .WithOne(p => p.GiaBan)
                    .HasForeignKey<GiaBan>(d => d.MaTuiXach)
                    .HasConstraintName("FK__GiaBan__MaTuiXac__3D5E1FD2");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.MaGioHang)
                    .HasName("PK__GioHang__F5001DA337E5217E");

                entity.ToTable("GioHang");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NgayMua).HasMaxLength(255);

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__GioHang__MaKhach__4E88ABD4");
            });

            modelBuilder.Entity<HoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaHoaDonNhap)
                    .HasName("PK__HoaDonNh__448838B5F6980F37");

                entity.ToTable("HoaDonNhap");

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__HoaDonNha__MaNha__44FF419A");

                entity.HasOne(d => d.MaNhaVienNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaNhaVien)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__HoaDonNha__MaNha__45F365D3");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .HasName("PK__KhachHan__88D2F0E5BE863E82");

                entity.ToTable("KhachHang");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenKhachHang).HasMaxLength(255);
            });

            modelBuilder.Entity<LoaiTuiXach>(entity =>
            {
                entity.HasKey(e => e.MaLoaiTuiXach)
                    .HasName("PK__LoaiTuiX__AE53632B6FBE1662");

                entity.ToTable("LoaiTuiXach");

                entity.HasIndex(e => e.TenLoai, "UQ__LoaiTuiX__E29B10423D97F3B9")
                    .IsUnique();

                entity.Property(e => e.MoTa).HasMaxLength(1000);

                entity.Property(e => e.TenLoai).HasMaxLength(255);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCungCap)
                    .HasName("PK__NhaCungC__53DA9205476CE3AE");

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhaCungCap).HasMaxLength(255);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__77B2CA47C222A179");

                entity.ToTable("NhanVien");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhanVien).HasMaxLength(255);
            });

            modelBuilder.Entity<TuiXach>(entity =>
            {
                entity.HasKey(e => e.MaTuiXach)
                    .HasName("PK__TuiXach__6B41F52A2C99C58B");

                entity.ToTable("TuiXach");

                entity.Property(e => e.HinhAnh)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("(N'E//hinh-nen-giot-nuoc-dep-lung-linh_052336239.jpg')");

                entity.Property(e => e.MoTa).HasMaxLength(1000);

                entity.Property(e => e.TenTuiXach).HasMaxLength(255);

                entity.HasOne(d => d.MaLoaiTuiXachNavigation)
                    .WithMany(p => p.TuiXaches)
                    .HasForeignKey(d => d.MaLoaiTuiXach)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__TuiXach__MaLoaiT__38996AB5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__Users__3214CC9F991BA42F");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TenDangNhap)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
