using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for your models. For example:
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<PostModel> PostModels { get; set; }
        public DbSet<LikeModel> LikeModels { get; set; }
        public DbSet<FollowModel> FollowModels { get; set; }
        public DbSet<CommentModel> CommentModels { get; set; }

        // Add the DbSet for LikeCommentModel
        public DbSet<LikeCommentModel> LikeCommentModels { get; set; }
    }
}
