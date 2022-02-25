using System.Threading.Tasks;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Menus.Commands.AssignRoleToMenu;
using DrumSpace.Application.Menus.Commands.CreateMenu;
using DrumSpace.Application.Menus.Commands.DeleteMenu;
using DrumSpace.Application.Menus.Commands.UpdateMenu;
using DrumSpace.Application.Menus.Queries.Dtos;
using DrumSpace.Application.Menus.Queries.GetMenuDetailById;
using DrumSpace.Application.Menus.Queries.GetMenusWithPagination;
using DrumSpace.Application.Menus.Queries.GetMenuWithCategorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    public class MenuController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetMenusWithPaginationQuery query)
        {
            PagedResponse<MenuDto> pagedResponse = await Mediator.Send(query);
            return pagedResponse.ToHttpResponse();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuCommand command)
        {
            SingleResponse<int> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMenuCommand command)
        {
            if (id != command.Id) return BadRequest();

            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(new DeleteMenuCommand {Id = id});
            return singleResponse.ToHttpResponse();
        }

        [HttpPost("{menuId}")]
        public async Task<IActionResult> AssignUserToRoles(int menuId, [FromBody] AssignRoleToMenuCommand command)
        {
            if (menuId != command.MenuId)
            {
                return BadRequest();
            }

            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDetailById(int id)
        {
            SingleResponse<MenuDto> singleResponse = await Mediator.Send(new GetMenuDetailByIdQuery
            {
                Id = id
            });
            return singleResponse.ToHttpResponse();
        }

        [HttpGet("get-menus-relation")]
        public async Task<IActionResult> GetMenusWithRelation()
        {
            ListResponse<MenuCategorizeDto> listResponse = await Mediator.Send(new GetMenuWithCategorizationQuery());
            return listResponse.ToHttpResponse();
        }
    }
}