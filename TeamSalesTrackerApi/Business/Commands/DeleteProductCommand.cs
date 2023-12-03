using MediatR;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class DeleteProductCommand : IRequest<ProductResult>
    {
        public long ProductId { get; set; }
        public DeleteProductCommand(long productId)
        {
            ProductId = productId;
        }
    }
}
