using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGiangVien.Api.Data;
using QuanLyGiangVien.Api.DTO.Auth;
using QuanLyGiangVien.Api.Service.AuthService;
using QuanLyGiangVien.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyGiangVien.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;
        private readonly IAuthService _authService;

        public LoginsController(QuanLyGiangVienDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        // GET: api/TaiKhoans
        [HttpGet]
        public async Task<IEnumerable<LoginRequest>> GetListTaiKhoan()
        {
            var listFromDB = await _context.TaiKhoans.ToListAsync();
            var listTaiKhoanDto = listFromDB.Select(x => new LoginRequest()
            {
                TenDangNhap = x.TenDangNhap,
                MatKhau = x.PasswordHash,
                MaGv = x.MaGv,
                Quyen = x.Quyen
            });

            return listTaiKhoanDto;
        }

        //[HttpGet("{tenTaiKhoan}")]
        //public async Task<ActionResult<LoginRequest>> GetTaiKhoanByUser(string tenTaiKhoan)
        //{
        //    var taiKhoan = await _context.TaiKhoans.FindAsync(tenTaiKhoan);
        //    if (taiKhoan == null)
        //    {
        //        return BadRequest(tenTaiKhoan);
        //    }
        //    var taiKhoanDto = new LoginRequest()
        //    {
        //        MaGv = taiKhoan.MaGv,
        //        TenDangNhap = taiKhoan.TenDangNhap,
        //        MatKhau = taiKhoan.,
        //        Quyen = taiKhoan.Quyen,
        //    };
            

        //    return taiKhoanDto;
        //}

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            return Ok(await _authService.Login(userLogin.TenDangNhap, userLogin.Password)); 
        }
    }
}
