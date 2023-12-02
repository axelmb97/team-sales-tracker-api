using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Results.Auth;

namespace TeamSalesTrackerApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<RegisterResult> userRegister(RegisterUserCommand command) {
            var reult = await _mediator.Send(command);
            return reult;
        }
    }
}
