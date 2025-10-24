using dts_231220886_de02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dts_231220886_de02.Controllers
{
    public class DtsCatalogsController : Controller
    {
        private readonly DtsDbContext _context;

        public DtsCatalogsController(DtsDbContext context)
        {
            _context = context;
        }

        // GET: DtsCatalogs/DtsIndex
        public async Task<IActionResult> DtsIndex()
        {
            var list = await _context.DtsCatalogs.ToListAsync();
            return View(list);
        }

        // GET: DtsCatalogs/DtsDetails/5
        public async Task<IActionResult> DtsDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dtsCatalog = await _context.DtsCatalogs
                .FirstOrDefaultAsync(m => m.DtsId == id);

            if (dtsCatalog == null)
            {
                return NotFound();
            }

            return View(dtsCatalog);
        }

        // GET: DtsCatalogs/DtsCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DtsCreate([Bind("DtsId,DtsCateName,DtsCatePrice,DtsCateQty,DtsCateActive")] DtsCatalog dtsCatalog,
                                           IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Lưu file vào wwwroot/uploads
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    // Set path cho entity
                    dtsCatalog.DtsCatePicture = "/uploads/" + fileName;
                }

                _context.Add(dtsCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DtsIndex));
            }

            return View(dtsCatalog);
        }


        // GET: DtsCatalogs/DtsEdit/5
        public async Task<IActionResult> DtsEdit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dtsCatalog = await _context.DtsCatalogs.FindAsync(id);
            if (dtsCatalog == null)
            {
                return NotFound();
            }
            return View(dtsCatalog);
        }

        // POST: DtsCatalogs/DtsEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DtsEdit(string id, [Bind("DtsId,DtsCateName,DtsCatePrice,DtsCateQty,DtsCatePicture,DtsCateActive")] dts_231220886_de02.Models.DtsCatalog dtsCatalog)
        {
            if (id != dtsCatalog.DtsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dtsCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DtsCatalogExists(dtsCatalog.DtsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(DtsIndex));
            }
            return View(dtsCatalog);
        }

        // GET: DtsCatalogs/DtsDelete/5
        public async Task<IActionResult> DtsDelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dtsCatalog = await _context.DtsCatalogs
                .FirstOrDefaultAsync(m => m.DtsId == id);

            if (dtsCatalog == null)
            {
                return NotFound();
            }

            return View(dtsCatalog);
        }

        // POST: DtsCatalogs/DtsDelete/5
        [HttpPost, ActionName("DtsDeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DtsDeleteConfirmed(string id)
        {
            var dtsCatalog = await _context.DtsCatalogs.FindAsync(id);
            if (dtsCatalog != null)
            {
                _context.DtsCatalogs.Remove(dtsCatalog);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(DtsIndex));
        }

        private bool DtsCatalogExists(string id)
        {
            return _context.DtsCatalogs.Any(e => e.DtsId == id);
        }
    }
}
