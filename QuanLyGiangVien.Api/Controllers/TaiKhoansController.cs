using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGiangVien.Api.Data;
using QuanLyGiangVien.Api.Entities;
using QuanLyGiangVien.Models.Models;

namespace QuanLyGiangVien.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoansController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public TaiKhoansController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/TaiKhoans
        [HttpGet]
        public async Task<IActionResult> GetListTaiKhoan()
        {
            var listFromDB = await _context.TaiKhoans.ToListAsync();
            var listTaiKhoanDto = listFromDB.Select(x => new TaiKhoanDto()
            {
                TenDangNhap = x.TenDangNhap,
                MatKhau = x.MatKhau,
                MaGv = x.MaGv,
                Quyen = x.Quyen,
                NgayTaoTk = x.NgayTaoTk,
                //TenGV = x.MaGvNavigation.TenGv != null ? x.MaGvNavigation.TenGv : "N/A"
            }) ;

            return Ok(listTaiKhoanDto);
        }

        // GET: api/TaiKhoans/5
        [HttpGet("{tenTaiKhoan}")]
        public async Task<IActionResult> GetTaiKhoanByUser(string tenTaiKhoan)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(tenTaiKhoan);
            var listTaiKhoanDto = new TaiKhoanDto() 
            {
                MaGv = taiKhoan.MaGv,
                TenDangNhap = taiKhoan.TenDangNhap,
                MatKhau = taiKhoan.MatKhau,
                NgayTaoTk = taiKhoan.NgayTaoTk,
                Quyen = taiKhoan.Quyen,
                //TenGV = taiKhoan.MaGvNavigation.TenGv
            };
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return Ok(listTaiKhoanDto);
        }

        // PUT: api/TaiKhoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{tenTaiKhoan}")]
        public async Task<IActionResult> UpdateTaiKhoan(string tenTaiKhoan, TaiKhoanUpdateRequest taiKhoan)
        {
            if (tenTaiKhoan != taiKhoan.TenDangNhap)
            {
                return BadRequest();
            }

            _context.Entry(taiKhoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanExists(tenTaiKhoan))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/TaiKhoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaiKhoan>> CreateTaiKhoan(TaiKhoan taiKhoan)
        {
            _context.TaiKhoans.Add(taiKhoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaiKhoanExists(taiKhoan.TenDangNhap))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTaiKhoan", new { tenTaiKhoan = taiKhoan.TenDangNhap }, taiKhoan);
        }

        // DELETE: api/TaiKhoans/5
        [HttpDelete("{tenTaiKhoan}")]
        public async Task<IActionResult> DeleteTaiKhoan(string tenTaiKhoan)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(tenTaiKhoan);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            _context.TaiKhoans.Remove(taiKhoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaiKhoanExists(string tenTaiKhoan)
        {
            return _context.TaiKhoans.Any(e => e.TenDangNhap == tenTaiKhoan);
        }
    }
}
