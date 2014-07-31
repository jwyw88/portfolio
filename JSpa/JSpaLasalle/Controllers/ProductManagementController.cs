using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Concrete;
using Domain.Abstract;

namespace JSpaLasalle.Controllers
{
    public class ProductManagementController : Controller
    {
       //private JSpaLasalleDbContext db = new JSpaLasalleDbContext();
        private IProductRepository repo;

        public ProductManagementController(IProductRepository productRepo)
        {
            this.repo = productRepo;
        }

        // GET: /ProductManagement/
        public ActionResult Index()
        {
            
            return View(repo.GetAllProducts());
        }

        // GET: /ProductManagement/Details/5
        public ActionResult Details(int id = 0)
        {
           
            Product product = repo.GetProductDetails(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /ProductManagement/Create
        public ActionResult Create()
        {
            //ViewData["Category Name"] = new SelectList(repo.GetAllCategories().ToList(), "Category Name");
            //IEnumerable<SelectListItem> items = repo.GetAllCategories().Select(c => new SelectListItem
            //{
            //    Value = c.CategoryId.ToString(),
            //    Text = c.Name
            //});

            //ViewData["Category Name"] = items;
            ViewBag.CategoryId = new SelectList(repo.GetAllCategories(), "CategoryId", "Name");

            return View();
        }

        // POST: /ProductManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductID,Name,CategoryID,Description,Price,PictureName,SpecialPrice,IsDiscontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.AddProduct(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(repo.GetAllCategories(), "CategoryId", "Name", product.CategoryId);       
            return View(product);
        }

        // GET: /ProductManagement/Edit/5
        public ActionResult Edit(int id = 0)
        {
            

            Product product = repo.GetProductDetails(id);
            ViewBag.CategoryId = new SelectList(repo.GetAllCategories(), "CategoryId", "Name", product.CategoryId);
            if (product == null)
            {
                return HttpNotFound();
            }
            
            return View(product);
        }

        // POST: /ProductManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProductID,Name,CategoryId,Description,Price,PictureName,SpecialPrice,IsDiscontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.EditProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(repo.GetAllCategories(), "CategoryId", "Name", product.CategoryId);        
            return View(product);
        }

       // GET: /ProductManagement/Discontinue/5
        public ActionResult Discontinue(int id = 0)
        {
            

            Product product = repo.GetProductDetails(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /ProductManagement/Discontinue/5
        [HttpPost, ActionName("Discontinue")]
        [ValidateAntiForgeryToken]
        /*public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/
        public ActionResult Discontinue([Bind(Include = "ProductID,Name,CategoryID,Description,Price,PictureName,SpecialPrice,IsDiscontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.DiscontinueProduct(product);
                return RedirectToAction("Index");
            }
           
            return View(product);
        }


        public Product p { get; set; }


        
    }
}
