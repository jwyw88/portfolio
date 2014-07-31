using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Category> GetAllCategories();
        Product GetProductDetails(int ProductID);
        Product AddProduct(Product p);
        void EditProduct(Product p);
        void DiscontinueProduct(Product p);
        
    }
    
}
