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
    public class HeSoLopDongsController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public HeSoLopDongsController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/HeSoLopDongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeSoLopDong>>> GetHeSoLopDongs()
        {
            return await _context.HeSoLopDongs.ToListAsync();
        }

        // GET: api/HeSoLopDongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeSoLopDong>> GetHeSoLopDong(string id)
        {
            var heSoLopDong = await _context.HeSoLopDongs.FindAsync(id);

            if (heSoLopDong == null)
            {
                return NotFound();
            }

            return heSoLopDong;
        }

        // PUT: api/HeSoLopDongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeSoLopDong(string id, HeSoLopDong heSoLopDong)
        {
            if (id != heSoLopDong.MaHslopDong)
            {
                return BadRequest();
            }

            _context.Entry(heSoLopDong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeSoLopDongExists(id))
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

        // POST: api/HeSoLopDongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HeSoLopDong>> PostHeSoLopDong(HeSoLopDong heSoLopDong)
        {
            _context.HeSoLopDongs.Add(heSoLopDong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeSoLopDongExists(heSoLopDong.MaHslopDong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHeSoLopDong", new { id = heSoLopDong.MaHslopDong }, heSoLopDong);
        }

        // DELETE: api/HeSoLopDongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeSoLopDong(string id)
        {
            var heSoLopDong = await _context.HeSoLopDongs.FindAsync(id);
            if (heSoLopDong == null)
            {
                return NotFound();
            }

            _context.HeSoLopDongs.Remove(heSoLopDong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeSoLopDongExists(string id)
        {
            return _context.HeSoLopDongs.Any(e => e.MaHslopDong == id);
        }
    }
}
