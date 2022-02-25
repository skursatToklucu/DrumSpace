using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Menus.Commands.DeleteMenu
{
    public class DeleteMenuCommand : IRequest<SingleResponse<bool>>
    {
        public int Id { get; set; }
    }
}