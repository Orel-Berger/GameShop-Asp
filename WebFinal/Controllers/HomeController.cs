using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebFinal.Data;
using WebFinal.Models;
using WebFinal.Repository.IRepository;

namespace WebFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitofWork _unitofWork;
        public HomeController( ILogger<HomeController> logger, IUnitofWork unitofWork)
        {
            _logger = logger;
            _unitofWork = unitofWork;
        }
        // get ,Home page show the 3 best games
        public IActionResult Index()
        {         
            IEnumerable<Game> gameList = _unitofWork.Comment.Top3Commented();
            return View(gameList);
       
        }
        // get ,Privacy page show the 3 best games
        public IActionResult Privacy()
        {
            try
            {
                //throw new NotImplementedException();    
                return View();
            }
           catch(Exception ex)
            {
                _logger.LogError(ex, $"privesy exption {ex.GetBaseException().Message}");
                return RedirectToAction("Index");
            }
 
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult staff()
        {
            IEnumerable<Game> gameList = _unitofWork.Comment.Top3Commented();
            return View(gameList);

        }
    }
}