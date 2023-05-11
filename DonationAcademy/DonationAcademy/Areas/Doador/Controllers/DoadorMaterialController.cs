using DonationAcademy.Areas.Doador.Models;
using DonationAcademy.Areas.Doador.Repositories.Interfaces;
using DonationAcademy.Areas.Doador.ViewModels;
using DonationAcademy.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DonationAcademy.Areas.Doador.Controllers
{
    [Area("Doador")]
    [Authorize(Roles = RolesTypes.Admin + "," + RolesTypes.AreaDoacao)]
    public class DoadorMaterialController : Controller
    {
        private readonly IMaterialDoadorRepository _materialDoadorRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public DoadorMaterialController(IMaterialDoadorRepository materialDoadorRepository, UserManager<IdentityUser> userManager)
        {
            _materialDoadorRepository = materialDoadorRepository;
            _userManager = userManager;
        }

        public IActionResult ListDoador(string categoria)
        {
            IEnumerable<DoadorM> doadores;
            string categoriaDoadorAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                doadores = _materialDoadorRepository.DoadorMs.OrderBy(dm => dm.Id);

                categoriaDoadorAtual = "Área de Doação";
            }
            else
            {
                doadores = _materialDoadorRepository.DoadorMs
                    .Where(dm => dm.CategoriaDoador.CategoriaDoadorNome.Equals(categoria))
                    .OrderBy(dm => dm.Nome);

                categoriaDoadorAtual = categoria;
            }

            var doadorListViewModel = new DoadorListViewModel
            {
                Doadores = doadores,
                CategoriaDoadorAtual = categoriaDoadorAtual

            };

            return View(doadorListViewModel);

        }


        public async Task<IActionResult> Details(int id)
        {
            var doador = _materialDoadorRepository.DoadorMs.FirstOrDefault(dm => dm.Id == id);

            if (doador == null)
            {
                return NotFound();
            }

            // Obter o usuário associado à postagem
            var user = await _userManager.FindByIdAsync(doador.UserId);

            if (user != null)
            {
                // Atribuir o usuário à propriedade User do objeto DoadorM
                doador.User = user;
            }

            return View(doador);
        }


        public IActionResult Search(string searchString)
        {
            IEnumerable<DoadorM> doadorMs;
            string categoriaDoadorAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                doadorMs = _materialDoadorRepository.DoadorMs.OrderBy(dm => dm.Id);
                categoriaDoadorAtual = "Área de doação";

            }
            else
            {
                doadorMs = _materialDoadorRepository.DoadorMs
                    .Where(dm => dm.Nome.ToLower()
                    .Contains(searchString.ToLower()));

                if (doadorMs.Any())
                    categoriaDoadorAtual = "Área de doação";
                else
                    categoriaDoadorAtual = "Nenhum material foi encontrado";
            }

            return View("~/Areas/Doador/Views/DoadorMaterial/ListDoador.cshtml", new DoadorListViewModel
            {
                Doadores = doadorMs,
                CategoriaDoadorAtual = categoriaDoadorAtual
            });

        }


    }
}
