using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain.Interfaces
{
    public interface IAdd<TEntity>
    {
        Task<TEntity> Add(TEntity entity);
    }
}
