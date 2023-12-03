using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Controllers
{
    [Route("sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
    }
}
