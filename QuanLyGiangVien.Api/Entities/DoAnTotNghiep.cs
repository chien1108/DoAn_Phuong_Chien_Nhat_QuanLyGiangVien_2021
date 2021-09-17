using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class DoAnTotNghiep
    {
        public string MaGv { get; set; }
        public string MaLop { get; set; }
        public int? SoDeTai { get; set; }
        public int? SoDoAnPbien { get; set; }
        public int? SoBuoiChamBai { get; set; }
        public string NamHoc { get; set; }
        public string GhiChu { get; set; }
        public int Ma { get; set; }

        public virtual GiaoVien MaGvNavigation { get; set; }
        public virtual Lop MaLopNavigation { get; set; }
    }
}
