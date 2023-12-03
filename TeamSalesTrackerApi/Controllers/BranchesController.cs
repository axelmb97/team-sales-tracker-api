using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Business.Queries;
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
        [HttpGet]
        public async Task<BranchesResult> GetAll() {
            var request = new GetAllBranchesQuery();
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<BranchResult> GetById(long id)
        {
            var request = new GetBranchByIdQuery(id);
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpPost]
        public async Task<BranchResult> CreateBranch(CreateBranchCommand command) {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpPut]
        public async Task<BranchResult> UpdateBranch(UpdateBranchCommand command) {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<BranchResult> DeleteBranch(long id) {
            var request = new DeleteBranchCommand(id);
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
