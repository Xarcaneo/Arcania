document.addEventListener('DOMContentLoaded', function () {
    // Function to update the avatar image and description
    function updateAvatarAndDescription() {
        const genderInput = document.querySelector('input[name="gender"]:checked');
        const raceInput = document.querySelector('input[name="race"]:checked');
        const avatarImg = document.getElementById('character-avatar');
        const raceDescriptionDiv = document.getElementById('race-description'); // Get the description div

        if (genderInput && raceInput) {
            const gender = genderInput.value;
            const race = raceInput.value;
            // Retrieve the description from the data attribute of the selected race radio button
            const description = raceInput.getAttribute('data-description');

            // Construct the image path based on selected gender and race
            // Example: "images/avatar-male-human.png"
            const imagePath = `/content/characters/${race}_${gender}.png`;

            // Update the src attribute of the avatar image
            avatarImg.src = imagePath;
            avatarImg.alt = `Avatar for ${race} ${gender}`;

            // Update the race description div
            raceDescriptionDiv.textContent = description;
        }
    }

    // Add event listeners to all gender and race radio buttons
    document.querySelectorAll('input[name="gender"], input[name="race"]').forEach(input => {
        input.addEventListener('change', updateAvatarAndDescription);
    });

    // Initial update in case the default selection is not the desired initial avatar and description
    updateAvatarAndDescription();
});
