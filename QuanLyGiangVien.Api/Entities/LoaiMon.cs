using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class LoaiMon
    {
        public LoaiMon()
        {
            MonHocs = new HashSet<MonHoc>();
        }

        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<MonHoc> MonHocs { get; set; }
    }
}
