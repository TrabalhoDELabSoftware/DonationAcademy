using DonationAcademy.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonationAcademy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RolesTypes.Admin + "," + RolesTypes.Vendedor + "," + RolesTypes.Gerente)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
