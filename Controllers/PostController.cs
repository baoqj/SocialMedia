// Handles post creation and feed display

using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Controllers
{
    public class PostController : Controller
    {
        // Temporary in-memory list of posts (replace with Firebase or a database)
        private static List<PostModel> _posts = new List<PostModel>
        {
            new PostModel
            {
                Id = 1,
                UserName = "John Doe",
                Content = "This is my first post!",
                ImageUrl = "/images/sample-post.png", // Placeholder image
                Likes = 5,
                Comments = new List<string> { "Great post!", "Nice!" }
            }
        };

        // GET: Post/Feed
        [HttpGet]
        public IActionResult Feed()
        {
            // In a real application, you'd fetch posts from Firebase or a database
            var orderedPosts = _posts.OrderByDescending(p => p.Id).ToList(); // Show newest posts first
            return View(orderedPosts);
        }

        // GET: Post/CreatePost
        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        // POST: Post/CreatePost
        [HttpPost]
        public IActionResult CreatePost(PostModel newPost)
        {
            if (ModelState.IsValid)
            {
                // Add the new post to the list (in a real scenario, save it to Firebase or a database)
                newPost.Id = _posts.Max(p => p.Id) + 1; // Increment the post ID
                newPost.Likes = 0;
                newPost.Comments = new List<string>();

                _posts.Add(newPost);

                // Redirect to the Feed after successful post creation
                return RedirectToAction("Feed");
            }

            // If validation fails, return to the CreatePost view with validation errors
            return View(newPost);
        }

        // GET: Post/PostDetails/{id}
        [HttpGet]
        public IActionResult PostDetails(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Post/LikePost/{id}
        [HttpPost]
        public IActionResult LikePost(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                post.Likes++; // Increment the like count
            }

            return RedirectToAction("Feed");
        }

        // POST: Post/Comment/{id}
        [HttpPost]
        public IActionResult Comment(int id, string comment)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);

            if (post != null && !string.IsNullOrEmpty(comment))
            {
                post.Comments.Add(comment); // Add comment to the post
            }

            return RedirectToAction("PostDetails", new { id });
        }
    }
}
