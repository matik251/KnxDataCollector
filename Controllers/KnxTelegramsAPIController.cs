using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnxDataCollector.Model;

namespace KnxDataCollector.Controllers
{
    [Route("api/KnxTelegrams")]
    [ApiController]
    public class KnxTelegramsAPIController : ControllerBase
    {
        private readonly KnxDBContext _context;

        public KnxTelegramsAPIController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: api/KnxTelegramsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnxTelegrams>>> GetKnxTelegrams()
        {
            return await _context.KnxTelegrams.ToListAsync();
        }

        // GET: api/KnxTelegramsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnxTelegrams>> GetKnxTelegrams(long id)
        {
            var knxTelegrams = await _context.KnxTelegrams.FindAsync(id);

            if (knxTelegrams == null)
            {
                return NotFound();
            }

            return knxTelegrams;
        }

        // PUT: api/KnxTelegramsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnxTelegrams(long id, KnxTelegrams knxTelegrams)
        {
            if (id != knxTelegrams.Tid)
            {
                return BadRequest();
            }

            _context.Entry(knxTelegrams).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnxTelegramsExists(id))
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

        // POST: api/KnxTelegramsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KnxTelegrams>> PostKnxTelegrams(KnxTelegrams knxTelegrams)
        {
            _context.KnxTelegrams.Add(knxTelegrams);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnxTelegrams", new { id = knxTelegrams.Tid }, knxTelegrams);
        }

        // DELETE: api/KnxTelegramsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnxTelegrams>> DeleteKnxTelegrams(long id)
        {
            var knxTelegrams = await _context.KnxTelegrams.FindAsync(id);
            if (knxTelegrams == null)
            {
                return NotFound();
            }

            _context.KnxTelegrams.Remove(knxTelegrams);
            await _context.SaveChangesAsync();

            return knxTelegrams;
        }

        private bool KnxTelegramsExists(long id)
        {
            return _context.KnxTelegrams.Any(e => e.Tid == id);
        }
    }
}
