// custom-validation.js

function validateForm() {
    // Get the value of the UserName input field
    var userNameValue = $('#UserName').val();

    // Check if the UserName is "Test"
    if (userNameValue === 'Test') {
        // Display an error message in the designated div
        $('#userNameError').text('User name cannot be "Test"');
        return false; // Prevent form submission
    } else {
        // Clear the error message
        $('#userNameError').text('');
        return true; // Allow form submission
    }
}
