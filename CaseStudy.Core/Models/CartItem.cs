using CaseStudy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core
{
    public class CartItem: BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public Cart Cart { get; set; }
    }
}
