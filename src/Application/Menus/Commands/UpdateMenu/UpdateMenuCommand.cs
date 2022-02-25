using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Menus.Commands.UpdateMenu
{
    public class UpdateMenuCommand : IRequest<SingleResponse<bool>>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Path { get; set; }

        public int ParentId { get; set; }

    }
}