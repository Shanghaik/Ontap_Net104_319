using Microsoft.AspNetCore.Mvc;
using Ontap_Net104_319.Models;

namespace Ontap_Net104_319.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _context;
        public ProductController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Index()
        {
            var data = _context.Products.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var editItem = _context.Products.Find(id);
            return View(editItem);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var editItem = _context.Products.Find(product.Id);  
            editItem.Name = product.Name;
            editItem.Description = product.Description;
            _context.Products.Update(editItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            var editItem = _context.Products.Find(id);
            _context.Remove(editItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
