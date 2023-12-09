using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain.Interfaces
{
    public interface IUserRepository<TEntity, TEntityEmail>
        : IAdd<TEntity>, ITransaction
    {
        Task<TEntity> GetByEmail(TEntityEmail email);
    }
}
