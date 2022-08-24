using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfBoardManager.Data;
using SurfBoardManager.Models;

namespace SurfBoardManager.Controllers
{
    public class BoardTypesController : Controller
    {
        private readonly SurfBoardManagerContext _context;

        public BoardTypesController(SurfBoardManagerContext context)
        {
            _context = context;
        }

        // GET: BoardTypes
        public async Task<IActionResult> Index()
        {
              return _context.BoardType != null ? 
                          View(await _context.BoardType.ToListAsync()) :
                          Problem("Entity set 'SurfBoardManagerContext.BoardType'  is null.");
        }

        // GET: BoardTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BoardType == null)
            {
                return NotFound();
            }

            var boardType = await _context.BoardType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardType == null)
            {
                return NotFound();
            }

            return View(boardType);
        }

        // GET: BoardTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoardTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] BoardType boardType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boardType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boardType);
        }

        // GET: BoardTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BoardType == null)
            {
                return NotFound();
            }

            var boardType = await _context.BoardType.FindAsync(id);
            if (boardType == null)
            {
                return NotFound();
            }
            return View(boardType);
        }

        // POST: BoardTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BoardType boardType)
        {
            if (id != boardType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardTypeExists(boardType.Id))
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
            return View(boardType);
        }

        // GET: BoardTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BoardType == null)
            {
                return NotFound();
            }

            var boardType = await _context.BoardType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardType == null)
            {
                return NotFound();
            }

            return View(boardType);
        }

        // POST: BoardTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BoardType == null)
            {
                return Problem("Entity set 'SurfBoardManagerContext.BoardType'  is null.");
            }
            var boardType = await _context.BoardType.FindAsync(id);
            if (boardType != null)
            {
                _context.BoardType.Remove(boardType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardTypeExists(int id)
        {
          return (_context.BoardType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
