using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuanLyGiangVien.Api.Entities;

#nullable disable

namespace QuanLyGiangVien.Api.Data
{
    public partial class QuanLyGiangVienDbContext : DbContext
    {
        public QuanLyGiangVienDbContext()
        {
        }

        public QuanLyGiangVienDbContext(DbContextOptions<QuanLyGiangVienDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BoMon> BoMons { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DoAnTotNghiep> DoAnTotNghieps { get; set; }
        public virtual DbSet<GiangDay> GiangDays { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<GiaoVienNckh> GiaoVienNckhs { get; set; }
        public virtual DbSet<GioChuan> GioChuans { get; set; }
        public virtual DbSet<HeDaoTao> HeDaoTaos { get; set; }
        public virtual DbSet<HeSoLopDong> HeSoLopDongs { get; set; }
        public virtual DbSet<HocBsnangCao> HocBsnangCaos { get; set; }
        public virtual DbSet<HuongDanNckh> HuongDanNckhs { get; set; }
        public virtual DbSet<LoaiMon> LoaiMons { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<QlphongMay> QlphongMays { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyGiangVien;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BoMon>(entity =>
            {
                entity.HasKey(e => e.MaBoMon);

                entity.ToTable("BoMon");

                entity.Property(e => e.MaBoMon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.TenBoMon)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaChucVu);

                entity.ToTable("ChucVu");

                entity.Property(e => e.MaChucVu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.TenChucVu).HasMaxLength(200);
            });

            modelBuilder.Entity<DoAnTotNghiep>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_DoAnTotNghiep_1");

                entity.ToTable("DoAnTotNghiep");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.MaGv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaLop)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoDoAnPbien).HasColumnName("SoDoAnPBien");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.DoAnTotNghieps)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK_DoAnTotNghiep_GiaoVien");

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.DoAnTotNghieps)
                    .HasForeignKey(d => d.MaLop)
                    .HasConstraintName("FK_DoAnTotNghiep_Lop");
            });

            modelBuilder.Entity<GiangDay>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaLop, e.MaMon });

                entity.ToTable("GiangDay");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaMon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoSv).HasColumnName("SoSV");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.GiangDays)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK_GiangDay_GiaoVien");

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.GiangDays)
                    .HasForeignKey(d => d.MaLop)
                    .HasConstraintName("FK_GiangDay_Lop");

                entity.HasOne(d => d.MaMonNavigation)
                    .WithMany(p => p.GiangDays)
                    .HasForeignKey(d => d.MaMon)
                    .HasConstraintName("FK_GiangDay_MonHoc1");
            });

            modelBuilder.Entity<GiaoVien>(entity =>
            {
                entity.HasKey(e => e.MaGv);

                entity.ToTable("GiaoVien");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.Anh)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.GioiTinh).HasMaxLength(20);

                entity.Property(e => e.MaBoMon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaChucDanh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaChucVu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamVaoLam)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.SoCmtnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SoCMTND");

                entity.Property(e => e.TenGv)
                    .HasMaxLength(100)
                    .HasColumnName("TenGV");

                entity.Property(e => e.TrinhDoHocVan).HasMaxLength(100);

                entity.HasOne(d => d.MaBoMonNavigation)
                    .WithMany(p => p.GiaoViens)
                    .HasForeignKey(d => d.MaBoMon)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_GiaoVien_BoMon");

                entity.HasOne(d => d.MaChucDanhNavigation)
                    .WithMany(p => p.GiaoViens)
                    .HasForeignKey(d => d.MaChucDanh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_GiaoVien_GioChuan");

                entity.HasOne(d => d.MaChucVuNavigation)
                    .WithMany(p => p.GiaoViens)
                    .HasForeignKey(d => d.MaChucVu)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_GiaoVien_ChucVu");
            });

            modelBuilder.Entity<GiaoVienNckh>(entity =>
            {
                entity.HasKey(e => e.MaDeTai);

                entity.ToTable("GiaoVienNCKH");

                entity.Property(e => e.MaDeTai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cap).HasMaxLength(100);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.MaGv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.NamThamGiaNc)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NamThamGiaNC");

                entity.Property(e => e.TenDeTai).HasMaxLength(200);

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.GiaoVienNckhs)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK_GiaoVienNCKH_GiaoVien");
            });

            modelBuilder.Entity<GioChuan>(entity =>
            {
                entity.HasKey(e => e.MaChucDanh);

                entity.ToTable("GioChuan");

                entity.Property(e => e.MaChucDanh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.TenChucDanh).HasMaxLength(100);
            });

            modelBuilder.Entity<HeDaoTao>(entity =>
            {
                entity.HasKey(e => e.MaHdt);

                entity.ToTable("HeDaoTao");

                entity.Property(e => e.MaHdt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaHDT");

                entity.Property(e => e.GhiChu).HasMaxLength(150);

                entity.Property(e => e.SoBuoiTren1DvhocTrinh).HasColumnName("SoBuoiTren1DVHocTrinh");

                entity.Property(e => e.TenHeDt)
                    .HasMaxLength(100)
                    .HasColumnName("TenHeDT");
            });

            modelBuilder.Entity<HeSoLopDong>(entity =>
            {
                entity.HasKey(e => e.MaHslopDong);

                entity.ToTable("HeSoLopDong");

                entity.Property(e => e.MaHslopDong)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaHSLopDong");

                entity.Property(e => e.HinhThucDay).HasMaxLength(100);
            });

            modelBuilder.Entity<HocBsnangCao>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_HocNangCao");

                entity.ToTable("HocBSNangCao");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.MaGv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.HocBsnangCaos)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK_HocNangCao_GiaoVien");
            });

            modelBuilder.Entity<HuongDanNckh>(entity =>
            {
                entity.HasKey(e => e.Ma);

                entity.ToTable("HuongDanNCKH");

                entity.Property(e => e.Ma)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.MaGv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Svnam)
                    .HasMaxLength(50)
                    .HasColumnName("SVNam");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.HuongDanNckhs)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK_HuongDanNCKH_GiaoVien");
            });

            modelBuilder.Entity<LoaiMon>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.ToTable("LoaiMon");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.TenLoai).HasMaxLength(200);
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop);

                entity.ToTable("Lop");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.HinhThucDt)
                    .HasMaxLength(100)
                    .HasColumnName("HinhThucDT");

                entity.Property(e => e.MaHeDt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaHeDT");

                entity.Property(e => e.TenLop).HasMaxLength(100);

                entity.HasOne(d => d.MaHeDtNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaHeDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lop_HeDaoTao");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMon);

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.MaHeDt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaHeDT");

                entity.Property(e => e.MaLoai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenMon).HasMaxLength(200);

                entity.HasOne(d => d.MaHeDtNavigation)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.MaHeDt)
                    .HasConstraintName("FK_MonHoc_HeDaoTao");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_MonHoc_LoaiMon");
            });

            modelBuilder.Entity<QlphongMay>(entity =>
            {
                entity.HasKey(e => e.MaQl);

                entity.ToTable("QLPhongMay");

                entity.Property(e => e.MaQl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaQL");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.MaGv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoLuongPm).HasColumnName("SoLuongPM");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.QlphongMays)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK_QLPhongMay_GiaoVien1");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TenDangNhap);

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.TenDangNhap)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaGv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTaoTk)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayTaoTK");

                entity.Property(e => e.Quyen).HasMaxLength(100);

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK_TaiKhoan_GiaoVien");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
