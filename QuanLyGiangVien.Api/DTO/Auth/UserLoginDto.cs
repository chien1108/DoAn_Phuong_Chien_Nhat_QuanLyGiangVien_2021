using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyGiangVien.Api.DTO.Auth
{
    public class UserLoginDto
    {
        public string TenDangNhap { get; set; }
        public string Password { get; set; }
    }
}
