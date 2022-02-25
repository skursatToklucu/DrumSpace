using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Menus.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Menus.Queries.GetMenuDetailById
{
    public class GetMenuDetailByIdQuery : IRequest<SingleResponse<MenuDto>>
    {
        public int Id { get; set; }
    }
}