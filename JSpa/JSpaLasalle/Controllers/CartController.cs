using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using JSpaLasalle.ViewModel;
using Microsoft.AspNet.Identity;

namespace JSpaLasalle.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository prodRepo;
        private IOrderRepository orderRepo;

        public CartController(IProductRepository prodRepository, IOrderRepository orderRepository )
        {
            prodRepo = prodRepository;
            orderRepo = orderRepository;
        }
        //
        // GET: /Cart/
        public ActionResult Index(Cart cart, string returnUrl)
        {
            CartIndexVM vm = new CartIndexVM
            {
                //Cart = GetCart(),
                Cart = cart,
                ReturnUrl = returnUrl,
                Categories = prodRepo.GetAllCategories()
            };
            return View(vm);
        }

        public RedirectToRouteResult AddToCart(Cart cart, string returnUrl, int productId = 0 )
        {
            Product product = prodRepo.GetProductDetails(productId);
            if (product != null)
            {
                //GetCart().AddItem(product, 1);
                int q = Convert.ToInt32(Request.Form["quantity"]);
                cart.AddItem(product, q);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = prodRepo.GetProductDetails(productId);
            if (product != null)
            {
                //GetCart().RemoveLine(product);
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [Authorize]
        public ActionResult SubmitOrder(Cart cart)
        {
            var username = User.Identity.GetUserName();
            CartSubmittedVM vm = new CartSubmittedVM
            {
                Categories = prodRepo.GetAllCategories(),
                order = orderRepo.ReceiveOrder(cart,username)
            };
            return View(vm);
        }

	}
}