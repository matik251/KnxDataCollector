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
    [Route("api/")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        private readonly KnxDBContext _context;

        public HomeApiController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: api/HomeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Home>>> GetHome()
        {
            return await _context.Home.ToListAsync();
            var result = await _context.Home.ToListAsync();

            foreach (var element in result)
            {
                element.Time = DateTime.Now;
            }
            return result;
        }

        // GET: api/HomeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Home>> GetHome(int id)
        {
            var home = await _context.Home.FindAsync(id);

            if (home == null)
            {
                return NotFound();
            }

            return home;
        }

        // PUT: api/HomeApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(int id, Home home)
        {
            if (id != home.ID)
            {
                return BadRequest();
            }

            _context.Entry(home).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(id))
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

        // POST: api/HomeApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Home>> PostHome(Home home)
        {
            _context.Home.Add(home);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHome", new { id = home.ID }, home);
        }

        // DELETE: api/HomeApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Home>> DeleteHome(int id)
        {
            var home = await _context.Home.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            _context.Home.Remove(home);
            await _context.SaveChangesAsync();

            return home;
        }

        private bool HomeExists(int id)
        {
            return _context.Home.Any(e => e.ID == id);
        }
    }
}
