using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataBase.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync()); // мы будем получать объекты из бд, создавать из них список и передавать в представление.
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user); // для данных из объекта user формируется sql - выражение INSERT
            await db.SaveChangesAsync(); // выполняет это выражение, тем самым добавляя данные в базу данных.
            return RedirectToAction("Index");
        }
    }
}