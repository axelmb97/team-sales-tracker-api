using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamSalesTrackerApi.Controllers
{
    [Route("intervals")]
    [ApiController]
    public class IntervalsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IntervalsController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
