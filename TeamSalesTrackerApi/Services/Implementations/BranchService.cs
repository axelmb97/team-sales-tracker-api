using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Controllers;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Services.Implementations
{
    public class BranchService : IBranchService
    {
        private readonly SalesTrackerDB _data;
        private readonly IMapper _mapper;
        private readonly IPaginationService _pager;
        public BranchService(SalesTrackerDB data, IMapper mapper, IPaginationService pager)
        {
            _data = data;
            _mapper = mapper;
            _pager = pager;
        }

        public async Task<BranchDto> CreateBranch(CreateBranchCommand branchData)
        {
            var newAddress = _mapper.Map<Address>(branchData);
            newAddress.Apartment = "-";
            var newBranch = _mapper.Map<Branch>(branchData);
            newBranch.Address = newAddress;

            _data.Branches.Add(newBranch);
            await _data.SaveChangesAsync();
            return _mapper.Map<BranchDto>(newBranch);
        }

        public async Task<BranchDto> DeleteBranch(long branchId)
        {
            var branchToDelete = await _data.Branches.Include(b => b.Address)
                .FirstOrDefaultAsync(b => b.BranchId.Equals(branchId));
            _data.Branches.Remove(branchToDelete);
            await _data.SaveChangesAsync();

            _data.Addresses.Remove(branchToDelete.Address);
            await _data.SaveChangesAsync();
            BranchDto deletedBranch = new BranchDto
            {
                BranchId = branchId,
                Name = branchToDelete.Name,
                BranchNumber = branchToDelete.BranchNumber,
                AddressId = branchToDelete.Address.AddressId,
                StreetName = branchToDelete.Address.StreetName,
                StreetNumber = branchToDelete.Address.StreetNumber
            };
            return deletedBranch;
        }

        public async Task<bool> Exists(long branchNumber, string streetName, long streetNumber)
        {
            var branch = await _data.Branches.Include(b => b.Address)
                .FirstOrDefaultAsync(b => b.BranchNumber.Equals(branchNumber) && 
                                       b.Address.StreetName.ToUpper().Equals(streetName.ToUpper()) &&
                                       b.Address.StreetNumber.Equals(streetNumber));
            return branch != null;
        }

        public async Task<bool> ExistsByBranchIdAndAddressId(long branchNumber, long addressId)
        {
            var branch = await _data.Branches.Include(b => b.Address).FirstOrDefaultAsync(b => b.BranchId.Equals(branchNumber)
                && b.Address.AddressId.Equals(addressId));
            return branch != null;
        }

        public async Task<bool> ExistsById(long branchId)
        {
           var branch = await _data.Branches.Include(b => b.Address)
                .FirstOrDefaultAsync(b => b.BranchId.Equals(branchId));
            return branch != null;
        }

        public async Task<List<BranchDto>> GetAll()
        {
            List<BranchDto> branchesDto = new List<BranchDto>();
            var branches = await _data.Branches.Include(b => b.Address).ToListAsync();
            if (branches == null) return null;
            foreach (var b in branches)
            {
                branchesDto.Add(_mapper.Map<BranchDto>(b));
            }
            return branchesDto;
        }

        public async Task<BranchDto> GetById(long branchId)
        {
            var branch = await _data.Branches.Include(b => b.Address).FirstOrDefaultAsync(b => b.BranchId.Equals(branchId));
            if (branch == null) return null;
            return _mapper.Map<BranchDto>(branch);
        }

        public async Task<Pagination<BranchDto>> GetPaginatedProducts(BranchPaginationCommand paginationParams)
        {
            var query = _data.Branches.Include(a => a.Address);
            var branches = await _pager.CreatePageGenericResults<Branch>(
                query,
                paginationParams.PageNumber,
                paginationParams.pageSize,
                paginationParams.OrderBy,
                paginationParams.OrderAsc);
            var branchesDto = branches.Items.Select(b => _mapper.Map<BranchDto>(b)).ToList();

            var branchDtoPagination = new Pagination<BranchDto>();
            branchDtoPagination.PageNumber = paginationParams.PageNumber;
            branchDtoPagination.TotalPages = branches.TotalPages;
            branchDtoPagination.TotalItems = branches.TotalItems;
            branchDtoPagination.Items = branchesDto;

            return branchDtoPagination;
        }

        public async Task<BranchDto> UpdateBranch(UpdateBranchCommand branchData)
        {
            var branchToUpdate = await _data.Branches.Include(b => b.Address)
                .FirstOrDefaultAsync(b => b.BranchId.Equals(branchData.BranchId)
                && b.Address.AddressId.Equals(branchData.AddressId));
            branchToUpdate.BranchNumber = branchData.BranchNumber;
            branchToUpdate.Name = branchData.Name;
            branchToUpdate.Address.StreetName = branchData.StreetName;
            branchToUpdate.Address.StreetNumber = branchData.StreetNumber;
            branchToUpdate.Address.ZipCode = branchData.ZipCode;
            branchToUpdate.Address.Apartment = branchData.Apartment;
            _data.Branches.Update(branchToUpdate);
            await _data.SaveChangesAsync();
            return _mapper.Map<BranchDto>(branchToUpdate);
        }
    }
}
