using TeamSalesTrackerApi.Dtos;

namespace TeamSalesTrackerApi.Results.Branches
{
    public class BranchesResult : BaseResult
    {
        public List<BranchDto> Branches { get; set; } = new List<BranchDto>();
    }
}
