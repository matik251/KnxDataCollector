using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KnxDataCollector.Model;
using Microsoft.AspNetCore.Cors;

namespace KnxDataCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnxTelegramsController : Controller
    {
        private readonly KnxDBContext _context;

        public KnxTelegramsController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: KnxTelegrams
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.KnxTelegrams.ToListAsync());
        }

        // GET: KnxTelegrams/Details/
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knxTelegrams = await _context.KnxTelegrams
                .FirstOrDefaultAsync(m => m.Tid == id);
            if (knxTelegrams == null)
            {
                return NotFound();
            }

            return View(knxTelegrams);
        }

        // POST: KnxTelegrams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Tid,TimestampS,Timestamp,Service,FrameFormat,RawData,RawDataLength,FileName")] KnxTelegrams knxTelegrams)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knxTelegrams);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(knxTelegrams);
        }

        // GET: KnxTelegrams/Edit/5
        [HttpGet("{id}")]
        [Route("api/[controller]/Edit/{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knxTelegrams = await _context.KnxTelegrams.FindAsync(id);
            if (knxTelegrams == null)
            {
                return NotFound();
            }
            return View(knxTelegrams);
        }

        //// POST: KnxTelegrams/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("Tid,TimestampS,Timestamp,Service,FrameFormat,RawData,RawDataLength,FileName")] KnxTelegrams knxTelegrams)
        //{
        //    if (id != knxTelegrams.Tid)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(knxTelegrams);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!KnxTelegramsExists(knxTelegrams.Tid))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(knxTelegrams);
        //}

        //// GET: KnxTelegrams/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var knxTelegrams = await _context.KnxTelegrams
        //        .FirstOrDefaultAsync(m => m.Tid == id);
        //    if (knxTelegrams == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(knxTelegrams);
        //}

        //// POST: KnxTelegrams/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var knxTelegrams = await _context.KnxTelegrams.FindAsync(id);
        //    _context.KnxTelegrams.Remove(knxTelegrams);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool KnxTelegramsExists(long id)
        //{
        //    return _context.KnxTelegrams.Any(e => e.Tid == id);
        //}
    }
}
