# Social Media Application with Firebase

### Objective: 
Develop a social media application using ASP.NET MVC and Firebase that enables users to register, manage profiles, create and view posts, follow other users, and interact with posts through likes and comments.

### Key Features and Functionality:

1. User Registration and Authentication
- Registration: Users can sign up with email and password, using Firebase Authentication for user management.
- Login: Users can log in using their email and password, with Firebase Authentication handling session management.
- Logout: Users can log out, which ends their Firebase session.

2. Profile Management
- View Profile: Users can view their profile, including their name, email, bio, and profile picture.
- Edit Profile: Users can update their profile details, including name, bio, and profile picture. Firebase Storage can be used for profile pictures.
- Change Password: Users can change their password using Firebase Authentication.

3. Post Creation and Feed
- Create Post: Users can create posts with text and optional images. Posts are stored in Firebase Realtime Database or Firestore.
- View Feed: Users can see a feed of posts from users they follow, displayed in reverse chronological order.
- Post Details: Users can view the details of a post, including content, image, and interactions (likes and comments).

4. Follow System
- Follow/Unfollow: Users can follow or unfollow other users. This information is stored in Firebase Realtime Database or Firestore.
- Follower List: Users can see a list of their followers and the users they are following on their profile.

5. Likes and Comments
- Like Posts: Users can like or unlike posts. The number of likes is displayed with each post.
- Comment on Posts: Users can add comments to posts. Comments are displayed below the post in chronological order.

6. Firebase Integration
- Firebase Authentication: For user authentication and management.
- Firebase Realtime Database or Firestore: For storing and retrieving posts, comments, likes, and user profiles.
- **Firebase Storage:** For storing user profile pictures and post images.


### Technical Details:
1. Technology Stack:
- Backend: ASP.NET MVC
- Database: Firebase Realtime Database or Firestore
- Authentication: Firebase Authentication
- Storage: Firebase Storage
- Frontend: Razor Pages for views, HTML, CSS, JavaScript for client-side interactivity

2. User Interface:
- Home Page: Displays the feed of posts from followed users.
- Profile Page: Shows user information, their posts, and followers/following lists.
- Post Page: Allows creation of new posts and displays existing posts.

3. Security:
- Firebase Authentication: Manages user authentication securely.
