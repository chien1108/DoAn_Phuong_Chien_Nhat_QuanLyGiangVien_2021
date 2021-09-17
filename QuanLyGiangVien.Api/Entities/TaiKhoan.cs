using QuanLyGiangVien.Models.Enums;
using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class TaiKhoan
    {
        public string MaGv { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; }
        public DateTime? NgayTaoTk { get; set; }

        public virtual GiaoVien MaGvNavigation { get; set; }
    }
}
