using DonationAcademy.Areas.Doador.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace DonationAcademy.Areas.Doador.Components
{
    public class CategoriaDoadorMenu : ViewComponent
    {
        private readonly ICategoriaDoadorRepository _categoriaDoadorRepository;

        public CategoriaDoadorMenu(ICategoriaDoadorRepository categoriaDoadorRepository)
        {
            _categoriaDoadorRepository = categoriaDoadorRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaDoadorRepository.CategoriaDoadores
                .OrderBy(cd => cd.CategoriaDoadorNome);

            return View(categorias);
        }
    }
}
