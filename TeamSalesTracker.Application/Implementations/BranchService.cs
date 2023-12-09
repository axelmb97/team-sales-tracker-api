using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Application.Interfaces;
using TeamSalesTracker.Domain;
using TeamSalesTracker.Domain.Interfaces;

namespace TeamSalesTracker.Application.Implementations
{
    public class BranchService : IBaseService<Branch, long>
    {
        private readonly IBaseRepository<Branch, long> _branchRepository;
        private readonly IAddressRepository<Address, long> _addressRepository;
        public BranchService(IBaseRepository<Branch, long> branchRepository, IAddressRepository<Address, long> addressRepository)
        {
            _branchRepository = branchRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Branch> Add(Branch entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Branch> Delete(long entityId)
        {
            var branch = await _branchRepository.GetById(entityId);
            await _addressRepository.Delete(entityId);
            await _branchRepository.Delete(branch.Address.AddressId);
            await _branchRepository.Save();
            return branch;
        }

        public async Task<Branch> Edit(Branch entity)
        {
            if(entity == null)
                throw new ArgumentNullException("La sucursal es requerida");
            await _addressRepository.Edit(entity.Address);
            var updatedBranch = await _branchRepository.Edit(entity);
            await _branchRepository.Save();
            return updatedBranch;
        }

        public async Task<List<Branch>> GetAll()
        {
            return await _branchRepository.GetAll();
        }

        public async Task<Branch> GetById(long entityId)
        {
            return await _branchRepository.GetById(entityId);
        }
    }
}
