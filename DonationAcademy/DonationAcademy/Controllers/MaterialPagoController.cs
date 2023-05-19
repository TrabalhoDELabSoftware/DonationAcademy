using DonationAcademy.Repositories.Interfaces;
using DonationAcademy.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonationAcademy.Controllers
{
    [Authorize]
    public class MaterialPagoController : Controller
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialPagoController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        [Authorize]
        public IActionResult MaterialPago()
        {
            var materialPagoViewModel = new MaterialPagoViewModel 
            { 
                
                MateriaisPagos = _materialRepository.MateriaisPagos
            
            };

            return View(materialPagoViewModel);
        }
    }
}
