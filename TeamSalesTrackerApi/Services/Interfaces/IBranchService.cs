using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Dtos;

namespace TeamSalesTrackerApi.Services.Interfaces
{
    public interface IBranchService
    {
        Task<bool> Exists(long branchNumber, string streetName, long streetNumber);
        Task<bool> ExistsById(long branchId);
        Task<bool> ExistsByBranchIdAndAddressId(long branchNumber, long addressId);
        Task<List<BranchDto>> GetAll();
        Task<BranchDto> GetById(long branchId);
        Task<BranchDto> CreateBranch(CreateBranchCommand branchData);
        Task<BranchDto> UpdateBranch(UpdateBranchCommand branchData);
        Task<BranchDto> DeleteBranch(long branchId);
    }
}
