namespace CaseStudy.Core.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<List<Cart>> GetCartsWitCartsItems();
        Task<Cart> GetCartByToken(string token);
    }
}
