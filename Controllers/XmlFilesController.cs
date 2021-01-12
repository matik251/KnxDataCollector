using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KnxDataCollector.Model;
using Microsoft.AspNetCore.Cors;

namespace KnxDataCollector.Controllers
{
    [Route("api/mvc/[controller]")]
    [ApiController]
    public class XmlFilesController : Controller
    {
        private readonly KnxDBContext _context;

        public XmlFilesController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: XmlFiles 
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Xmlfiles.ToListAsync());
        }

        // GET: XmlFiles/Details/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xmlFiles = await _context.Xmlfiles
                .FirstOrDefaultAsync(m => m.Fid == id);
            if (xmlFiles == null)
            {
                return NotFound();
            }

            return View(xmlFiles);
        }

        // POST: XmlFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fid,FileName,Xmldata,IsProcessed,ProcessingPercentage,TelegramsCount,CancellationToken")] XmlFiles xmlFiles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xmlFiles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(xmlFiles);
        }


        // GET: XmlFiles/Edit/5
        [HttpGet]
        [Route("api/[controller]/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xmlFiles = await _context.Xmlfiles.FindAsync(id);
            if (xmlFiles == null)
            {
                return NotFound();
            }
            return View(xmlFiles);
        }

        //// POST: XmlFiles/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Fid,FileName,Xmldata,IsProcessed,ProcessingPercentage,TelegramsCount,CancellationToken")] XmlFiles xmlFiles)
        //{
        //    if (id != xmlFiles.Fid)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(xmlFiles);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!XmlFilesExists(xmlFiles.Fid))
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
        //    return View(xmlFiles);
        //}

        //// GET: XmlFiles/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var xmlFiles = await _context.Xmlfiles
        //        .FirstOrDefaultAsync(m => m.Fid == id);
        //    if (xmlFiles == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(xmlFiles);
        //}

        //// POST: XmlFiles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var xmlFiles = await _context.Xmlfiles.FindAsync(id);
        //    _context.Xmlfiles.Remove(xmlFiles);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool XmlFilesExists(int id)
        {
            return _context.Xmlfiles.Any(e => e.Fid == id);
        }
    }
}
