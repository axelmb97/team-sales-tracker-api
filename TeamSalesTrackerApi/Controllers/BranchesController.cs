using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Controllers
{
    [Route("branches")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BranchesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<BranchResult> createBranch(CreateBranchCommand command) {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
