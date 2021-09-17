using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class GiangDay
    {
        public string MaGv { get; set; }
        public string MaLop { get; set; }
        public string MaMon { get; set; }
        public int? SoSv { get; set; }
        public string NamHoc { get; set; }
        public string GhiChu { get; set; }

        public virtual GiaoVien MaGvNavigation { get; set; }
        public virtual Lop MaLopNavigation { get; set; }
        public virtual MonHoc MaMonNavigation { get; set; }
    }
}
