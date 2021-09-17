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
    public class LoaiMonsController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public LoaiMonsController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/LoaiMons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiMon>>> GetLoaiMons()
        {
            return await _context.LoaiMons.ToListAsync();
        }

        // GET: api/LoaiMons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiMon>> GetLoaiMon(string id)
        {
            var loaiMon = await _context.LoaiMons.FindAsync(id);

            if (loaiMon == null)
            {
                return NotFound();
            }

            return loaiMon;
        }

        // PUT: api/LoaiMons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiMon(string id, LoaiMon loaiMon)
        {
            if (id != loaiMon.MaLoai)
            {
                return BadRequest();
            }

            _context.Entry(loaiMon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiMonExists(id))
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

        // POST: api/LoaiMons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoaiMon>> PostLoaiMon(LoaiMon loaiMon)
        {
            _context.LoaiMons.Add(loaiMon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoaiMonExists(loaiMon.MaLoai))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoaiMon", new { id = loaiMon.MaLoai }, loaiMon);
        }

        // DELETE: api/LoaiMons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiMon(string id)
        {
            var loaiMon = await _context.LoaiMons.FindAsync(id);
            if (loaiMon == null)
            {
                return NotFound();
            }

            _context.LoaiMons.Remove(loaiMon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoaiMonExists(string id)
        {
            return _context.LoaiMons.Any(e => e.MaLoai == id);
        }
    }
}
