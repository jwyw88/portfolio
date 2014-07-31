using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace JSpaLasalle.ViewModel
{
    public class CartSubmittedVM
    {
        //public string ReturnUrl { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Order order { get; set; }
    }
}