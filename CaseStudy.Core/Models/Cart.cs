using CaseStudy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core
{
    public class Cart: BaseEntity
    {
        public string Token { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = null!;
    }
}
