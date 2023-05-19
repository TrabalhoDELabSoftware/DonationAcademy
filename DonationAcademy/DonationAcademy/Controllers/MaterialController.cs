using DonationAcademy.Models;
using DonationAcademy.Repositories.Interfaces;
using DonationAcademy.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonationAcademy.Controllers
{
    [Authorize]
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Material> materiais;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                materiais = _materialRepository.Materiais.OrderBy(m => m.MaterialId);

                categoriaAtual = "Todos os materiais";
            }
            else
            {
                #region código para categorias fixas
                //if (string.Equals("Livros", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    materiais = _materialRepository.Materiais
                //        .Where(m => m.Categoria.CategoriaNome.Equals("Livros"))
                //        .OrderBy(m => m.Nome);
                //}
                //else
                //{
                //    materiais = _materialRepository.Materiais
                //        .Where(m => m.Categoria.CategoriaNome.Equals("Cadernos"))
                //        .OrderBy(m => m.Nome);
                //}
                #endregion
               
                materiais = _materialRepository.Materiais
                    .Where(m => m.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(m => m.Nome);

                categoriaAtual = categoria;
            }

            var materialListViewModel = new MaterialListViewModel 
            { 
                Materiais = materiais,
                CategoriaAtual = categoriaAtual
            
            };

            return View (materialListViewModel);
        }

        public IActionResult Details(int materialId)
        {
            var material = _materialRepository.Materiais.FirstOrDefault(m => m.MaterialId == materialId);

            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Material> materiais;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                materiais = _materialRepository.Materiais.OrderBy(m => m.MaterialId);
                categoriaAtual = "Todos os Materiais";

            }
            else
            {
                materiais = _materialRepository.Materiais
                    .Where(m => m.Nome.ToLower().Contains(searchString.ToLower()));

                if (materiais.Any())
                    categoriaAtual = "Material";
                else
                    categoriaAtual = "Nenhum material foi encontrado";
            }

            return View("~/Views/Material/List.cshtml", new MaterialListViewModel
            {
                Materiais = materiais,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
