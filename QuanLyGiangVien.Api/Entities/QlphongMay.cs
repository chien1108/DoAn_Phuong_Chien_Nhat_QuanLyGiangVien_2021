using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiangVien.Api.Entities
{
    public partial class QlphongMay
    {
        public string MaQl { get; set; }
        public string MaGv { get; set; }
        public int SoLuongPm { get; set; }
        public string NamHoc { get; set; }
        public string GhiChu { get; set; }

        public virtual GiaoVien MaGvNavigation { get; set; }
    }
}
