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
    public class GiangDaysController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public GiangDaysController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/GiangDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiangDay>>> GetGiangDays()
        {
            return await _context.GiangDays.ToListAsync();
        }

        // GET: api/GiangDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiangDay>> GetGiangDay(string id)
        {
            var giangDay = await _context.GiangDays.FindAsync(id);

            if (giangDay == null)
            {
                return NotFound();
            }

            return giangDay;
        }

        // PUT: api/GiangDays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiangDay(string id, GiangDay giangDay)
        {
            if (id != giangDay.MaGv)
            {
                return BadRequest();
            }

            _context.Entry(giangDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiangDayExists(id))
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

        // POST: api/GiangDays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiangDay>> PostGiangDay(GiangDay giangDay)
        {
            _context.GiangDays.Add(giangDay);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiangDayExists(giangDay.MaGv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGiangDay", new { id = giangDay.MaGv }, giangDay);
        }

        // DELETE: api/GiangDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiangDay(string id)
        {
            var giangDay = await _context.GiangDays.FindAsync(id);
            if (giangDay == null)
            {
                return NotFound();
            }

            _context.GiangDays.Remove(giangDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiangDayExists(string id)
        {
            return _context.GiangDays.Any(e => e.MaGv == id);
        }
    }
}
