using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandCreateUser;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandResetPassword;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdatePassword;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdateUser;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandVerifyUser;
using UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetProfile;
using UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetToken;

namespace UserCloneApp.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getProfile")]
        public async Task<IActionResult> GetProfile()
        {
            GetProfileQueryResponse queryResponse = await _mediator.Send(new GetProfileQueryRequest());
            if (queryResponse.Response != null) return CreateActionResult(queryResponse.Response);

            return CreateActionResult(queryResponse.Profile);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] GetTokenQueryRequest request)
        {
            GetTokenQueryResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.Response != null)  return CreateActionResult(commandResponse.Response);

            return CreateActionResult(commandResponse);           
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]       
        public async Task<IActionResult> Register([FromBody] CreateUserCommandRequest request)
        {
            CreateUserCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpPut]
        [Route("updateProfile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserCommandRequest request)
        {
            UpdateUserCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpPut]
        [Route("updatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest request)
        {
            UpdatePasswordCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpPut]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommandRequest request)
        {
            ResetPasswordCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);

        }

        [HttpPut]
        [Route("verify")]
        public async Task<IActionResult> Verify()
        {
            VerifyUserCommandResponse commandResponse = await _mediator.Send(new VerifyUserCommandRequest());
            return CreateActionResult(commandResponse.Response);
        }

    }
}
