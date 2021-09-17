using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            GiangDays = new HashSet<GiangDay>();
        }

        public string MaHeDt { get; set; }
        public string MaLoai { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int SoTiet { get; set; }
        public string GhiChu { get; set; }

        public virtual HeDaoTao MaHeDtNavigation { get; set; }
        public virtual LoaiMon MaLoaiNavigation { get; set; }
        public virtual ICollection<GiangDay> GiangDays { get; set; }
    }
}
