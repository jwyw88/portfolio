using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public virtual int CategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Product> Products { get; set; }
        
    }
}
