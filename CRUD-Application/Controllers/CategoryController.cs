using CRUD_Application.Data;
using CRUD_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        // by Default it's a GET 
        public IActionResult Index()
        {
            List<Category> objCategories = _db.Categories.ToList();
            return View(objCategories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == "test")
            {
                ModelState.AddModelError("Name", "You have to change the name");
            }
            // Check if the name already exists in the database
            var existingCategory = _db.Categories.FirstOrDefault(c => c.Name == obj.Name);
            if (existingCategory != null)
            {
                ModelState.AddModelError("Name", "This name is already registered.");
            }

            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(existingCategory);
        }
        public IActionResult Edit(int id)

        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category CategoriesFromDb = _db.Categories.Find(id);
            if (CategoriesFromDb == null)
            {
                return NotFound();
            }
            return View(CategoriesFromDb);

        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            var existingCategory = _db.Categories.FirstOrDefault(c => c.Name == obj.Name);
            var existingDisplayOrder = _db.Categories.FirstOrDefault(c => c.DisplayOrder == obj.DisplayOrder);

            if (existingCategory != null )
            {
                ModelState.AddModelError("Name", "This name is already registered.");
            }
            if (existingDisplayOrder != null)
            {
                ModelState.AddModelError("DisplayOrder", "There is already an item ocuppying that order");
            }

            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(existingCategory);
        }

        public IActionResult Delete(int id)

        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category CategoriesFromDb = _db.Categories.Find(id);
            if (CategoriesFromDb == null)
            {
                return NotFound();
            }
            return View(CategoriesFromDb);

        }

        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
