using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using JSpaLasalle.ViewModel;

namespace JSpaLasalle.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private IProductRepository repo;

        public ProductController(IProductRepository productRepo)
        {
            this.repo = productRepo;
        }

        //
        // GET: /Product/List

        public ActionResult List(string category)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repo.GetAllProducts()
                .Where(p => category == null || p.Category.Name == category),
                //Categories = repo.GetAllProducts()
                //    .Select(p => p.Category.Name)
                //    .Distinct()
                Categories = repo.GetAllCategories()
            };
            return View(model);
            //IEnumerable<Product> products = repo.GetAllProducts()
            //    .Where(p => p.Category.Name == category || category == null);
            //return View(products);
                  
        }

        //GET: /Product/Details/5

        public ViewResult Details(int id = 0)
        {
            ProductDetailVM model = new ProductDetailVM
            {
                Product = repo.GetProductDetails(id),
                Categories = repo.GetAllCategories()
            };
            return View(model);
        }

	}
}