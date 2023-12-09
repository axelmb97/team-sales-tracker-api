using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Domain.Interfaces;

namespace TeamSalesTracker.Application.Interfaces
{
    public interface IUserService<TEntity, TEntityEmail> : IAdd<TEntity>
    {
        Task<TEntity> GetByEmail(TEntityEmail entityEmail);
    }
}
