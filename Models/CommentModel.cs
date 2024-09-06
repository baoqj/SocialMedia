// Defines comments data

using System;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class CommentModel
    {
        [Key]  // Primary key for the comment
        public string CommentId { get; set; }

        [Required]
        public string PostId { get; set; }  // The ID of the post that this comment is related to

        [Required]
        public string UserId { get; set; }  // The ID of the user who made the comment

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }  // The content of the comment

        public DateTime CreatedAt { get; set; }  // Timestamp when the comment was created

        public DateTime? UpdatedAt { get; set; }  // Timestamp if the comment was updated

        // Optional: You can add a field for likes on comments if your app supports that feature
        public int Likes { get; set; } = 0;
    }
}
