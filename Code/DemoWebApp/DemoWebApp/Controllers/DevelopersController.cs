using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoWebApp.Models;

namespace DemoWebApp.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly MyDbContext _context;

        public DevelopersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Developers
        public  IActionResult Index()
        {
            return View( _context.developers.ToList());
        }
        [HttpPost]
        public JsonResult InsertRecords(Developer developer)
        {
            //if (developers == null)
            //{
            //    developers = new List<Developer>();
            //}
            //foreach (Developer developer in developers)
            //{
            //    _context.developers.Add(developer);
            //}
            if (developer != null)
                _context.developers.Add(developer);
            int RecordsInserted = _context.SaveChanges();
            return Json(new { rec = RecordsInserted,eId = developer.Id});
        }
        [HttpPost]
        public JsonResult DeletetRecords(int id)
        {
            int RecordsInserted = 0;
            var developer =  _context.developers.SingleOrDefault(m => m.Id == id);
            if (developer != null)
            {
                _context.developers.Remove(developer);
                RecordsInserted = _context.SaveChanges();
            }
            return Json(RecordsInserted);
        }
        // GET: Developers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = _context.developers
                .SingleOrDefault(m => m.Id == id);
            if (developer == null)
            {
                return NotFound();
            }

            return PartialView(developer);
        }

        // GET: Developers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,JobTitle")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(developer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(developer);
        }

        // GET: Developers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.developers.SingleOrDefaultAsync(m => m.Id == id);
            if (developer == null)
            {
                return NotFound();
            }
            return View(developer);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,JobTitle")] Developer developer)
        {
            if (id != developer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeveloperExists(developer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(developer);
        }
     
        private bool DeveloperExists(int id)
        {
            return _context.developers.Any(e => e.Id == id);
        }
    }
}
