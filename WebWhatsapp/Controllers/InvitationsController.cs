using Microsoft.AspNetCore.Mvc;

namespace WebWhatsappApi.Controllers
{
    public class InvitationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
