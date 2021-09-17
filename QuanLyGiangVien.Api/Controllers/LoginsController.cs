using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGiangVien.Api.Data;
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

        public LoginsController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }
        // GET: api/TaiKhoans
        [HttpGet]
        public async Task<IEnumerable<LoginRequest>> GetListTaiKhoan()
        {
            var listFromDB = await _context.TaiKhoans.ToListAsync();
            var listTaiKhoanDto = listFromDB.Select(x => new LoginRequest()
            {
                TenDangNhap = x.TenDangNhap,
                MatKhau = x.MatKhau,
                MaGv = x.MaGv,
                Quyen = x.Quyen
            });

            return listTaiKhoanDto;
        }

        [HttpGet("{tenTaiKhoan}")]
        public async Task<ActionResult<LoginRequest>> GetTaiKhoanByUser(string tenTaiKhoan)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(tenTaiKhoan);
            if (taiKhoan == null)
            {
                return BadRequest(tenTaiKhoan);
            }
            var taiKhoanDto = new LoginRequest()
            {
                MaGv = taiKhoan.MaGv,
                TenDangNhap = taiKhoan.TenDangNhap,
                MatKhau = taiKhoan.MatKhau,
                Quyen = taiKhoan.Quyen,
            };
            

            return taiKhoanDto;
        }
    }
}
