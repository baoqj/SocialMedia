// Handles post creation, image uploads, and fetching posts

import { db } from './firebase-config.js';

// Function to add a new post
function addPost(userName, content, imageUrl) {
    db.collection("posts").add({
        userName: userName,
        content: content,
        imageUrl: imageUrl,
        timestamp: firebase.firestore.FieldValue.serverTimestamp()
    })
        .then((docRef) => {
            console.log("Post added with ID:", docRef.id);
        })
        .catch((error) => {
            console.error("Error adding post:", error);
        });
}

// Function to get all posts
function getPosts() {
    db.collection("posts").orderBy("timestamp", "desc").get()
        .then((querySnapshot) => {
            querySnapshot.forEach((doc) => {
                console.log(`${doc.id} => ${doc.data()}`);
            });
        })
        .catch((error) => {
            console.error("Error fetching posts:", error);
        });
}
