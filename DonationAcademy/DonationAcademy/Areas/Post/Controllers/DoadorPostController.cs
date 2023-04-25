using DonationAcademy.Areas.Doador.Models;
using DonationAcademy.Context;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using ReflectionIT.Mvc.Paging;

namespace DonationAcademy.Areas.Post.Controllers
{
    [Area("Post")]
    [Authorize]
    public class DoadorPostController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DoadorPostController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return Challenge();
            }

            var resultado = _context.Doadores
                .Where(dm => dm.UserId == currentUser.Id)
                .Include(dm => dm.CategoriaDoador)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(dm => dm.Nome.Contains(filter));
            }

            var doadorPosts = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "Nome");

            doadorPosts.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(doadorPosts);
        }



        // GET: DoadorPostController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Obtém o id do usuário logado
            var userId = _userManager.GetUserId(User);

            // Busca as postagens filtrando pelo id do usuário logado
            var doadorM = await _context.Doadores
                .Include(d => d.CategoriaDoador)
                .Where(d => d.UserId == userId && d.Id == id)
                .FirstOrDefaultAsync();

            if (doadorM == null)
            {
                return NotFound();
            }

            return View(doadorM);
        }


        // GET: DoadorPostController/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaDoadorId = new SelectList(_context.CategoriaDoadores, "CategoriaDoadorId", "CategoriaDoadorNome");
            return View();
        }

        // POST: DoadorPostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DescricaoCurta,DescricaoDetalhada,ImagemUrl,ImagemThumbnailUrl,Telefone,CategoriaDoadorId")] DoadorM doadorM)
        {
            if (ModelState.IsValid)
            {
                // Obter o ID do usuário atualmente logado
                var userId = _userManager.GetUserId(User);

                // Definir a propriedade UserId do objeto DoadorM
                doadorM.UserId = userId;

                _context.Add(doadorM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaDoadorId"] = new SelectList(_context.CategoriaDoadores, "CategoriaDoadorId", "CategoriaDoadorNome", doadorM.CategoriaDoadorId);
            return View(doadorM);
        }


        // GET: DoadorPostController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var userId = _userManager.GetUserId(User);
            var doadorM = await _context.Doadores.FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (doadorM == null)
            {
                return NotFound();
            }

            ViewData["CategoriaDoadorId"] = new SelectList(_context.CategoriaDoadores, "CategoriaDoadorId", "CategoriaDoadorNome", doadorM.CategoriaDoadorId);
            return View(doadorM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DescricaoCurta,DescricaoDetalhada,ImagemUrl,ImagemThumbnailUrl,Telefone,CategoriaDoadorId")] DoadorM doadorM)
        {
            if (id != doadorM.Id)
            {
                return NotFound();
            }

            // Encontra o usuário logado
            var user = await _userManager.GetUserAsync(User);

            // Encontra a postagem do usuário logado
            var doadorPost = await _context.Doadores.FirstOrDefaultAsync(d => d.UserId == user.Id && d.Id == doadorM.Id);

            if (doadorPost == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza a postagem
                    doadorPost.Nome = doadorM.Nome;
                    doadorPost.DescricaoCurta = doadorM.DescricaoCurta;
                    doadorPost.DescricaoDetalhada = doadorM.DescricaoDetalhada;
                    doadorPost.ImagemUrl = doadorM.ImagemUrl;
                    doadorPost.ImagemThumbnailUrl = doadorM.ImagemThumbnailUrl;
                    doadorPost.Telefone = doadorM.Telefone;
                    doadorPost.CategoriaDoadorId = doadorM.CategoriaDoadorId;

                    _context.Update(doadorPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoadorMExists(doadorM.Id))
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
            ViewData["CategoriaDoadorId"] = new SelectList(_context.CategoriaDoadores, "CategoriaDoadorId", "CategoriaDoadorNome", doadorM.CategoriaDoadorId);
            return View(doadorM);
        }


        // GET: DoadorPostController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            var doadorM = await _context.Doadores
                .Include(d => d.CategoriaDoador)
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);

            if (doadorM == null)
            {
                return NotFound();
            }

            return View(doadorM);
        }


        // POST: DoadorPostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doadorM = await _context.Doadores.FindAsync(id);
            if (doadorM == null)
            {
                return NotFound();
            }

            // Verificar se o usuário logado é o dono da postagem
            var userId = _userManager.GetUserId(User);
            if (doadorM.UserId != userId)
            {
                return Unauthorized();
            }

            _context.Doadores.Remove(doadorM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool DoadorMExists(int id)
        {
            return _context.Doadores.Any(e => e.Id == id);
        }

    }
}
