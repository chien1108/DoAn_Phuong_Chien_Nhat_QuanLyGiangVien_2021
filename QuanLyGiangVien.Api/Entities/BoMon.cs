using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class BoMon
    {
        public BoMon()
        {
            GiaoViens = new HashSet<GiaoVien>();
        }

        public string MaBoMon { get; set; }
        public string TenBoMon { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<GiaoVien> GiaoViens { get; set; }
    }
}
