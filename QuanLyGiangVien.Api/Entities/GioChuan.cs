using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class GioChuan
    {
        public GioChuan()
        {
            GiaoViens = new HashSet<GiaoVien>();
        }

        public string MaChucDanh { get; set; }
        public string TenChucDanh { get; set; }
        public int? SoGioChuan { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<GiaoVien> GiaoViens { get; set; }
    }
}
