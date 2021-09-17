using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class Lop
    {
        public Lop()
        {
            DoAnTotNghieps = new HashSet<DoAnTotNghiep>();
            GiangDays = new HashSet<GiangDay>();
        }

        public string MaHeDt { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int? SiSo { get; set; }
        public string HinhThucDt { get; set; }
        public string GhiChu { get; set; }

        public virtual HeDaoTao MaHeDtNavigation { get; set; }
        public virtual ICollection<DoAnTotNghiep> DoAnTotNghieps { get; set; }
        public virtual ICollection<GiangDay> GiangDays { get; set; }
    }
}
