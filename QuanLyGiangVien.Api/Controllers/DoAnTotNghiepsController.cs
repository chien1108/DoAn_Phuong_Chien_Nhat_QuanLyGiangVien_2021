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
    public class DoAnTotNghiepsController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public DoAnTotNghiepsController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/DoAnTotNghieps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoAnTotNghiep>>> GetDoAnTotNghieps()
        {
            return await _context.DoAnTotNghieps.ToListAsync();
        }

        // GET: api/DoAnTotNghieps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoAnTotNghiep>> GetDoAnTotNghiep(int id)
        {
            var doAnTotNghiep = await _context.DoAnTotNghieps.FindAsync(id);

            if (doAnTotNghiep == null)
            {
                return NotFound();
            }

            return doAnTotNghiep;
        }

        // PUT: api/DoAnTotNghieps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoAnTotNghiep(int id, DoAnTotNghiep doAnTotNghiep)
        {
            if (id != doAnTotNghiep.Ma)
            {
                return BadRequest();
            }

            _context.Entry(doAnTotNghiep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoAnTotNghiepExists(id))
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

        // POST: api/DoAnTotNghieps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoAnTotNghiep>> PostDoAnTotNghiep(DoAnTotNghiep doAnTotNghiep)
        {
            _context.DoAnTotNghieps.Add(doAnTotNghiep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoAnTotNghiep", new { id = doAnTotNghiep.Ma }, doAnTotNghiep);
        }

        // DELETE: api/DoAnTotNghieps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoAnTotNghiep(int id)
        {
            var doAnTotNghiep = await _context.DoAnTotNghieps.FindAsync(id);
            if (doAnTotNghiep == null)
            {
                return NotFound();
            }

            _context.DoAnTotNghieps.Remove(doAnTotNghiep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoAnTotNghiepExists(int id)
        {
            return _context.DoAnTotNghieps.Any(e => e.Ma == id);
        }
    }
}
