using Microsoft.AspNetCore.Mvc;

namespace DevXuongMoc.Areas.Admins.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
