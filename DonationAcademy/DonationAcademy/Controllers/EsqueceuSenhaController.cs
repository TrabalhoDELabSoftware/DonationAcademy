using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonationAcademy.Controllers
{
    public class EsqueceuSenhaController : Controller
    {
        [AllowAnonymous]
        public IActionResult EsqueceuSenha()
        {
            return View();
        }
    }
}
