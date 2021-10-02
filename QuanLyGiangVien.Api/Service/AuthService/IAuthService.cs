using QuanLyGiangVien.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyGiangVien.Api.Service.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(TaiKhoan taikhoan, string password);
        Task<bool> UserExist(string TenDangNhap);
    }
}
