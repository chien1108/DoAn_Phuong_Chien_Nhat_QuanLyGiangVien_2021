using System;

namespace QuanLyGiangVien.Models.Models
{
    public class TaiKhoanUpdateRequest
    {
        public string MaGv { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; }
        public DateTime? NgayTaoTk { get; set; }
    }
}
