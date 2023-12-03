using MediatR;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class DeleteBranchCommand : IRequest<BranchResult>
    {
        public long BranchId { get; set; }
        public DeleteBranchCommand(long branchId)
        {
            BranchId = branchId;
        }
    }
}
