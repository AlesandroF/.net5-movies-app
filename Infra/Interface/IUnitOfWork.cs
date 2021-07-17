using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}