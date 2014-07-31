using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Domain.Entities
{
    public class JSpaLasalleDbInitializer : DropCreateDatabaseAlways<JSpaLasalleDbContext>
    {
        protected override void Seed(JSpaLasalleDbContext context)
        {
            var catgories = new List<Category>
            {
                new Category {Name = "Facial"},
                new Category { Name = "Body"},
                new Category {Name = "Hand"},
                new Category {Name ="Foot"}
            };
            

            new List<Product>
            {
                new Product {  
                    Name = "Skin Moisturizing Repair", 
                    Price = 25M, 
                    Description = "A must product for oily skin and comedonal acne-prone skin", 
                    Category = catgories.Single(c=>c.Name == "Facial" ),
                    PictureName = "/images/p0.png"
                },
                new Product {
                    Name = "Moisturizing Body Milk", 
                    Price = 35M, 
                    Description = "with a delicious aroma of lavender and white lotus is a must in every bathroom.",
                    Category = catgories.Single(c=>c.Name == "Body"),
                    PictureName = "/images/p1.png"
                },
                new Product { 
                    Name = "Douceur Extrême Treatment Hand Cream", 
                    Price = 45M, 
                    Description = "Moisturizing hand cream for dry, rough and sensitive skin.",
                    Category = catgories.Single(c=>c.Name == "Hand"),
                    PictureName = "/images/p2.png"
                },
                new Product {
                    Name = "Moisturizing Foot Milk", 
                    Price = 35M, 
                    Description = "with a delicious aroma of lavender and white lotus is a must in every bathroom.",
                    Category = catgories.Single(c=>c.Name == "Foot"),
                    PictureName = "/images/p4.png",
                    IsDiscontinued = true
                }
             }.ForEach(p => context.Products.Add(p));

        }
    }
}
