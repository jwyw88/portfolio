using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string Name { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string PictureName { get; set; }
        public virtual decimal SpecialPrice { get; set; }
        public virtual bool IsDiscontinued { get; set; }
        public virtual Category Category { get; set; }
    }
}
