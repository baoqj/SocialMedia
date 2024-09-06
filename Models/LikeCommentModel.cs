using System;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class LikeCommentModel
    {
        [Key]
        public string LikeId { get; set; }

        [Required]
        public string CommentId { get; set; }  // The ID of the comment being liked

        [Required]
        public string UserId { get; set; }  // The ID of the user who liked the comment

        public DateTime LikedAt { get; set; } = DateTime.UtcNow;  // Timestamp for when the like occurred
    }
}
