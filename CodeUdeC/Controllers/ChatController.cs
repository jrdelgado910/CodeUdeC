using Microsoft.AspNetCore.Mvc;

namespace CodeUdeC.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
