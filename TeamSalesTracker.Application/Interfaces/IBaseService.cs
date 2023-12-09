using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Domain.Interfaces;

namespace TeamSalesTracker.Application.Interfaces
{
    public interface IBaseService<TEntity, TEntityID> 
        : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntity,TEntityID>, IGet<TEntity, TEntityID>
    {
    }
}
