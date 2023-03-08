using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using WebFinal.Models.ViewModels;
using WebFinal.Repository;
using WebFinal.Repository.IRepository;

namespace WebFinal.Controllers
{
    public class GameController : Controller
    {
        
        private readonly IUnitofWork _unitofWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly ILogger<GameController> _logger;
        public GameController(IUnitofWork unitofWork, IWebHostEnvironment hostEnvironment, ILogger<GameController> logger)
        {
            _unitofWork = unitofWork;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }
        // get ,Admin page show All Game
        public IActionResult Index()
        {
            return View();
        }
        //Get create game or edit if exsit id
        public IActionResult Upsert(int? id)
        {
            try
            {
                GameVM gameVM = new()
                {
                    Game = new(),
                    CategoryList = _unitofWork.Category.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
                };
                if (id == null || id == 0)
                {
                    //create game
                    return View(gameVM);
                }
                else
                {
                    //update game
                    gameVM.Game = _unitofWork.Game.GetFirstOrDefault(u => u.Id == id);
                    return View(gameVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Create Game exption {ex.GetBaseException().Message}");
                TempData["error"] = "somthing goes wrong, try again later";
                return RedirectToAction("Index");
            }
        }

        //Post create game or edit if exsit id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(GameVM obj, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(wwwRootPath, @"images\games");
                        var extension = Path.GetExtension(file.FileName);

                        if (obj.Game.ImageUrl != null)
                        {
                            var oldImagePath = Path.Combine(wwwRootPath, obj.Game.ImageUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }
                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            file.CopyTo(fileStreams);
                        }
                        obj.Game.ImageUrl = @"images\games\" + fileName + extension;
                    }
                    if (obj.Game.Id == 0)
                    {
                        _unitofWork.Game.Add(obj.Game);
                    }
                    else
                    {
                        _unitofWork.Game.Update(obj.Game);
                    }
                    _unitofWork.Save();
                    TempData["success"] = "Game Created successfully";
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Update Game exption {ex.GetBaseException().Message}");
                TempData["error"] = "somthing goes wrong in upsert, try again later";
                return RedirectToAction("Index");
            }
        }
        
        
        //this function for Admin.js Data table
        #region Api Calls
        [HttpGet]
        //Write all data to Json , html 
        public IActionResult GetAll()
        {
            var gameList = _unitofWork.Game.GetAll(includeProperties: "Category");
            return Json(new { data = gameList });
        }
        //Post delete data by id to Json , html and also delete the image from images
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            try
            {   
            var obj = _unitofWork.Game.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, Message = "error while delteing" });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitofWork.Game.Remove(obj);
            _unitofWork.Save();
            return Json(new { success = true, Message = "Delete success" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Delete Game exption {ex.GetBaseException().Message}");
                TempData["error"] = "somthing goes wrong in Delete, try again later";
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}
