using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebFinal.Models;
using WebFinal.Repository;
using WebFinal.Repository.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebFinal.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CustomerController> _logger;


        public CustomerController(IUnitofWork unitofWork, ILogger<CustomerController> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        // GET: CustomerController Show all games in table with function to comment them and also more details
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                Game game = new();
                IEnumerable<SelectListItem> CategoryList = _unitofWork.Category.GetAll().Select(
                    u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                ViewBag.CategoryList = CategoryList;
                IEnumerable<Game> gameList = _unitofWork.Game.GetAll();
                return View(gameList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Index get game exption {ex.GetBaseException().Message}");
                TempData["error"] = "Game now Are not Available, try again later";
                return RedirectToAction("Index");
            }
        }


        //post: this take id of category and sorting by id
        [HttpPost]
        public ActionResult index(int categoryId)
        {
            try
            {
                var objCategory = _unitofWork.Category.GetFirstOrDefault(u => u.Id == categoryId);
                IEnumerable<SelectListItem> CategoryList = _unitofWork.Category.GetAll().ToList().Select(
                    u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                ViewBag.CategoryList = CategoryList.ToList();
                if (categoryId == null || categoryId <= 0)
                {
                    IEnumerable<Game> gameList = _unitofWork.Game.GetAll();
                    return View(gameList);
                }
                TempData["Data"] = $"By {objCategory.Name}";
                IEnumerable<Game> GameByCategory = _unitofWork.Game.GetGameByCategoryId(categoryId);
                return View(GameByCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Index Post Sort game exption {ex.GetBaseException().Message}");
                TempData["error"] = "Game now Are not can Be Sorted, try again later";
                return RedirectToAction("Index");
            }
        }

        //get: show the 2 top game with most Comment
        public ActionResult showPopular(int? id)
        {
            try
            {
                IEnumerable<SelectListItem> CategoryList = _unitofWork.Category.GetAll().Select(
                 u => new SelectListItem
                 {
                     Text = u.Name,
                     Value = u.Id.ToString()
                 });
                IEnumerable<Game> gameList = _unitofWork.Comment.TopTwoCommented();
                return View(gameList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"showPopular get game exption {ex.GetBaseException().Message}");
                TempData["error"] = "Game now Are not can Be Sorted, try again later";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        //get: Create comment that get from from view Game id ,rating and the description
        public ActionResult AddComment(int articleId, int rating, string articleComment)
        {
            try
            {
                Comment obj = new ();
                obj.GameId = articleId;
                obj.Description = articleComment;
                obj.PublishDate = DateTime.Now;
                obj.Rating = rating;
                _unitofWork.Comment.Add(obj);
                _unitofWork.Save();
                TempData["success"] = "Comment Created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Add Comment post game exption {ex.GetBaseException().Message}");
                TempData["error"] = "Comment Created Unsuccessfully try again later";
                return RedirectToAction("Index");
            }
        }
        //get: show all comment this is partial view that shown in view of add comment
        public ActionResult showComment(int id)
        {
            try
            {
                IEnumerable<Comment> commentsList = _unitofWork.Comment.GetCommentsByGameId(id);
                var gameName = _unitofWork.Game.GetFirstOrDefault(u => u.Id == id);
                ViewBag.GameImage = gameName.ImageUrl;
                ViewBag.GameName = gameName.Title;
                ViewBag.Gameid = id;
                ViewBag.Comment = commentsList.Count();
                return View(commentsList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"showComment get game exption {ex.GetBaseException().Message}");
                TempData["error"] = "Can not Show Commnts Right Nowm try again later";
                return RedirectToAction("Index");
            }
        }

        // GET: CustomerController/Details/5  show details of the game view
        public ActionResult Details(int id)
        {
            try
            {
                ShoppingCart cartObj = new()
                {
                    Game = _unitofWork.Game.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category"),

                };
                ViewBag.GameID = id;
                return View(cartObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Details get game exption {ex.GetBaseException().Message}");
                TempData["error"] = "Can not Show Details Right Now try again later";
                return RedirectToAction("Index");
            }
        }
    }
}
