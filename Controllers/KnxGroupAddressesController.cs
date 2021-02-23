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
    [Route("api/KnxGroupAddresses/[action]")]
    [ApiController]
    public class KnxGroupAddressesController : ControllerBase
    {
        private readonly KnxDBContext _context;

        public KnxGroupAddressesController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: api/KnxGroupAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnxGroupAddresses>>> GetKnxGroupAddresses()
        {
            return await _context.KnxGroupAddresses.ToListAsync();
        }

        // GET: api/KnxGroupAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnxGroupAddresses>> GetKnxGroupAddresses(int id)
        {
            var knxGroupAddresses = await _context.KnxGroupAddresses.FindAsync(id);

            if (knxGroupAddresses == null)
            {
                return NotFound();
            }

            return knxGroupAddresses;
        }

        
        // GET: api/KnxGroupAddresses/groupAddress
        public async Task<ActionResult<KnxGroupAddresses>> GetKnxGroupAddressesByGroupAddress(string groupAddress)
        {
            var knxGroupAddresses = await _context.KnxGroupAddresses.ToListAsync();

            var knxGroupAddressesList = knxGroupAddresses.Where(p => p.GroupAddress.Equals(groupAddress)).ToList();

            if (knxGroupAddresses == null)
            {
                if (knxGroupAddresses.Count < 1)
                {
                    return NotFound();
                }
            }

            if(knxGroupAddressesList.Count < 1)
            {
                return NotFound();
            }

            return knxGroupAddressesList[0];
        }

        // PUT: api/KnxGroupAddresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnxGroupAddresses(int id, KnxGroupAddresses knxGroupAddresses)
        {
            if (id != knxGroupAddresses.Gid)
            {
                return BadRequest();
            }

            _context.Entry(knxGroupAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnxGroupAddressesExists(id))
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

        // POST: api/KnxGroupAddresses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KnxGroupAddresses>> PostKnxGroupAddresses(KnxGroupAddresses knxGroupAddresses)
        {
            _context.KnxGroupAddresses.Add(knxGroupAddresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnxGroupAddresses", new { id = knxGroupAddresses.Gid }, knxGroupAddresses);
        }

        // DELETE: api/KnxGroupAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnxGroupAddresses>> DeleteKnxGroupAddresses(int id)
        {
            var knxGroupAddresses = await _context.KnxGroupAddresses.FindAsync(id);
            if (knxGroupAddresses == null)
            {
                return NotFound();
            }

            _context.KnxGroupAddresses.Remove(knxGroupAddresses);
            await _context.SaveChangesAsync();

            return knxGroupAddresses;
        }

        private bool KnxGroupAddressesExists(int id)
        {
            return _context.KnxGroupAddresses.Any(e => e.Gid == id);
        }
    }
}
