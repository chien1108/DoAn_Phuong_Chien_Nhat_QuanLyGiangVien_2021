using QuanLyGiangVien.Api.DTO.Auth;
using QuanLyGiangVien.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyGiangVien.Api.Service.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Register(TaiKhoan taikhoan, string password);
        Task<bool> UserExist(string TenDangNhap);
        Task<ServiceResponse<string>> Login(string tenDangNhap, string password);
    }
}
