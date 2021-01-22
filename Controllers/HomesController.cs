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
    [Route("api/mvc")]
    [ApiController]
    public class HomesController : Controller
    {
        private readonly KnxDBContext _context;

        public HomesController(KnxDBContext context)
        {
            _context = context;
        }

        // GET: Homes
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Home.ToListAsync());
        }

        // GET: Homes/Details/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Home
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        //// GET: Homes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HomeText,Time")] Home home)
        {
            if (ModelState.IsValid)
            {
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(home);
        }

        private bool HomeExists(int id)
        {
            return _context.Home.Any(e => e.Id == id);
        }
    }
}
