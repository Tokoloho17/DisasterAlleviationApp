document.addEventListener("DOMContentLoaded", function () {
    
    const fadeElements = document.querySelectorAll(".fade-in");
    fadeElements.forEach((el, index) => {
        el.style.opacity = 0;
        setTimeout(() => {
            el.style.transition = "opacity 1s, transform 1s";
            el.style.opacity = 1;
            el.style.transform = "translateY(0)";
        }, index * 200); // staggered animation
    });

   
    const buttons = document.querySelectorAll(".btn-custom, .button");
    buttons.forEach(btn => {
        btn.addEventListener("click", function (e) {
            const ripple = document.createElement("span");
            ripple.classList.add("ripple");
            this.appendChild(ripple);

            const rect = this.getBoundingClientRect();
            ripple.style.left = (e.clientX - rect.left) + "px";
            ripple.style.top = (e.clientY - rect.top) + "px";

            setTimeout(() => {
                ripple.remove();
            }, 600);
        });
    });

    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({ behavior: 'smooth' });
            }
        });
    });

 
    const disasterForm = document.getElementById("disasterForm");
    const message = document.getElementById("message");
    if (disasterForm && message) {
        disasterForm.addEventListener("submit", function () {
            // fade in message after form submit)
            message.style.opacity = 0;
            setTimeout(() => {
                message.style.transition = "opacity 1s";
                message.style.opacity = 1;
            }, 200);
        });
    }

    const inputs = document.querySelectorAll("input, textarea");
    inputs.forEach(input => {
        input.addEventListener("focus", () => {
            input.style.boxShadow = "0 0 10px rgba(52,152,219,0.6)";
        });
        input.addEventListener("blur", () => {
            input.style.boxShadow = "none";
        });
    });
});
