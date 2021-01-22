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
    [Route("api/DecodedTelegrams/[action]")]
    [ApiController]
    public class DecodedTelegramsController : ControllerBase
    {
        private readonly KnxDBContext _context;

        public DecodedTelegramsController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: api/DecodedTelegrams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DecodedTelegrams>>> GetDecodedTelegrams()
        {
            return await _context.DecodedTelegrams.ToListAsync();
        }

        // GET: api/DecodedTelegrams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DecodedTelegrams>> GetDecodedTelegrams(long id)
        {
            var decodedTelegrams = await _context.DecodedTelegrams.FindAsync(id);

            if (decodedTelegrams == null)
            {
                return NotFound();
            }

            return decodedTelegrams;
        }


        // GET: api/DecodedTelegrams/?decoded=false
        public async Task<ActionResult<IEnumerable<DecodedTelegrams>>> GetIncompleteTelegram(bool decoded)
        {
            var decodedTelegrams = await _context.DecodedTelegrams.ToListAsync();

            var incompleteList = decodedTelegrams.Where(p => p.DeviceName == null || p.DataFloat == null).ToList();

            if (decodedTelegrams == null)
            {
                return NotFound();
            }

            return incompleteList;
        }

        // PUT: api/DecodedTelegrams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDecodedTelegrams(long id, DecodedTelegrams decodedTelegrams)
        {
            if (id != decodedTelegrams.Tid)
            {
                return BadRequest();
            }

            _context.Entry(decodedTelegrams).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DecodedTelegramsExists(id))
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

        // POST: api/DecodedTelegrams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DecodedTelegrams>> PostDecodedTelegrams(DecodedTelegrams decodedTelegrams)
        {
            _context.DecodedTelegrams.Add(decodedTelegrams);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DecodedTelegramsExists(decodedTelegrams.Tid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDecodedTelegrams", new { id = decodedTelegrams.Tid }, decodedTelegrams);
        }

        // DELETE: api/DecodedTelegrams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DecodedTelegrams>> DeleteDecodedTelegrams(long id)
        {
            var decodedTelegrams = await _context.DecodedTelegrams.FindAsync(id);
            if (decodedTelegrams == null)
            {
                return NotFound();
            }

            _context.DecodedTelegrams.Remove(decodedTelegrams);
            await _context.SaveChangesAsync();

            return decodedTelegrams;
        }

        private bool DecodedTelegramsExists(long id)
        {
            return _context.DecodedTelegrams.Any(e => e.Tid == id);
        }
    }
}
