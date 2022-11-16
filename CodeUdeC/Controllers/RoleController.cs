using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CodeUdeC.Core;

namespace CodeUdeC.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.Moderator}")]
        public IActionResult Moderator()
        {
            return View();
        }

        [Authorize(Roles  = $"{Constants.Roles.Administrator}")]
        public IActionResult Admin()
        {
            return View();
        }

    }
}
