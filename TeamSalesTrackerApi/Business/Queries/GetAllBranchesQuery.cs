using MediatR;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Queries
{
    public class GetAllBranchesQuery : IRequest<BranchesResult>
    {
    }
}
