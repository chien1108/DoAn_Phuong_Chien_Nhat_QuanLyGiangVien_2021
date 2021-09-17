using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class HeDaoTao
    {
        public HeDaoTao()
        {
            Lops = new HashSet<Lop>();
            MonHocs = new HashSet<MonHoc>();
        }

        public string MaHdt { get; set; }
        public string TenHeDt { get; set; }
        public int? SoBuoiTren1DvhocTrinh { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<Lop> Lops { get; set; }
        public virtual ICollection<MonHoc> MonHocs { get; set; }
    }
}
