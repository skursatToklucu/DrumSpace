using System.Threading.Tasks;
using DrumSpace.Application.Accounts.Commands.ConfirmEmail;
using DrumSpace.Application.Accounts.Commands.Login;
using DrumSpace.Application.Accounts.Commands.Register;
using DrumSpace.Application.Accounts.Commands.VerificationCode;
using DrumSpace.Application.Common.Models.Response;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    public class AccountController : ApiControllerBase
    {

        [HttpPost]
        [Route("register", Name = nameof(Register))]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            SingleResponse<bool> response = await Mediator.Send(command);
            return response.ToHttpResponse();
        }

        [HttpPost]
        [Route("login", Name = nameof(Login))]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            SingleResponse<string> response = await Mediator.Send(command);
            return response.ToHttpResponse();
        }

        [HttpGet]
        [Route("confirm-email", Name = nameof(ConfirmEmail))]
        public async Task<ActionResult<bool>> ConfirmEmail([FromQuery] ConfirmCommand command) => await Mediator.Send(command);

        [HttpGet("verification")]
        public async Task<ActionResult<bool>> Verification([FromQuery] VerificationCodeQuery query)
        {
            return await Mediator.Send(new VerificationCodeQuery
            {
                VerificationCode = query.VerificationCode
            });
        }
    }
}