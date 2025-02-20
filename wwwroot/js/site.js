// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    const navbarNav = document.getElementById("navbarNav");
    document.querySelectorAll(".navbar-nav a").forEach(item => {
        item.addEventListener("click", () => {
            if (navbarNav.classList.contains("show")) {
                new bootstrap.Collapse(navbarNav).hide();
            }
        });
    });
});
