using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Business.Queries;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ProductResult> createProduct(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpPut]
        public async Task<ProductResult> updateProduct(UpdateProductCommand command) {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpGet]
        public async Task<ProductsResult> getAll() {
            var request = new GetAllProductsQuery();
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
