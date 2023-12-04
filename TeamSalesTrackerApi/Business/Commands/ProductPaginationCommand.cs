using MediatR;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Pagination;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class ProductPaginationCommand : PaginationCommand, IRequest<PaginationResult<Product>>
    {
        public ProductPaginationCommand() : base()
        {

        }
        
    }
}
