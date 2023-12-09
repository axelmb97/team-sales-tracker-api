using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain.Interfaces
{
    public interface IBaseRepository<TEntity,TEntityID>
         : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntity, TEntityID>, IGet<TEntity,TEntityID>, ITransaction
    {
    }
}
