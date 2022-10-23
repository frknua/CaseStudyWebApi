using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.DTOs
{
    public class CartItemUpdateDto
    {
        public int Id { get; set; }

        public byte Quantity { get; set; }
    }
}
