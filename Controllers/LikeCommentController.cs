// Handles likes and comments on posts

using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Linq;

namespace SocialMedia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeCommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LikeCommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/LikeComment/Like
        [HttpPost("Like")]
        public IActionResult Like(string commentId, string userId)
        {
            // Check if the user has already liked the comment
            if (_context.LikeCommentModels.Any(l => l.CommentId == commentId && l.UserId == userId))
            {
                return BadRequest("User has already liked this comment.");
            }

            // Create a new like
            var like = new LikeCommentModel
            {
                LikeId = Guid.NewGuid().ToString(),
                CommentId = commentId,
                UserId = userId,
                LikedAt = DateTime.UtcNow
            };

            _context.LikeCommentModels.Add(like);
            _context.SaveChanges();

            return Ok(new { Message = "Comment liked successfully." });
        }

        // POST: api/LikeComment/Unlike
        [HttpPost("Unlike")]
        public IActionResult Unlike(string commentId, string userId)
        {
            // Find the like to be removed
            var like = _context.LikeCommentModels
                .FirstOrDefault(l => l.CommentId == commentId && l.UserId == userId);

            if (like == null)
            {
                return NotFound("Like not found.");
            }

            _context.LikeCommentModels.Remove(like);
            _context.SaveChanges();

            return Ok(new { Message = "Comment unliked successfully." });
        }

        // GET: api/LikeComment/GetLikesForComment
        [HttpGet("GetLikesForComment")]
        public IActionResult GetLikesForComment(string commentId)
        {
            var likes = _context.LikeCommentModels
                .Where(l => l.CommentId == commentId)
                .Select(l => new { l.UserId, l.LikedAt })
                .ToList();

            return Ok(likes);
        }

        // GET: api/LikeComment/GetUserLikeStatus
        [HttpGet("GetUserLikeStatus")]
        public IActionResult GetUserLikeStatus(string commentId, string userId)
        {
            bool isLiked = _context.LikeCommentModels
                .Any(l => l.CommentId == commentId && l.UserId == userId);

            return Ok(new { IsLiked = isLiked });
        }
    }
}
