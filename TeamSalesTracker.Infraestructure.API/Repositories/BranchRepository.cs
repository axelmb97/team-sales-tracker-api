using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Domain;
using TeamSalesTracker.Domain.Interfaces;
using TeamSalesTracker.Infraestructure.Data.Contexts;

namespace TeamSalesTracker.Infraestructure.Data.Repositories
{
    public class BranchRepository : IBaseRepository<Branch, long>
    {
        private readonly TeamSaleTrackerData _data;
        public BranchRepository(TeamSaleTrackerData data)
        {
            _data = data;
        }

        public async Task<Branch> Add(Branch entity)
        {
            await _data.Branches.AddAsync(entity);
            return entity;
        }

        public async Task<Branch> Delete(long entityId)
        {
            var branch = await _data.Branches.FirstOrDefaultAsync(b => b.BranchId.Equals(entityId));
            if (branch != null) {
                _data.Branches.Remove(branch);
            }
            return branch;
        }

        public async Task<Branch> Edit(Branch entity)
        {
            var branch = await _data.Branches.FirstOrDefaultAsync(b => b.BranchId.Equals(entity.BranchId));
            if (branch != null) {
                branch.Name = entity.Name;
                branch.BranchNumber = entity.BranchNumber;
                _data.Entry(branch).State = EntityState.Modified;
                _data.Branches.Update(branch);
            }
            return branch;
        }

        public async Task<List<Branch>> GetAll()
        {
            return await _data.Branches.Include(b => b.Address).ToListAsync();
        }

        public async Task<Branch> GetById(long entityId)
        {
            var branch = await _data.Branches.FirstOrDefaultAsync(b => b.BranchId.Equals(entityId));
            return branch;
        }

        public async Task Save()
        {
            await _data.SaveChangesAsync();
        }
    }
}
