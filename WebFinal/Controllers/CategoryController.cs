using Microsoft.AspNetCore.Mvc;
using WebFinal.Models;
using WebFinal.Repository.IRepository;

namespace WebFinal.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IUnitofWork _unitofWork;

        private readonly ILogger<CategoryController> _logger;
        public CategoryController(IUnitofWork unitofWork, ILogger<CategoryController> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        //undex CategoryController that show all category in table 
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitofWork.Category.GetAll();
            return View(objCategoryList);
        }
        //Get , Create the Category index
        public IActionResult Create()
        {
            return View();
        }
        //Post, Create the Category index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.Category.Add(obj);
                    _unitofWork.Save();
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Create Post Category exption {ex.GetBaseException().Message}");
                TempData["error"] = "Category Uncreated, try again later";
                return RedirectToAction("Index");
            }
        }
        //Get, edit the Category index
        public IActionResult Edit(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var cargoryFromDbFirst = _unitofWork.Category.GetFirstOrDefault(u => u.Id == id);

                if (cargoryFromDbFirst == null)
                {
                    return NotFound();
                }
                return View(cargoryFromDbFirst);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Edit Get Category exption {ex.GetBaseException().Message}");
                TempData["error"] = "Category not edited , try again later";
                return RedirectToAction("Index");
            }
        }
        //Post, edit the Category index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.Category.Update(obj);
                    _unitofWork.Save();
                    TempData["success"] = "Category Edited successfully";
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Edit post Category exption {ex.GetBaseException().Message}");
                TempData["error"] = "Category not edited , try again later";
                return RedirectToAction("Index");
            }
        }



        //Get, Delete the Category index
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    TempData["error"] = "Category not found, try again later";
                    return RedirectToAction("Index");
                }
                var cargoryFromDbFirst = _unitofWork.Category.GetFirstOrDefault(u => u.Id == id);

                if (cargoryFromDbFirst == null)
                {
                    TempData["error"] = "Category not found, try again later";
                    return RedirectToAction("Index");
                }
                return View(cargoryFromDbFirst);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Delete get Category exption {ex.GetBaseException().Message}");
                TempData["error"] = "Category not deleted , try again later";
                return RedirectToAction("Index");
            }
        }
        //Post, Delete the Category index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            try
            {
                var obj = _unitofWork.Category.GetFirstOrDefault(u => u.Id == id);
                if (obj == null)
                {
                    return NotFound();
                }
                _unitofWork.Category.Remove(obj);
                _unitofWork.Save();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Delete Post Category exption {ex.GetBaseException().Message}");
                TempData["error"] = "Category Undeleted, try again later";
                return RedirectToAction("Index");
            }
        }
    }
}
