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
    public class HocBsnangCaosController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public HocBsnangCaosController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/HocBsnangCaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HocBsnangCao>>> GetHocBsnangCaos()
        {
            return await _context.HocBsnangCaos.ToListAsync();
        }

        // GET: api/HocBsnangCaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HocBsnangCao>> GetHocBsnangCao(int id)
        {
            var hocBsnangCao = await _context.HocBsnangCaos.FindAsync(id);

            if (hocBsnangCao == null)
            {
                return NotFound();
            }

            return hocBsnangCao;
        }

        // PUT: api/HocBsnangCaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocBsnangCao(int id, HocBsnangCao hocBsnangCao)
        {
            if (id != hocBsnangCao.Ma)
            {
                return BadRequest();
            }

            _context.Entry(hocBsnangCao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocBsnangCaoExists(id))
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

        // POST: api/HocBsnangCaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HocBsnangCao>> PostHocBsnangCao(HocBsnangCao hocBsnangCao)
        {
            _context.HocBsnangCaos.Add(hocBsnangCao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHocBsnangCao", new { id = hocBsnangCao.Ma }, hocBsnangCao);
        }

        // DELETE: api/HocBsnangCaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocBsnangCao(int id)
        {
            var hocBsnangCao = await _context.HocBsnangCaos.FindAsync(id);
            if (hocBsnangCao == null)
            {
                return NotFound();
            }

            _context.HocBsnangCaos.Remove(hocBsnangCao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HocBsnangCaoExists(int id)
        {
            return _context.HocBsnangCaos.Any(e => e.Ma == id);
        }
    }
}
