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
    [Authorize(Roles = "Admin")]
    public class OrderManagementController : Controller
    {
        private IProductRepository prodRepo;
        private IOrderRepository orderRepo;

        public OrderManagementController(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this.prodRepo = productRepository;
            this.orderRepo = orderRepository;
        }
        
        //
        // GET: /OrderManagement/
        public ActionResult Index(string status = null)
        {
            string t;
            switch (status)
            {
                
                case "Received":
                    t = "New Order List";
                    break;
                case "Processing":
                    t = "  In Processing Order List";
                    break;
                case "Ready":
                    t = "Ready for Pickup Order List";
                    break;
                default:
                    t = "All Order List";
                    break;
            }

            OrderListVM vm = new OrderListVM {
                Orders = orderRepo.GetOrders(status),
                CountOfAll = orderRepo.GetOrders().Count(),
                CountOfReceived = 0,
                CountOfProcessing = 0,
                CountOfReady = 0,
                CountOfCompleted = 0,
                ListTitle = t
            };
            return View(vm);
        }


        public ActionResult GetOrderDetails(string returnUrl, int id=0)
        {
            Order o = orderRepo.GetOrderDetails(id);
            ViewBag.ReturnList = returnUrl;
            return View(o);
        }

        public ActionResult ChangeStatus(int id, string status, string returnList)
        {
                var orderId = orderRepo.ChangeOrderStatus(id, status);
                return RedirectToAction("GetOrderDetails", new { returnUrl = returnList, id = orderId });
        }
     
	}
}