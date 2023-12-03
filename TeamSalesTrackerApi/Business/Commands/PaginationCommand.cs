using MediatR;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Pagination;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class PaginationCommand : IRequest<PaginationResult<Product>>
    {
        public int PageNumber { get; set; } = 0;
        public int pageSize { get; set; } = 15;
        public string? OrderBy { get; set; }
        public bool OrderAsc { get; set; } = true;
        public PaginationCommand()
        {

        }
        
    }
}
