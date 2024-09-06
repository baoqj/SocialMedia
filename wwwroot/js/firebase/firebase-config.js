// Import Firebase SDK modules from the installed npm package
import { initializeApp } from './firebase-app.js';
import { getAuth } from './firebase-auth.js';
import { getFirestore, doc, getDoc, collection, getDocs } from './firebase-firestore.js';
import { getStorage } from 'firebase/storage';

// Firebase configuration
const firebaseConfig = {
    apiKey: "AIzaSyBPKA2CyBAKzhiGSxNVXfvCRAgsERW3-2E",
    authDomain: "socialmedia-f367e.firebaseapp.com",
    projectId: "socialmedia-f367e",
    storageBucket: "socialmedia-f367e.appspot.com",
    messagingSenderId: "237634340079",
    appId: "1:237634340079:web:a4a024f8f8687a7c7a871a",
    measurementId: "G-E2ZJDQ5JRM"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const auth = getAuth(app);
const db = getFirestore(app);
const storage = getStorage(app);

export { auth, db, storage };
