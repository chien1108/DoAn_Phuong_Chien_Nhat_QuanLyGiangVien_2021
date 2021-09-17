using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class HocBsnangCao
    {
        public int Ma { get; set; }
        public string MaGv { get; set; }
        public string NamHoc { get; set; }
        public string GhiChu { get; set; }

        public virtual GiaoVien MaGvNavigation { get; set; }
    }
}
