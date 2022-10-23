using System.Linq.Expressions;
namespace CaseStudy.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);       

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        T Update(T entity);

        void Remove(int id);
    }
}
