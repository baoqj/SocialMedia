// Defines likes data
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class LikeModel
    {
        [Key]  // Primary key for the like
        public string LikeId { get; set; }

        [Required]
        public string PostId { get; set; }  // The ID of the post that was liked

        [Required]
        public string UserId { get; set; }  // The ID of the user who liked the post

        public DateTime LikedAt { get; set; } = DateTime.UtcNow;  // Timestamp when the like action occurred
    }
}
