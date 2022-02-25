using System.Threading.Tasks;
using DrumSpace.Application.CommentPosts.Commands.CreateCommentPosts;
using DrumSpace.Application.CommentPosts.Queries.Dtos;
using DrumSpace.Application.CommentPosts.Queries.GetCommentPostsWithPagination;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Posts.Commands.CreatePost;
using DrumSpace.Application.Posts.Commands.DeletePost;
using DrumSpace.Application.Posts.Commands.UpdatePost;
using DrumSpace.Application.Posts.Queries.Dtos;
using DrumSpace.Application.Posts.Queries.GetPostDetailById;
using DrumSpace.Application.Posts.Queries.GetPostsWithPagination;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    public class PostsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPostsWithPaginationQuery query)
        {
            PagedResponse<PostDto> pagedResponse = await Mediator.Send(query);
            return pagedResponse.ToHttpResponse();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand command)
        {
            SingleResponse<int> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePostCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(new DeletePostCommand { Id = id });
            return singleResponse.ToHttpResponse();
        }

        [HttpPost]
        [Route("{postId:int}/comments")]
        public async Task<IActionResult> AddComment(int postId, [FromBody] CreateCommentPost command)
        {
            if (postId != command.PostId) return BadRequest();

            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpGet]
        [Route("{postId:int}/comments")]
        public async Task<IActionResult> Comments(int postId, [FromQuery] GetCommentPostsWithPaginationQuery query)
        {
            // if (postId != query.PostId) return BadRequest();
            query.PostId = postId;
            PagedResponse<CommentPostsDto> pagedResponse = await Mediator.Send(query);
            return pagedResponse.ToHttpResponse();
        }

        [HttpGet]
        [Route("{postId:int}")]
        public async Task<IActionResult> Detail(int postId)
        {
            SingleResponse<PostDetailDto> singleResponse = await Mediator.Send(new GetPostDetailByIdQuery
            {
                Id = postId
            });

            return singleResponse.ToHttpResponse();
        }
    }
}