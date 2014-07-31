using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;


namespace JSpaLasalle.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //put bindings here
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.GetAllProducts()).Returns(new List<Product>
            //{
            //    new Product {  
            //        ProductID = 0, 
            //        Name = "Skin Moisturizing Repair", 
            //        Price = 25M, 
            //        CategoryID = 0,
            //        Description = "A must product for oily skin and comedonal acne-prone skin", 
            //    },
            //    new Product {
            //        ProductID = 1, 
            //        Name = "Moisturizing Body Milk", 
            //        Price = 35M, 
            //        CategoryID = 1,
            //        Description = "with a delicious aroma of lavender and white lotus is a must in every bathroom.",
            //    },
            //    new Product { 
            //        ProductID = 2, 
            //        Name = "Douceur Extrême Treatment Hand Cream", 
            //        Price = 45M, 
            //        CategoryID = 2,
            //        Description = "Moisturizing hand cream for dry, rough and sensitive skin.",
            //    }
            //});

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
        }
    }
}