using MediatR;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Results.Pagination;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class BranchPaginationCommand : PaginationCommand, IRequest<PaginationResult<BranchDto>>
    {
       
        public BranchPaginationCommand():base()
        {

        }
    }
}
