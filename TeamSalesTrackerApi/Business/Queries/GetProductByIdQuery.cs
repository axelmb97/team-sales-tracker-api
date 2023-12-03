using MediatR;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Business.Queries
{
    public class GetProductByIdQuery : IRequest<ProductResult>
    {
        public long ProductId { get; set; }
        public GetProductByIdQuery(long productId)
        {
            ProductId = productId;
        }
    }
}
