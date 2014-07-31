using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace JSpaLasalle.ViewModel
{
    public class OrderListVM
    {
        public IEnumerable<Order> Orders { get; set; }
        public int CountOfAll { get; set; }
        public int CountOfReceived { get; set; }
        public int CountOfProcessing { get; set; }
        public int CountOfReady { get; set; }
        public int CountOfCompleted { get; set; }
        public string ListTitle { get; set; }
        public string ReturnUrl { get; set; }
    }
}