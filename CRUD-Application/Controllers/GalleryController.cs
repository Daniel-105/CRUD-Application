using CRUD_Application.Data;
using CRUD_Application.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

public class GalleryController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public GalleryController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        List<Gallery> objCategories = _context.Gallery.ToList();
        return View(objCategories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] // Defining that this action is of the type POST
    public IActionResult Create(Gallery gallery, IFormFile? file)
    {
        // associating the path for the wwwroot (/) with the variable wwwRootPath
        string wwwRootPath = _webHostEnvironment.WebRootPath;
        if (file != null)
        {
            //Creating a new Guid and conserting it to a string 
            // Then concatnate that with the extention of the file (.jpeg, .pdf, etc...)
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string productPath = Path.Join(wwwRootPath, @"images\gallery");

            // Check if there is an image loaded
            if (!string.IsNullOrEmpty(gallery.ImageURL))
            {
                //Delete the old image
                var oldImagePath = Path.Join(wwwRootPath, gallery.ImageURL.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            gallery.ImageURL = @"\images\gallery\" + fileName;
        }
        if (gallery.Id == 0)
        {
            // Stages the post
            _context.Add(gallery);
        }
        else
        {
            _context.Update(gallery);
        }
        // Push the post to the database
        _context.SaveChanges();
        TempData["success"] = "Category Updated Successfully";
        return RedirectToAction("Index");
    }
    public IActionResult Edit(int? id)
    {
        Gallery gallery = _context.Gallery.FirstOrDefault(g => g.Id == id);
        if (gallery == null)
        {
            return NotFound();
        }
        return View(gallery);
    }

    [HttpPost] // Defining that this action is of the type POST
    public IActionResult Edit(Gallery gallery, IFormFile? file)
    {
        // associating the path for the wwwroot (/) with the variable wwwRootPath
        string wwwRootPath = _webHostEnvironment.WebRootPath;
        if (file != null)
        {
            //Creating a new Guid and conserting it to a string 
            // Then concatnate that with the extention of the file (.jpeg, .pdf, etc...)
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string productPath = Path.Join(wwwRootPath, @"images\gallery");

            // Check if there is an image loaded
            if (!string.IsNullOrEmpty(gallery.ImageURL))
            {
                //Delete the old image
                var oldImagePath = Path.Join(wwwRootPath, gallery.ImageURL.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            gallery.ImageURL = @"\images\gallery\" + fileName;
        }
        if (gallery.Id == 0)
        {
            // Stages the post
            _context.Add(gallery);
        }
        else
        {
            _context.Update(gallery);
        }
        // Push the post to the database
        _context.SaveChanges();
        TempData["success"] = "Category Updated Successfully";
        return RedirectToAction("Index");
    }


}
