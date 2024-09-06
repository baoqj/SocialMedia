// Defines user data (name, bio, profile picture)

using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Bio { get; set; }

        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
