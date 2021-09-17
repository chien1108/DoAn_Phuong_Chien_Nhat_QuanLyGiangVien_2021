using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiangVien.Models.Models
{
    public class GiaoVienUpdateRequest
    {
        public string TenGv { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoCmtnd { get; set; }
        public string Anh { get; set; }
        public string TrinhDoHocVan { get; set; }
        public string NamVaoLam { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string GhiChu { get; set; }
    }
}
