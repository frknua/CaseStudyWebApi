using CaseStudy.Core;
using CaseStudy.Core.Repositories;
using CaseStudy.Core.Services;
using CaseStudy.Core.UnitOfWorks;

namespace CaseStudy.Service.Services
{
    public class CartItemService : Service<CartItem>, ICartItemService
    {
        public CartItemService(IUnitOfWork unitOfWork, IRepository<CartItem> repository) : base(unitOfWork, repository)
        {
        }
    }
}
