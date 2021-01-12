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
    [Route("api/RawLogs")]
    [ApiController]
    public class RawLogsAPIController : ControllerBase
    {
        private readonly KnxDBContext _context;

        public RawLogsAPIController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: api/RawLogsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RawLogs>>> GetRawLogs()
        {
            return await _context.RawLogs.ToListAsync();
        }

        // GET: api/RawLogsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RawLogs>> GetRawLogs(int id)
        {
            var rawLogs = await _context.RawLogs.FindAsync(id);

            if (rawLogs == null)
            {
                return NotFound();
            }

            return rawLogs;
        }

        // PUT: api/RawLogsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRawLogs(int id, RawLogs rawLogs)
        {
            if (id != rawLogs.LogId)
            {
                return BadRequest();
            }

            _context.Entry(rawLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RawLogsExists(id))
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

        // POST: api/RawLogsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RawLogs>> PostRawLogs(RawLogs rawLogs)
        {
            _context.RawLogs.Add(rawLogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRawLogs", new { id = rawLogs.LogId }, rawLogs);
        }

        // DELETE: api/RawLogsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RawLogs>> DeleteRawLogs(int id)
        {
            var rawLogs = await _context.RawLogs.FindAsync(id);
            if (rawLogs == null)
            {
                return NotFound();
            }

            _context.RawLogs.Remove(rawLogs);
            await _context.SaveChangesAsync();

            return rawLogs;
        }

        private bool RawLogsExists(int id)
        {
            return _context.RawLogs.Any(e => e.LogId == id);
        }
    }
}
