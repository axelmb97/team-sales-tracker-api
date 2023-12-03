using MediatR;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Queries
{
    public class GetBranchByIdQuery : IRequest<BranchResult>
    {
        public long BranchId { get; set; }
        public GetBranchByIdQuery(long branchId)
        {
            BranchId = branchId;
        }
    }
}
