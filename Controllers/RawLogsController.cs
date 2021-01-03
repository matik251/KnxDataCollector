using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnxDataCollector.Models;
using Microsoft.AspNetCore.Cors;

namespace KnxDataCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawLogsController : ControllerBase
    {
        private readonly KnxDBContext _context;

        public RawLogsController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: api/RawLogs
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<RawLogs>>> GetRawLogs()
        {
            //return await _context.RawLogs.ToListAsync();
            var rawLogs = new RawLogs();
            rawLogs.LogId = 1;
            rawLogs.RawData = "0000000000000000000000000000";
            var temp = new List<RawLogs>();
            temp.Add(rawLogs);
            var actionresultrawLogs = new ActionResult<IEnumerable<RawLogs>>(temp);
            return actionresultrawLogs;
        }

        // GET: api/RawLogs/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<RawLogs>> GetRawLogs(int id)
        {
            //var rawLogs = await _context.RawLogs.FindAsync(id);

            //if (rawLogs == null)
            //{
            //    return NotFound();
            //}

            var rawLogs = new ActionResult<RawLogs>(new RawLogs());
            return rawLogs;
        }

        // PUT: api/RawLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
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

        // POST: api/RawLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<RawLogs>> PostRawLogs(RawLogs rawLogs)
        {
            _context.RawLogs.Add(rawLogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRawLogs", new { id = rawLogs.LogId }, rawLogs);
        }

        // DELETE: api/RawLogs/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
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
