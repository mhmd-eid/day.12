using System.Collections.Specialized;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using toDoList.Data;
using toDoList.Models;

namespace toDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplictionDbContext _dbcontext = new ApplictionDbContext();

     
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateNew(string name)
        {
            _dbcontext.saves.Add(new()
            {
                Name = name,
            });
            
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Show));
        } 

        public IActionResult Show()
        {

            var Db = _dbcontext.tasks.ToList();
            var User = _dbcontext.saves.OrderBy(e => e.Id).LastOrDefault();
            ViewBag.User = User;
            return View(Db);

        }
           
         

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
