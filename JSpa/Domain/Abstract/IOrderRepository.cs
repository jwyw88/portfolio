using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders(string status=null);
        Order GetOrderDetails(int id);
        Order ReceiveOrder(Cart cart, string username);
        int ChangeOrderStatus(int orderId, string status);
    }
}
