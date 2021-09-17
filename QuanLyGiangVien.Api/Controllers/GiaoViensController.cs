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
    public class GiaoViensController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public GiaoViensController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/GiaoViens
        [HttpGet]
        public async Task<IEnumerable<GiaoVienRequest>> GetGiaoViens()
        {
            //return await _context.GiaoViens.ToListAsync();
            var listFromDB = await _context.GiaoViens.ToListAsync();
            var listRequest = listFromDB.Select(x => new GiaoVienRequest()
            {
                MaGv = x.MaGv,
                TenGv = x.TenGv,
                GioiTinh = x.GioiTinh,
                NgaySinh = x.NgaySinh,
                SoCmtnd = x.SoCmtnd,
                Anh = x.Anh,
                TrinhDoHocVan = x.TrinhDoHocVan,
                MaChucDanh = x.MaChucDanh,
                MaChucVu = x.MaChucVu,
                NamVaoLam = x.NamVaoLam,
                Email = x.Email,
                DiaChi = x.DiaChi,
                DienThoai = x.DienThoai,
                GhiChu = x.GhiChu,
                MaBoMon = x.MaBoMon
            });
            return listRequest;
        }

        // GET: api/GiaoViens/5
        [HttpGet("{maGV}")]
        public async Task<ActionResult<GiaoVienRequest>> GetGiaoVien(string maGV)
        {
            var giaoVien = await _context.GiaoViens.FindAsync(maGV);

            if (giaoVien == null)
            {
                return NotFound();
            }

            return Ok(new GiaoVienRequest() 
            {
                MaGv = giaoVien.MaGv,
                TenGv = giaoVien.TenGv,
                GioiTinh = giaoVien.GioiTinh,
                NgaySinh = giaoVien.NgaySinh,
                SoCmtnd = giaoVien.SoCmtnd,
                Anh = giaoVien.Anh,
                TrinhDoHocVan = giaoVien.TrinhDoHocVan,
                MaChucDanh = giaoVien.MaChucDanh,
                MaChucVu = giaoVien.MaChucVu,
                NamVaoLam = giaoVien.NamVaoLam,
                Email = giaoVien.Email,
                DiaChi = giaoVien.DiaChi,
                DienThoai = giaoVien.DienThoai,
                GhiChu = giaoVien.GhiChu,
                MaBoMon = giaoVien.MaBoMon
            });
        }

        // PUT: api/GiaoViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maGV}")]
        public async Task<IActionResult> PutGiaoVien(string maGV, GiaoVien giaoVien)
        {
            if (maGV != giaoVien.MaGv)
            {
                return BadRequest();
            }

            _context.Entry(giaoVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaoVienExists(maGV))
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

        // POST: api/GiaoViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiaoVien>> PostGiaoVien(GiaoVien giaoVien)
        {
            _context.GiaoViens.Add(giaoVien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiaoVienExists(giaoVien.MaGv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGiaoVien", new { maGV = giaoVien.MaGv }, giaoVien);
        }

        // DELETE: api/GiaoViens/5
        [HttpDelete("{maGV}")]
        public async Task<IActionResult> DeleteGiaoVien(string maGV)
        {
            var giaoVien = await _context.GiaoViens.FindAsync(maGV);
            if (giaoVien == null)
            {
                return NotFound();
            }

            _context.GiaoViens.Remove(giaoVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiaoVienExists(string maGV)
        {
            return _context.GiaoViens.Any(e => e.MaGv == maGV);
        }
    }
}
