using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DonationAcademy.Context;
using DonationAcademy.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using ReflectionIT.Mvc.Paging;

namespace DonationAcademy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RolesTypes.Admin + "," + RolesTypes.Vendedor + "," + RolesTypes.Gerente)]
    public class AdminMateriaisController : Controller
    {
        private readonly AppDbContext _context;

        public AdminMateriaisController(AppDbContext context)
        {
            _context = context;
        }

        //// GET: Admin/AdminMateriais
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.Materiais.Include(m => m.Categoria);
        //    return View(await appDbContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var resultado = _context.Materiais
                .Include(m => m.Categoria).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.Contains(filter));
            }

            var model = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }

        // GET: Admin/AdminMateriais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Materiais == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Admin/AdminMateriais/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Admin/AdminMateriais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,EmEstoque,IsMaterialPago,CategoriaId")] Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", material.CategoriaId);
            return View(material);
        }

        // GET: Admin/AdminMateriais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Materiais == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", material.CategoriaId);
            return View(material);
        }

        // POST: Admin/AdminMateriais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,EmEstoque,IsMaterialPago,CategoriaId")] Material material)
        {
            if (id != material.MaterialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.MaterialId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", material.CategoriaId);
            return View(material);
        }

        // GET: Admin/AdminMateriais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materiais == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Admin/AdminMateriais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Materiais == null)
            {
                return Problem("Entity set 'AppDbContext.Materiais'  is null.");
            }
            var material = await _context.Materiais.FindAsync(id);
            if (material != null)
            {
                _context.Materiais.Remove(material);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
          return _context.Materiais.Any(e => e.MaterialId == id);
        }
    }
}
