using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Business.Queries;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Pagination;
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
        [HttpGet]
        [Route("{id}")]
        public async Task<ProductResult> getById(long id) {
            var request = new GetProductByIdQuery(id);
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpDelete]
        public async Task<ProductResult> deleteProduct(long id) {
            var request = new DeleteProductCommand(id);
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        [Route("paginated")]
        public async Task<PaginationResult<Product>> GetPagination([FromQuery] ProductPaginationCommand command) {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
