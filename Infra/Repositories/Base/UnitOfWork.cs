using System.Threading.Tasks;
using Infra.Context;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MoviesContext _context;

        public UnitOfWork(MoviesContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            var commited = true;
            if (!_context.HasChanges())
                return false;

            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using var dbContextTransaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    await _context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch
                {
                    await dbContextTransaction.RollbackAsync();
                    commited = false;
                }
            });
            
            return commited;
        }
    }
}