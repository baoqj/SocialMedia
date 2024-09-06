// Handles follow/unfollow functionality
// Import Firestore functions from the Firebase SDK
import { getFirestore, collection, addDoc, deleteDoc, query, where, getDocs } from "./firebase/firebase-firestore.js";
import { db } from './firebase/firebase-config.js';  // Assuming Firebase is initialized in firebase-config.js

// Function to follow a user
export async function followUser(followerId, followingId) {
    try {
        const followCollection = collection(db, "followers");

        // Add a new follow relationship to Firestore
        await addDoc(followCollection, {
            followerId: followerId,
            followingId: followingId
        });

        console.log(`${followerId} is now following ${followingId}`);
        alert("You are now following this user.");
    } catch (error) {
        console.error("Error following user:", error);
        alert("Error: Unable to follow the user.");
    }
}

// Function to unfollow a user
export async function unfollowUser(followerId, followingId) {
    try {
        const followCollection = collection(db, "followers");

        // Query to find the follow relationship document
        const q = query(followCollection, where("followerId", "==", followerId), where("followingId", "==", followingId));
        const querySnapshot = await getDocs(q);

        // Delete the follow relationship
        querySnapshot.forEach(async (doc) => {
            await deleteDoc(doc.ref);
            console.log(`${followerId} has unfollowed ${followingId}`);
            alert("You have unfollowed this user.");
        });

    } catch (error) {
        console.error("Error unfollowing user:", error);
        alert("Error: Unable to unfollow the user.");
    }
}

// Function to check if the user is already following another user (Optional)
export async function isFollowing(followerId, followingId) {
    try {
        const followCollection = collection(db, "followers");

        // Query to check the existence of a follow relationship
        const q = query(followCollection, where("followerId", "==", followerId), where("followingId", "==", followingId));
        const querySnapshot = await getDocs(q);

        if (!querySnapshot.empty) {
            console.log(`${followerId} is already following ${followingId}`);
            return true;
        } else {
            console.log(`${followerId} is not following ${followingId}`);
            return false;
        }
    } catch (error) {
        console.error("Error checking follow status:", error);
        alert("Error: Unable to check follow status.");
        return false;
    }
}
