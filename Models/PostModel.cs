// Defines post data (content, image, likes, comments)

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Content { get; set; }

        public string ImageUrl { get; set; } // Optional image for the post

        public int Likes { get; set; } // Like counter

        public List<string> Comments { get; set; } // List of comments
    }
}
