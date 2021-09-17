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
    public class HeDaoTaosController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public HeDaoTaosController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/HeDaoTaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeDaoTao>>> GetHeDaoTaos()
        {
            return await _context.HeDaoTaos.ToListAsync();
        }

        // GET: api/HeDaoTaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeDaoTao>> GetHeDaoTao(string id)
        {
            var heDaoTao = await _context.HeDaoTaos.FindAsync(id);

            if (heDaoTao == null)
            {
                return NotFound();
            }

            return heDaoTao;
        }

        // PUT: api/HeDaoTaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeDaoTao(string id, HeDaoTao heDaoTao)
        {
            if (id != heDaoTao.MaHdt)
            {
                return BadRequest();
            }

            _context.Entry(heDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeDaoTaoExists(id))
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

        // POST: api/HeDaoTaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HeDaoTao>> PostHeDaoTao(HeDaoTao heDaoTao)
        {
            _context.HeDaoTaos.Add(heDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeDaoTaoExists(heDaoTao.MaHdt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHeDaoTao", new { id = heDaoTao.MaHdt }, heDaoTao);
        }

        // DELETE: api/HeDaoTaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeDaoTao(string id)
        {
            var heDaoTao = await _context.HeDaoTaos.FindAsync(id);
            if (heDaoTao == null)
            {
                return NotFound();
            }

            _context.HeDaoTaos.Remove(heDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeDaoTaoExists(string id)
        {
            return _context.HeDaoTaos.Any(e => e.MaHdt == id);
        }
    }
}
