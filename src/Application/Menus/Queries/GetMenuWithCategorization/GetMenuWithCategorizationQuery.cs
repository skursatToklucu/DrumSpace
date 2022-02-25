using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Menus.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Menus.Queries.GetMenuWithCategorization
{
    public class GetMenuWithCategorizationQuery : IRequest<ListResponse<MenuCategorizeDto>>
    {
    }
}