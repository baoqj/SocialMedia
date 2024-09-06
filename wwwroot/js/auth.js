// Manages Firebase authentication (registration, login, logout)// Firebase configuration
// Import the functions you need from the SDKs you need
// Import Firebase Authentication functions from the Firebase SDK
import { getAuth, createUserWithEmailAndPassword, signInWithEmailAndPassword, signOut } from "./firebase/firebase-auth.js";
import { auth } from './firebase/firebase-config.js';  // Import the initialized auth object from firebase-config.js

// Function to register a new user
export function registerUser(email, password) {
    createUserWithEmailAndPassword(auth, email, password)
        .then((userCredential) => {
            // Registration successful
            const user = userCredential.user;
            console.log("User registered:", user);
            alert("User registered successfully!");
            window.location.href = "/"; // Redirect to home or dashboard after registration
        })
        .catch((error) => {
            const errorCode = error.code;
            const errorMessage = error.message;
            console.error("Error registering user:", errorCode, errorMessage);
            alert("Error: " + errorMessage);
        });
}

// Function to log in an existing user
export function loginUser(email, password) {
    signInWithEmailAndPassword(auth, email, password)
        .then((userCredential) => {
            // Login successful
            const user = userCredential.user;
            console.log("User logged in:", user);
            alert("Login successful!");
            window.location.href = "/"; // Redirect to home or dashboard after login
        })
        .catch((error) => {
            const errorCode = error.code;
            const errorMessage = error.message;
            console.error("Error logging in:", errorCode, errorMessage);
            alert("Error: " + errorMessage);
        });
}

// Function to log out the current user
export function logoutUser() {
    signOut(auth)
        .then(() => {
            // Logout successful
            console.log("User logged out");
            alert("Logout successful!");
            window.location.href = "/"; // Redirect to login or home after logout
        })
        .catch((error) => {
            console.error("Error logging out:", error.message);
            alert("Error logging out: " + error.message);
        });
}
