using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CaseStudy.Core.DTOs
{
    public class CartItemAddDto
    {
        public string Token { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]
        public byte Quantity { get; set; } = 1;

        [JsonIgnore]
        public int CartId { get; set; }
    }
}
