using DrumSpace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DrumSpace.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<CommentPost> CommentPosts { get; set; }
        DbSet<Menu> Menus { get; set; }
        DbSet<MenuRole> MenuRoles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}