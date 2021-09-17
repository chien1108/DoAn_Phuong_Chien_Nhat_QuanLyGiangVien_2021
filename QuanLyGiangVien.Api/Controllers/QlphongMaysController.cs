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
    public class QlphongMaysController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public QlphongMaysController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/QlphongMays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QlphongMay>>> GetQlphongMays()
        {
            return await _context.QlphongMays.ToListAsync();
        }

        // GET: api/QlphongMays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QlphongMay>> GetQlphongMay(string id)
        {
            var qlphongMay = await _context.QlphongMays.FindAsync(id);

            if (qlphongMay == null)
            {
                return NotFound();
            }

            return qlphongMay;
        }

        // PUT: api/QlphongMays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQlphongMay(string id, QlphongMay qlphongMay)
        {
            if (id != qlphongMay.MaQl)
            {
                return BadRequest();
            }

            _context.Entry(qlphongMay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QlphongMayExists(id))
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

        // POST: api/QlphongMays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QlphongMay>> PostQlphongMay(QlphongMay qlphongMay)
        {
            _context.QlphongMays.Add(qlphongMay);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QlphongMayExists(qlphongMay.MaQl))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQlphongMay", new { id = qlphongMay.MaQl }, qlphongMay);
        }

        // DELETE: api/QlphongMays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQlphongMay(string id)
        {
            var qlphongMay = await _context.QlphongMays.FindAsync(id);
            if (qlphongMay == null)
            {
                return NotFound();
            }

            _context.QlphongMays.Remove(qlphongMay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QlphongMayExists(string id)
        {
            return _context.QlphongMays.Any(e => e.MaQl == id);
        }
    }
}
