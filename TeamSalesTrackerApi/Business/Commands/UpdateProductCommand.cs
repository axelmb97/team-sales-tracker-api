using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class UpdateProductCommand : IRequest<ProductResult>
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
    }
}
