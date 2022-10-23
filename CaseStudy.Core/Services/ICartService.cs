using CaseStudy.Core.DTOs;

namespace CaseStudy.Core.Services
{
    public interface ICartService : IService<Cart>
    {
        Task<List<CartWithCartItemsDto>> GetCartsWitCartsItems();

        Task<Cart> GetCartByToken(string token);
    }
}
