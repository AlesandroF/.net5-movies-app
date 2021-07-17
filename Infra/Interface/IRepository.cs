using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity, int id);
        Task DeleteAsync(int id);
    }
}