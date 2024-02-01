const raceDescriptions = {
    human: "Description for Human Race",
    elf: "Description for Elf Race",
    dwarf: "Description for Dwarf Race",
    // Add descriptions for other races
};

document.addEventListener('DOMContentLoaded', function () {
    // Function to update the avatar image and description
    function updateAvatarAndDescription() {
        const genderInput = document.querySelector('input[name="gender"]:checked');
        const raceInput = document.querySelector('input[name="race"]:checked');
        const avatarImg = document.getElementById('character-avatar');
        const raceDescriptionDiv = document.querySelector('.form-container-description'); // Get the description div

        if (genderInput && raceInput) {
            const gender = genderInput.value;
            const race = raceInput.value;

            // Construct the image path based on selected gender and race
            // Example: "images/avatar-male-human.png"
            const imagePath = `/content/characters/${race}_${gender}.png`;

            // Update the src attribute of the avatar image
            avatarImg.src = imagePath;
            avatarImg.alt = `Avatar for ${race} ${gender}`;

            // Update the race description based on the selected race
            if (raceDescriptions.hasOwnProperty(race)) {
                raceDescriptionDiv.textContent = raceDescriptions[race];
            }
        }
    }

    // Add event listeners to all gender and race radio buttons
    document.querySelectorAll('input[name="gender"], input[name="race"]').forEach(input => {
        input.addEventListener('change', updateAvatarAndDescription);
    });

    // Initial update in case the default selection is not the desired initial avatar
    updateAvatarAndDescription();
});
