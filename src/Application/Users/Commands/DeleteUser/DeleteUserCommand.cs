using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<SingleResponse<bool>>
    {
        public string UserId { get; set; }
    }
}