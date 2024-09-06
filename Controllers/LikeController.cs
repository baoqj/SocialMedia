using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Linq;

namespace SocialMediaApp.Controllers
{
    public class LikeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LikeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Like(string postId, string userId)
        {
            if (_context.LikeModels.Any(l => l.PostId == postId && l.UserId == userId))
            {
                return BadRequest("User has already liked this post.");
            }

            var like = new LikeModel
            {
                LikeId = Guid.NewGuid().ToString(),
                PostId = postId,
                UserId = userId,
                LikedAt = DateTime.UtcNow
            };

            _context.LikeModels.Add(like);
            _context.SaveChanges();

            return Ok("Post liked successfully.");
        }

        [HttpPost]
        public IActionResult Unlike(string postId, string userId)
        {
            var like = _context.LikeModels
                .FirstOrDefault(l => l.PostId == postId && l.UserId == userId);

            if (like == null)
            {
                return NotFound("Like not found.");
            }

            _context.LikeModels.Remove(like);
            _context.SaveChanges();

            return Ok("Post unliked successfully.");
        }

        [HttpGet]
        public IActionResult GetLikesForPost(string postId)
        {
            var likes = _context.LikeModels
                .Where(l => l.PostId == postId)
                .ToList();

            return Ok(likes);
        }
    }
}
