using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using System.Data.Entity;


namespace Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private JSpaLasalleDbContext db = new JSpaLasalleDbContext();

        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories;
        }

        public Product GetProductDetails(int id)
        {
            Product p = db.Products.Find(id);
            if (p == null)
            {
                throw new ArgumentException("Product not found");
            }
            return p;
        }

        public Product AddProduct(Product p)
        {
            if (p == null)
            {
                throw new ArgumentException("product");
            }
            db.Products.Add(p);
            db.SaveChanges();
            return p;
        }

        public void EditProduct(Product p)
        {
            if (p == null)
            {
                throw new ArgumentException("product");
            }
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DiscontinueProduct(Product p)
        {
            if (p == null)
            {
                throw new ArgumentException("product");
            }
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
