using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace JSpaLasalle.ViewModel
{
    public class ProductDetailVM
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}