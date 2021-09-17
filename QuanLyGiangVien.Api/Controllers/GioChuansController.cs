using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGiangVien.Api.Data;
using QuanLyGiangVien.Api.Entities;

namespace QuanLyGiangVien.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioChuansController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public GioChuansController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/GioChuans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GioChuan>>> GetGioChuans()
        {
            return await _context.GioChuans.ToListAsync();
        }

        // GET: api/GioChuans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GioChuan>> GetGioChuan(string id)
        {
            var gioChuan = await _context.GioChuans.FindAsync(id);

            if (gioChuan == null)
            {
                return NotFound();
            }

            return gioChuan;
        }

        // PUT: api/GioChuans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGioChuan(string id, GioChuan gioChuan)
        {
            if (id != gioChuan.MaChucDanh)
            {
                return BadRequest();
            }

            _context.Entry(gioChuan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GioChuanExists(id))
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

        // POST: api/GioChuans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GioChuan>> PostGioChuan(GioChuan gioChuan)
        {
            _context.GioChuans.Add(gioChuan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GioChuanExists(gioChuan.MaChucDanh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGioChuan", new { id = gioChuan.MaChucDanh }, gioChuan);
        }

        // DELETE: api/GioChuans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGioChuan(string id)
        {
            var gioChuan = await _context.GioChuans.FindAsync(id);
            if (gioChuan == null)
            {
                return NotFound();
            }

            _context.GioChuans.Remove(gioChuan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GioChuanExists(string id)
        {
            return _context.GioChuans.Any(e => e.MaChucDanh == id);
        }
    }
}
