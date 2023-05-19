using DonationAcademy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonationAcademy.Areas.PostAdmin.Controllers
{
    [Area("PostAdmin")]
    [Authorize(Roles = RolesTypes.Admin + "," + RolesTypes.Gerente)]
    public class AdminPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
