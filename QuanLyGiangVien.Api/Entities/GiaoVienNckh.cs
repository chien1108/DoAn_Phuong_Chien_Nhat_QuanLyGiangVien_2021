using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class GiaoVienNckh
    {
        public string MaGv { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
        public string Cap { get; set; }
        public string NamThamGiaNc { get; set; }
        public string GhiChu { get; set; }

        public virtual GiaoVien MaGvNavigation { get; set; }
    }
}
