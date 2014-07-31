using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private JSpaLasalleDbContext db = new JSpaLasalleDbContext();

        public IEnumerable<Order> GetOrders(string status = null)
        {
            if (status == null)
            {
               return db.Orders;
            }
            else
            {
                return db.Orders.Where(o => o.Status == status);
            }
        }


        public Order GetOrderDetails(int id)
        {
           Order o = db.Orders.Include("OrderDetails").Where( od => od.OrderId==id).FirstOrDefault();
            if (o == null)
            {
                throw new ArgumentException("Order not found");
            }
            return o;
        }

        public Order ReceiveOrder(Cart cart, string username)
        {
            var order = new Order{ 
                Username = username,
                OrderDate = DateTime.Now,
                Status = "Received",
                Total = cart.ComputeTotal(),
                //CompleteDate = new DateTime(1900,1,1)          
            };

           db.Orders.Add(order);
           
           AddOrderDetails(order, cart);
           db.SaveChanges();

           cart.Clear();

           return order;
        }

        public void AddOrderDetails(Order order, Cart cart) 
        {
            
            var cartItems = cart.lineCollection.ToList();
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = item.Product.ProductId,
                    Quantity = item.Quantity
                };
                db.OrderDetails.Add(orderDetail);
            }                
            db.SaveChanges();
           
        }

        public int ChangeOrderStatus(int id, string status)
        {
            Order o = db.Orders.Find(id);
            o.Status = status;
            if (status == "Completed")
            {
                o.CompleteDate = DateTime.Now;
            }
            db.SaveChanges();
            return o.OrderId;
        }
    }
}
