import { storage } from './firebase-config.js';

// Function to upload a file
function uploadFile(file) {
    const storageRef = storage.ref('uploads/' + file.name);

    storageRef.put(file).then((snapshot) => {
        console.log("File uploaded successfully");
        snapshot.ref.getDownloadURL().then((url) => {
            console.log("File available at:", url);
        });
    });
}
