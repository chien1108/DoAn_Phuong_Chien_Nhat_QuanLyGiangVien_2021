using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiangVien.Models.Models
{
    public class TaiKhoanDto
    {
        public string MaGv { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; }
        public DateTime? NgayTaoTk { get; set; }
        public string? TenGV { get; set; }
    }
}
