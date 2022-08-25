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
    public class PostsController : Controller
    {
        private readonly SurfBoardManagerContext _context;

        public PostsController(SurfBoardManagerContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return _context.Post != null ?
                          View(await _context.Post.Include("Board").ToListAsync()) :
                          Problem("Entity set 'SurfBoardManagerContext.Post'  is null.");
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Boards = _context.Board != null ? await _context.Board.ToListAsync() : new List<Board>();
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public async Task<IActionResult> Create()
        {
            PostBoardsViewModel postBoardsViewModel = new PostBoardsViewModel();
            postBoardsViewModel.Boards = _context.Board != null ? await _context.Board.ToListAsync() : new List<Board>();
            postBoardsViewModel.Post = new Post();
            return View(postBoardsViewModel);
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Post,ChosenBoardId")] PostBoardsViewModel postBoardsViewModel)
        {
            postBoardsViewModel.Post.Board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == postBoardsViewModel.ChosenBoardId);
            ModelState.Remove("Boards");
            if (ModelState.IsValid)
            {
                _context.Add(postBoardsViewModel.Post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postBoardsViewModel);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            PostBoardsViewModel postBoardsViewModel = new PostBoardsViewModel();

            postBoardsViewModel.Post = post;
            postBoardsViewModel.Boards = _context.Board != null ? await _context.Board.ToListAsync() : new List<Board>();
            postBoardsViewModel.ChosenBoardId = 0;

            return View(postBoardsViewModel);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Post, ChosenBoardId")] PostBoardsViewModel postBoardsViewModel)
        {
            postBoardsViewModel.Post.Board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == postBoardsViewModel.ChosenBoardId);
            if (id != postBoardsViewModel.Post.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Boards");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postBoardsViewModel.Post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(postBoardsViewModel.Post.Id))
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
            postBoardsViewModel.Boards = _context.Board != null ? await _context.Board.ToListAsync() : new List<Board>();
            return View(postBoardsViewModel);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post == null)
            {
                return Problem("Entity set 'SurfBoardManagerContext.Post'  is null.");
            }
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return (_context.Post?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
