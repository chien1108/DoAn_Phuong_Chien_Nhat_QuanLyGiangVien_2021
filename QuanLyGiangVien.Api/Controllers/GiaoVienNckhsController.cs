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
    public class GiaoVienNckhsController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public GiaoVienNckhsController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/GiaoVienNckhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiaoVienNckh>>> GetGiaoVienNckhs()
        {
            return await _context.GiaoVienNckhs.ToListAsync();
        }

        // GET: api/GiaoVienNckhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiaoVienNckh>> GetGiaoVienNckh(string id)
        {
            var giaoVienNckh = await _context.GiaoVienNckhs.FindAsync(id);

            if (giaoVienNckh == null)
            {
                return NotFound();
            }

            return giaoVienNckh;
        }

        // PUT: api/GiaoVienNckhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiaoVienNckh(string id, GiaoVienNckh giaoVienNckh)
        {
            if (id != giaoVienNckh.MaDeTai)
            {
                return BadRequest();
            }

            _context.Entry(giaoVienNckh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaoVienNckhExists(id))
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

        // POST: api/GiaoVienNckhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiaoVienNckh>> PostGiaoVienNckh(GiaoVienNckh giaoVienNckh)
        {
            _context.GiaoVienNckhs.Add(giaoVienNckh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiaoVienNckhExists(giaoVienNckh.MaDeTai))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGiaoVienNckh", new { id = giaoVienNckh.MaDeTai }, giaoVienNckh);
        }

        // DELETE: api/GiaoVienNckhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiaoVienNckh(string id)
        {
            var giaoVienNckh = await _context.GiaoVienNckhs.FindAsync(id);
            if (giaoVienNckh == null)
            {
                return NotFound();
            }

            _context.GiaoVienNckhs.Remove(giaoVienNckh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiaoVienNckhExists(string id)
        {
            return _context.GiaoVienNckhs.Any(e => e.MaDeTai == id);
        }
    }
}
