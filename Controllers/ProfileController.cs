// Manages profile viewing and editing

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    public class ProfileController : Controller
    {
        // Temporary in-memory user data for demonstration (replace with Firebase or database)
        private static UserModel _user = new UserModel
        {
            Name = "John Doe",
            Email = "john.doe@example.com",
            Bio = "Welcome to my profile!",
            ProfilePictureUrl = "/images/default-profile.png" // Placeholder profile picture
        };

        // GET: Profile/ViewProfile
        [HttpGet]
        public IActionResult ViewProfile()
        {
            // Normally, you'd retrieve the logged-in user's profile data from Firebase or a database.
            return View(_user);
        }

        // GET: Profile/EditProfile
        [HttpGet]
        public IActionResult EditProfile()
        {
            // Pass the current user profile data to the EditProfile view
            return View(_user);
        }

        // POST: Profile/EditProfile
        [HttpPost]
        public IActionResult EditProfile(UserModel updatedProfile)
        {
            if (ModelState.IsValid)
            {
                // In a real scenario, you'd update the user's profile data in Firebase or your database.
                _user.Name = updatedProfile.Name;
                _user.Bio = updatedProfile.Bio;
                _user.ProfilePictureUrl = updatedProfile.ProfilePictureUrl ?? _user.ProfilePictureUrl;

                // Redirect to the ViewProfile page after a successful profile update
                return RedirectToAction("ViewProfile");
            }

            // If validation fails, return to the EditProfile view with the validation messages
            return View(updatedProfile);
        }

        // Additional methods for uploading profile picture, etc., can be added here
    }
}
