using Microsoft.AspNetCore.Mvc;

namespace DonationAcademy.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult ContatoView()
        {
            return View();
        }
    }
}
