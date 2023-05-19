using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DonationAcademy.Areas.Doador.Models;
using DonationAcademy.Context;
using DonationAcademy.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace DonationAcademy.Areas.PostAdmin.Controllers
{
    [Area("PostAdmin")]
    [Authorize(Roles = RolesTypes.Admin + "," + RolesTypes.Gerente)]
    public class AdminCategoriaDoadorController : Controller
    {
        private readonly AppDbContext _context;

        public AdminCategoriaDoadorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PostAdmin/AdminCategoriaDoador
        public async Task<IActionResult> Index()
        {
              return View(await _context.CategoriaDoadores.ToListAsync());
        }

        // GET: PostAdmin/AdminCategoriaDoador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoriaDoadores == null)
            {
                return NotFound();
            }

            var categoriaDoador = await _context.CategoriaDoadores
                .FirstOrDefaultAsync(m => m.CategoriaDoadorId == id);
            if (categoriaDoador == null)
            {
                return NotFound();
            }

            return View(categoriaDoador);
        }

        // GET: PostAdmin/AdminCategoriaDoador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostAdmin/AdminCategoriaDoador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaDoadorId,CategoriaDoadorNome,Descricao")] CategoriaDoador categoriaDoador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaDoador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDoador);
        }

        // GET: PostAdmin/AdminCategoriaDoador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoriaDoadores == null)
            {
                return NotFound();
            }

            var categoriaDoador = await _context.CategoriaDoadores.FindAsync(id);
            if (categoriaDoador == null)
            {
                return NotFound();
            }
            return View(categoriaDoador);
        }

        // POST: PostAdmin/AdminCategoriaDoador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaDoadorId,CategoriaDoadorNome,Descricao")] CategoriaDoador categoriaDoador)
        {
            if (id != categoriaDoador.CategoriaDoadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaDoador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaDoadorExists(categoriaDoador.CategoriaDoadorId))
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
            return View(categoriaDoador);
        }

        // GET: PostAdmin/AdminCategoriaDoador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoriaDoadores == null)
            {
                return NotFound();
            }

            var categoriaDoador = await _context.CategoriaDoadores
                .FirstOrDefaultAsync(m => m.CategoriaDoadorId == id);
            if (categoriaDoador == null)
            {
                return NotFound();
            }

            return View(categoriaDoador);
        }

        // POST: PostAdmin/AdminCategoriaDoador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoriaDoadores == null)
            {
                return Problem("Entity set 'AppDbContext.CategoriaDoadores'  is null.");
            }
            var categoriaDoador = await _context.CategoriaDoadores.FindAsync(id);
            if (categoriaDoador != null)
            {
                _context.CategoriaDoadores.Remove(categoriaDoador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaDoadorExists(int id)
        {
          return _context.CategoriaDoadores.Any(e => e.CategoriaDoadorId == id);
        }
    }
}
