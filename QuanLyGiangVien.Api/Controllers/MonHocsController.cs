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
    public class MonHocsController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public MonHocsController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/MonHocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonHoc>>> GetMonHocs()
        {
            return await _context.MonHocs.ToListAsync();
        }

        // GET: api/MonHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonHoc>> GetMonHoc(string id)
        {
            var monHoc = await _context.MonHocs.FindAsync(id);

            if (monHoc == null)
            {
                return NotFound();
            }

            return monHoc;
        }

        // PUT: api/MonHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonHoc(string id, MonHoc monHoc)
        {
            if (id != monHoc.MaMon)
            {
                return BadRequest();
            }

            _context.Entry(monHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonHocExists(id))
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

        // POST: api/MonHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonHoc>> PostMonHoc(MonHoc monHoc)
        {
            _context.MonHocs.Add(monHoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MonHocExists(monHoc.MaMon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMonHoc", new { id = monHoc.MaMon }, monHoc);
        }

        // DELETE: api/MonHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonHoc(string id)
        {
            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }

            _context.MonHocs.Remove(monHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonHocExists(string id)
        {
            return _context.MonHocs.Any(e => e.MaMon == id);
        }
    }
}
