using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Business.Queries;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Results.Branches;
using TeamSalesTrackerApi.Results.Pagination;

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
        [Authorize(Roles = "ADMIN, ENCARGADO/A")]
        public async Task<BranchResult> CreateBranch(CreateBranchCommand command) {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpPut]
        [Authorize(Roles = "ADMIN, ENCARGADO/A")]
        public async Task<BranchResult> UpdateBranch(UpdateBranchCommand command) {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "ADMIN, ENCARGADO/A")]
        public async Task<BranchResult> DeleteBranch(long id) {
            var request = new DeleteBranchCommand(id);
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        [Route("paginated")]
        public async Task<PaginationResult<BranchDto>> GetPaginatedBraches([FromQuery]BranchPaginationCommand command) {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
