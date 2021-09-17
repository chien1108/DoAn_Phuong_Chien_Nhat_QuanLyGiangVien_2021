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
    public class BoMonsController : ControllerBase
    {
        private readonly QuanLyGiangVienDbContext _context;

        public BoMonsController(QuanLyGiangVienDbContext context)
        {
            _context = context;
        }

        // GET: api/BoMons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoMon>>> GetBoMons()
        {
            return await _context.BoMons.ToListAsync();
        }

        // GET: api/BoMons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoMon>> GetBoMon(string id)
        {
            var boMon = await _context.BoMons.FindAsync(id);

            if (boMon == null)
            {
                return NotFound();
            }

            return boMon;
        }

        // PUT: api/BoMons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoMon(string id, BoMon boMon)
        {
            if (id != boMon.MaBoMon)
            {
                return BadRequest();
            }

            _context.Entry(boMon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoMonExists(id))
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

        // POST: api/BoMons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BoMon>> PostBoMon(BoMon boMon)
        {
            _context.BoMons.Add(boMon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BoMonExists(boMon.MaBoMon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBoMon", new { id = boMon.MaBoMon }, boMon);
        }

        // DELETE: api/BoMons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoMon(string id)
        {
            var boMon = await _context.BoMons.FindAsync(id);
            if (boMon == null)
            {
                return NotFound();
            }

            _context.BoMons.Remove(boMon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoMonExists(string id)
        {
            return _context.BoMons.Any(e => e.MaBoMon == id);
        }
    }
}
