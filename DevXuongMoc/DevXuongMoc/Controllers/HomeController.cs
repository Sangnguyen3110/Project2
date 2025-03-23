﻿using System.Diagnostics;
using DevXuongMoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevXuongMoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly DevXuongMocContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DevXuongMocContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var hotProducts = _context.Products.Where(p => p.Hot == 1).ToList();

            // Truyền danh sách này vào View
            return View(hotProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
