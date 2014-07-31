using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public DateTime? CompleteDate { get; set; }
        public List<OrderDetail> OrderDetails {get;set;}
    }

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order order { get; set; }
    }
}
