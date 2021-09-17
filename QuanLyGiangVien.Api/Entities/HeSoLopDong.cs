using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class HeSoLopDong
    {
        public string MaHslopDong { get; set; }
        public int? Tu { get; set; }
        public int? Den { get; set; }
        public double HeSo { get; set; }
        public string HinhThucDay { get; set; }
    }
}
