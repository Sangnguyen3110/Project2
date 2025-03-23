using Devxuongmoc.Areas.Admins.Models;
using DevXuongMoc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevXuongMoc.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class LoginController : Controller
    {
        public DevXuongMocContext _context;

        public LoginController(DevXuongMocContext context)
        {
            _context = context;
        }

        [HttpGet]// get, hiển thị form để nhập dữ liệu
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] // POST -> khi submit form
        public IActionResult Index(Login model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không hợp lệ.");
                return View(model);
            }

            var pass = model.Password;
            var dataLogin = _context.AdminUsers.FirstOrDefault(x => x.Email.Equals(model.Email) && x.Password.Equals(pass));
            if (dataLogin != null)
            {
                HttpContext.Session.SetString("AdminLogin", model.Email);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không chính xác.");
                return View(model);
            }

        }
        [HttpGet]// thoát đăng nhập, huỷ session
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLogin"); // huỷ session với key AdminLogin đã lưu trước đó

            return RedirectToAction("Index");
        }
    }
}