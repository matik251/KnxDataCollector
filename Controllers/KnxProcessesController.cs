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
    [Route("api/[controller]")]
    [ApiController]
    public class KnxProcessesController : ControllerBase
    {
        private readonly KnxDBContext _context;

        public KnxProcessesController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: api/KnxProcesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnxProcesses>>> GetKnxProcesses()
        {
            return await _context.KnxProcesses.ToListAsync();
        }

        // GET: api/KnxProcesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnxProcesses>> GetKnxProcesses(int id)
        {
            var knxProcesses = await _context.KnxProcesses.FindAsync(id);

            if (knxProcesses == null)
            {
                return NotFound();
            }

            return knxProcesses;
        }

        // PUT: api/KnxProcesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnxProcesses(long id, KnxProcesses knxProcesses)
        {
            if (id != knxProcesses.Pid)
            {
                return BadRequest();
            }

            _context.Entry(knxProcesses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnxProcessesExists(id))
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

        // POST: api/KnxProcesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KnxProcesses>> PostKnxProcesses(KnxProcesses knxProcesses)
        {
            _context.KnxProcesses.Add(knxProcesses);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KnxProcessesExists(knxProcesses.Pid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKnxProcesses", new { id = knxProcesses.Pid }, knxProcesses);
        }

        // DELETE: api/KnxProcesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnxProcesses>> DeleteKnxProcesses(long id)
        {
            var knxProcesses = await _context.KnxProcesses.FindAsync(id);
            if (knxProcesses == null)
            {
                return NotFound();
            }

            _context.KnxProcesses.Remove(knxProcesses);
            await _context.SaveChangesAsync();

            return knxProcesses;
        }

        private bool KnxProcessesExists(long id)
        {
            return _context.KnxProcesses.Any(e => e.Pid == id);
        }
    }
}
