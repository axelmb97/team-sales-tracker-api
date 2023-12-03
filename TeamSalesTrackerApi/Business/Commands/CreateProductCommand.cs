using MediatR;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class CreateProductCommand : IRequest<ProductResult>
    {
        public string Name { get; set; }
        public string Remarks { get; set; }
    }
}
