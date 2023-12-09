﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain.Interfaces
{
    public interface IGet<TEntity, TEntityID>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(TEntityID entityId);
    }
}
