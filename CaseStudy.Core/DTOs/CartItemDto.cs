namespace CaseStudy.Core.DTOs
{
    public class CartItemDto: BaseDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
