using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_FastOrder.Models;

namespace E_FastOrder.Controllers
{
    public class FavoriteMenuItemsController : Controller
    {
        private readonly EfastOrderDbContext _context;

        public FavoriteMenuItemsController(EfastOrderDbContext context)
        {
            _context = context;
        }

        // GET: FavoriteMenuItems
        public async Task<IActionResult> Index()
        {
            var efastOrderDbContext = _context.FavoriteMenuItems.Include(f => f.MenuItem).Include(f => f.User);
            return View(await efastOrderDbContext.ToListAsync());
        }

        // GET: FavoriteMenuItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMenuItem = await _context.FavoriteMenuItems
                .Include(f => f.MenuItem)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FavoriteMenuItemId == id);
            if (favoriteMenuItem == null)
            {
                return NotFound();
            }

            return View(favoriteMenuItem);
        }

        // GET: FavoriteMenuItems/Create
        public IActionResult Create()
        {
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: FavoriteMenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoriteMenuItemId,UserId,MenuItemId")] FavoriteMenuItem favoriteMenuItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteMenuItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemId", favoriteMenuItem.MenuItemId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", favoriteMenuItem.UserId);
            return View(favoriteMenuItem);
        }

        // GET: FavoriteMenuItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMenuItem = await _context.FavoriteMenuItems.FindAsync(id);
            if (favoriteMenuItem == null)
            {
                return NotFound();
            }
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemId", favoriteMenuItem.MenuItemId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", favoriteMenuItem.UserId);
            return View(favoriteMenuItem);
        }

        // POST: FavoriteMenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoriteMenuItemId,UserId,MenuItemId")] FavoriteMenuItem favoriteMenuItem)
        {
            if (id != favoriteMenuItem.FavoriteMenuItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteMenuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteMenuItemExists(favoriteMenuItem.FavoriteMenuItemId))
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
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemId", favoriteMenuItem.MenuItemId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", favoriteMenuItem.UserId);
            return View(favoriteMenuItem);
        }

        // GET: FavoriteMenuItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMenuItem = await _context.FavoriteMenuItems
                .Include(f => f.MenuItem)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FavoriteMenuItemId == id);
            if (favoriteMenuItem == null)
            {
                return NotFound();
            }

            return View(favoriteMenuItem);
        }

        // POST: FavoriteMenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteMenuItem = await _context.FavoriteMenuItems.FindAsync(id);
            if (favoriteMenuItem != null)
            {
                _context.FavoriteMenuItems.Remove(favoriteMenuItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteMenuItemExists(int id)
        {
            return _context.FavoriteMenuItems.Any(e => e.FavoriteMenuItemId == id);
        }
    }
}
