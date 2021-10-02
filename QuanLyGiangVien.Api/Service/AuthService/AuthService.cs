using Microsoft.Extensions.Configuration;
using QuanLyGiangVien.Api.Data;
using QuanLyGiangVien.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace QuanLyGiangVien.Api.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly QuanLyGiangVienDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IHttpContextAccessor httpAccessor, QuanLyGiangVienDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _httpAccessor = httpAccessor;
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<int>> Register(TaiKhoan taikhoan, string password)
        {
            //ServiceResponse<int> response = new ServiceResponse<int>();
            //if(await UserExist(taikhoan.TenDangNhap))
            //{
            //    response.Success = false;
            //    response.Message = "Da ton tai ten dang nhap";
            //    return response;
            //}

            //CreateHashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);

            throw new NotImplementedException();

        }

        private void CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hcma = new HMACSHA512();
            passwordSalt = hcma.Key;
            passwordHash = hcma.ComputeHash(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
        }

        public async Task<bool> UserExist(string TenDangNhap)
        {
            throw new NotImplementedException();
        }
    }
}
