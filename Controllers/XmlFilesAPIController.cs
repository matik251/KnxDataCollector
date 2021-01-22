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
    [Route("api/XmlFiles/[action]")]
    [ApiController]
    public class XmlFilesAPIController : ControllerBase
    {
        private readonly KnxDBContext _context;
        private Random _rnd;

        public XmlFilesAPIController(KnxDBContext context)
        {
            _context = context;
            _rnd = new Random();
        }

        // GET: api/XmlFilesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<XmlFiles>>> GetXmlfiles()
        {
            return await _context.XmlFiles.ToListAsync();
        }

        // GET: api/XmlFilesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<XmlFiles>> GetXmlFiles(int id)
        {
            var xmlFiles = await _context.XmlFiles.FindAsync(id);

            if (xmlFiles == null)
            {
                return NotFound();
            }

            return xmlFiles;
        }

        // GET: api/XmlFilesAPI/5
        [HttpGet]
        public async Task<ActionResult<XmlFiles>> GetNotProcessedXmlFiles([FromQuery] bool isProcessed = false)
        {
            var xmlFiles = await _context.XmlFiles.ToListAsync();
            if (xmlFiles == null)
            {
                return NotFound();
            }
            var notProcessedList = xmlFiles.Where(p => p.IsProcessed == Convert.ToInt32(isProcessed)).ToList();

            return notProcessedList[_rnd.Next(notProcessedList.Count())];
        }

        // PUT: api/XmlFilesAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXmlFiles(int id, XmlFiles xmlFiles)
        {
            if (id != xmlFiles.Fid)
            {
                return BadRequest();
            }

            _context.Entry(xmlFiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XmlFilesExists(id))
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

        // POST: api/XmlFilesAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<XmlFiles>> PostXmlFiles(XmlFiles xmlFiles)
        {
            _context.XmlFiles.Add(xmlFiles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXmlFiles", new { id = xmlFiles.Fid }, xmlFiles);
        }

        // DELETE: api/XmlFilesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<XmlFiles>> DeleteXmlFiles(int id)
        {
            var xmlFiles = await _context.XmlFiles.FindAsync(id);
            if (xmlFiles == null)
            {
                return NotFound();
            }

            _context.XmlFiles.Remove(xmlFiles);
            await _context.SaveChangesAsync();

            return xmlFiles;
        }

        private bool XmlFilesExists(int id)
        {
            return _context.XmlFiles.Any(e => e.Fid == id);
        }
    }
}
