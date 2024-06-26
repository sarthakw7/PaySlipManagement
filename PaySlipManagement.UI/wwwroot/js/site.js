// In your JavaScript file (e.g., script.js)
function showToast(message, type) {
    debugger
    // Create a toast element
    const toast = document.createElement('div');
    toast.classList.add('toast', type);
    toast.textContent = message;

    // Append the toast to the body
    document.body.appendChild(toast);

    // Automatically hide the toast after a few seconds
    setTimeout(() => {
        toast.remove();
    }, 3000);
}