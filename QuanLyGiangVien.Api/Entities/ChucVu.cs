using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            GiaoViens = new HashSet<GiaoVien>();
        }

        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public int? PhanTramDuocGiam { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<GiaoVien> GiaoViens { get; set; }
    }
}
