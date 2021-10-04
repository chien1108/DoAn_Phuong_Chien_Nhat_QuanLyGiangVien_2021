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
using Microsoft.EntityFrameworkCore;
using QuanLyGiangVien.Api.DTO.Auth;

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
        public async Task<ServiceResponse<string>> Register(TaiKhoan taikhoan, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            if (await UserExist(taikhoan.TenDangNhap))
            {
                response.Success = false;
                response.Message = "Da ton tai ten dang nhap";
                return response;
            }

            CreateHashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);

            taikhoan.PasswordHash = passwordHash;
            taikhoan.PasswordSalt = passwordSalt;

            _context.TaiKhoans.Add(taikhoan);
            await _context.SaveChangesAsync();

            response.Data = taikhoan.MaGv;
            return response;
        }

        public async Task<bool> UserExist(string TenDangNhap) => await _context.TaiKhoans.AnyAsync(x => x.TenDangNhap.ToLower().Equals(TenDangNhap.ToLower()));

        public async Task<ServiceResponse<string>> Login(string tenDangNhap, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.TaiKhoans.FirstOrDefaultAsync(x => x.TenDangNhap.ToLower().Equals(tenDangNhap.ToLower()));

            if(user != null)
            {
                if(!CheckPassword(password, user.PasswordSalt, user.PasswordHash))
                {
                    response.Success = false;
                    response.Message = "tai khoan hoac mat khau da sai!";
                    return response;
                }
                response.Data = GenerateToken(user);
                return response;
            }   
            else
            {
                response.Success = false;
                response.Message = "tai khoan hoac mat khau da sai!";
                return response;
            }    
        }

        private bool CheckPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            var hmac = new HMACSHA512(passwordSalt);
            var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for(int i = 0; i < computed.Length; i++)
            {
                if(computed[i] != passwordHash[i])
                {
                    return false;
                }    
            }
            return true;
        }

        private string GenerateToken(TaiKhoan taiKhoan)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, taiKhoan.MaGv),
                new Claim(ClaimTypes.Name, taiKhoan.TenDangNhap),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private void CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hcma = new HMACSHA512();
            passwordSalt = hcma.Key;
            passwordHash = hcma.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
