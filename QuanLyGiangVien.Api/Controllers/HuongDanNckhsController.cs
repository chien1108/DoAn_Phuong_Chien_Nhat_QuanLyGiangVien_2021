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
    public class HuongDanNckhsController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public HuongDanNckhsController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/HuongDanNckhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HuongDanNckh>>> GetHuongDanNckhs()
        {
            return await _context.HuongDanNckhs.ToListAsync();
        }

        // GET: api/HuongDanNckhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HuongDanNckh>> GetHuongDanNckh(string id)
        {
            var huongDanNckh = await _context.HuongDanNckhs.FindAsync(id);

            if (huongDanNckh == null)
            {
                return NotFound();
            }

            return huongDanNckh;
        }

        // PUT: api/HuongDanNckhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHuongDanNckh(string id, HuongDanNckh huongDanNckh)
        {
            if (id != huongDanNckh.Ma)
            {
                return BadRequest();
            }

            _context.Entry(huongDanNckh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HuongDanNckhExists(id))
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

        // POST: api/HuongDanNckhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HuongDanNckh>> PostHuongDanNckh(HuongDanNckh huongDanNckh)
        {
            _context.HuongDanNckhs.Add(huongDanNckh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HuongDanNckhExists(huongDanNckh.Ma))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHuongDanNckh", new { id = huongDanNckh.Ma }, huongDanNckh);
        }

        // DELETE: api/HuongDanNckhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHuongDanNckh(string id)
        {
            var huongDanNckh = await _context.HuongDanNckhs.FindAsync(id);
            if (huongDanNckh == null)
            {
                return NotFound();
            }

            _context.HuongDanNckhs.Remove(huongDanNckh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HuongDanNckhExists(string id)
        {
            return _context.HuongDanNckhs.Any(e => e.Ma == id);
        }
    }
}
