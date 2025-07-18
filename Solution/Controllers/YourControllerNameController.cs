//
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Solution.Data;
// using Solution.Models;
//
// namespace Solution.Controllers
// //mvc a remplir / a modifier pour aller avec service
// {
//     public class YourControllerNameController(ContextDataBase context) : Controller
//     {
//         private readonly ContextDataBase _context = context;
//
//         // GET: /YourControllerName/
//         public async Task<IActionResult> Index()
//         {
//             var items = await _context.Entities
//                 .Include(e => e.RelationPropriete) // À adapter selon vos relations
//                 .ToListAsync();
//
//             return View(items);
//         }
//
//         // GET: /YourControllerName/Details/5
//         public async Task<IActionResult> Details(int id)
//         {
//             var item = await _context.Entities
//                 .Include(e => e.RelationPropriete)
//                 .FirstOrDefaultAsync(e => e.Id == id);
//
//             if (item == null)
//             {
//                 return NotFound();
//             }
//
//             return View(item);
//         }
//
//         // GET: /YourControllerName/Create
//         public IActionResult Create()
//         {
//             return View();
//         }
//
//         // POST: /YourControllerName/Create
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("Propriete1,Propriete2,Propriete3")] Entity entity)
//         {
//             if (ModelState.IsValid)
//             {
//                 _context.Entities.Add(entity);
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(entity);
//         }
//
//         // GET: /YourControllerName/Edit/5
//         public async Task<IActionResult> Edit(int id)
//         {
//             var item = await _context.Entities.FindAsync(id);
//             if (item == null)
//             {
//                 return NotFound();
//             }
//             return View(item);
//         }
//
//         // POST: /YourControllerName/Edit/5
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(int id, [Bind("Id,Propriete1,Propriete2,Propriete3")] Entity entity)
//         {
//             if (id != entity.Id)
//             {
//                 return NotFound();
//             }
//
//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(entity);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!EntityExists(entity.Id))
//                     {
//                         return NotFound();
//                     }
//                     throw;
//                 }
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(entity);
//         }
//
//         // GET: /YourControllerName/Delete/5
//         public async Task<IActionResult> Delete(int id)
//         {
//             var item = await _context.Entities
//                 .FirstOrDefaultAsync(e => e.Id == id);
//             if (item == null)
//             {
//                 return NotFound();
//             }
//
//             return View(item);
//         }
//
//         // POST: /YourControllerName/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(int id)
//         {
//             var item = await _context.Entities.FindAsync(id);
//             if (item != null)
//             {
//                 _context.Entities.Remove(item);
//                 await _context.SaveChangesAsync();
//             }
//             return RedirectToAction(nameof(Index));
//         }
//
//         private bool EntityExists(int id)
//         {
//             return _context.Entities.Any(e => e.Id == id);
//         }
//     }
// }