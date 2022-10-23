using Microsoft.EntityFrameworkCore;
using CaseStudy.Core;
using CaseStudy.Core.Repositories;

namespace CaseStudy.Data.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Cart> GetCartByToken(string token)
        {
            return await _context.Carts.Where(i=>i.Token.Equals(token)).SingleOrDefaultAsync();
        }

        public async Task<List<Cart>> GetCartsWitCartsItems()
        {
            return await _context.Carts.Include(x => x.CartItems).ToListAsync();
        }
    }
}
