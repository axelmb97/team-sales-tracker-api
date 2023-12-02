using MediatR;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Business.Queries
{
    public class GetAllProductsQuery : IRequest<ProductsResult>
    {
    }
}
