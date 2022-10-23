namespace CaseStudy.Core.DTOs
{
    public class CartWithCartItemsDto: CartDto
    {
        public List<CartItemDto> CartItems { get; set; }

        public double TotalPrice { get; set; } = 0;
    }
}
