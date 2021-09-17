using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class HuongDanNckh
    {
        public string MaGv { get; set; }
        public string Ma { get; set; }
        public int SoLuong { get; set; }
        public string Svnam { get; set; }
        public string NamHoc { get; set; }
        public string GhiChu { get; set; }

        public virtual GiaoVien MaGvNavigation { get; set; }
    }
}
