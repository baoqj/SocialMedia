using System;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class FollowModel
    {
        [Key]  // Primary key for the follow relationship
        public string FollowId { get; set; }

        [Required]
        public string FollowerId { get; set; }  // The ID of the user who is following

        [Required]
        public string FollowingId { get; set; }  // The ID of the user being followed

        public DateTime FollowedAt { get; set; } = DateTime.UtcNow;  // Timestamp when the follow action occurred
    }
}
