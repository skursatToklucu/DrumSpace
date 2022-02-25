using DrumSpace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrumSpace.Infrastructure.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentPost>
    {
        public void Configure(EntityTypeBuilder<CommentPost> builder)
        {
        }
    }
}