using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SLICKIce.Application.Data;
using SLICKIce.Application.Models;
using SLICKIce.DAL;

namespace SLICKIce.Application.Controllers
{
    public class ItemController : Controller
    {
        private readonly IRespositoryAsync<Item> _itemsRepo;

        public ItemController(SLICKIceDBContext context)
        {
            _itemsRepo = new WinterGearRepositoryEFC(context);
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            return View(await _itemsRepo.SelectAll().ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _itemsRepo.SelectByIdAsync(new Item { ItemId = (int)id });
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ItemId,ItemName,ItemDescription,ItemType,ItemCondition")] Item item)
        {
            if (ModelState.IsValid)
            {
                _itemsRepo.Insert(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _itemsRepo.SelectByIdAsync(new Item { ItemId = (int)id });
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ItemId,ItemName,ItemDescription,ItemType,ItemCondition")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _itemsRepo.UpdateAsync(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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
            return View(item);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _itemsRepo.SelectByIdAsync(new Item { ItemId = (int)id });
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _itemsRepo.SelectByIdAsync(new Item { ItemId = (int)id });
            await _itemsRepo.DeleteAsync(item);
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _itemsRepo.SelectById(new Item { ItemId = (int)id }) != null;
        }
    }
}
