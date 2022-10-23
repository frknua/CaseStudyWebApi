using AutoMapper;
using CaseStudy.Core;
using CaseStudy.Core.DTOs;
using CaseStudy.Core.Repositories;
using CaseStudy.Core.Services;
using CaseStudy.Core.UnitOfWorks;

namespace CaseStudy.Service.Services
{
    public class CartService : Service<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public CartService(IUnitOfWork unitOfWork, IRepository<Cart> repository, IMapper mapper, ICartRepository cartRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<Cart> GetCartByToken(string token)
        {
            return await _cartRepository.GetCartByToken(token);
        }

        public async Task<List<CartWithCartItemsDto>> GetCartsWitCartsItems()
        {
            var carts = await _cartRepository.GetCartsWitCartsItems();
            var cartsDto = _mapper.Map<List<CartWithCartItemsDto>>(carts);
            return cartsDto;
        }
    }
}