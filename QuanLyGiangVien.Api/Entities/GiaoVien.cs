using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class GiaoVien
    {
        public GiaoVien()
        {
            DoAnTotNghieps = new HashSet<DoAnTotNghiep>();
            GiangDays = new HashSet<GiangDay>();
            GiaoVienNckhs = new HashSet<GiaoVienNckh>();
            HocBsnangCaos = new HashSet<HocBsnangCao>();
            HuongDanNckhs = new HashSet<HuongDanNckh>();
            QlphongMays = new HashSet<QlphongMay>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public string MaGv { get; set; }
        public string TenGv { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoCmtnd { get; set; }
        public string Anh { get; set; }
        public string TrinhDoHocVan { get; set; }
        public string MaChucDanh { get; set; }
        public string MaChucVu { get; set; }
        public string NamVaoLam { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string GhiChu { get; set; }
        public string MaBoMon { get; set; }

        public virtual BoMon MaBoMonNavigation { get; set; }
        public virtual GioChuan MaChucDanhNavigation { get; set; }
        public virtual ChucVu MaChucVuNavigation { get; set; }
        public virtual ICollection<DoAnTotNghiep> DoAnTotNghieps { get; set; }
        public virtual ICollection<GiangDay> GiangDays { get; set; }
        public virtual ICollection<GiaoVienNckh> GiaoVienNckhs { get; set; }
        public virtual ICollection<HocBsnangCao> HocBsnangCaos { get; set; }
        public virtual ICollection<HuongDanNckh> HuongDanNckhs { get; set; }
        public virtual ICollection<QlphongMay> QlphongMays { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
