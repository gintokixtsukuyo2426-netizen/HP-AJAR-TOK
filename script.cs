document.addEventListener("DOMContentLoaded", function () {
    
    // ==================================================
    // 1. MOBILE NAVIGATION TOGGLE
    // ==================================================
    const hamburger = document.getElementById("hamburger");
    const navLinks = document.getElementById("navLinks");

    if (hamburger && navLinks) {
        hamburger.addEventListener("click", function () {
            navLinks.classList.toggle("active");
        });

        // Close menu when clicking link
        navLinks.querySelectorAll("a").forEach(link => {
            link.addEventListener("click", () => {
                navLinks.classList.remove("active");
            });
        });
    }

    // ==================================================
    // 2. FAQ ACCORDION
    // ==================================================
    const faqItems = document.querySelectorAll(".faq-item");

    faqItems.forEach(item => {
        const questionBtn = item.querySelector(".faq-question");
        questionBtn.addEventListener("click", () => {
            const isActive = item.classList.contains("active");
            
            // Close all items
            faqItems.forEach(i => i.classList.remove("active"));
            
            // Toggle clicked item
            if (!isActive) {
                item.classList.add("active");
            }
        });
    });

    // ==================================================
    // 3. META ADS EVENT TRACKING SIMULATION
    // ==================================================
    // Track Lead / Conversion event on CTA click
    const ctaButtons = document.querySelectorAll(".cta-btn");

    ctaButtons.forEach(button => {
        button.addEventListener("click", function (e) {
            // Trigger Meta Pixel Event safely if installed
            if (typeof fbq === "function") {
                fbq('track', 'Lead');
                fbq('track', 'InitiateCheckout');
            }
            console.log("Simulated Meta Ads Event: Lead / InitiateCheckout Triggered");
        });
    });

    // Simulated ViewContent Event on Load
    if (typeof fbq === "function") {
        fbq('track', 'ViewContent');
    }

    // ==================================================
    // 4. INTERSECTION OBSERVER (SCROLL ANIMATIONS)
    // ==================================================
    const observerOptions = {
        threshold: 0.1
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = "1";
                entry.target.style.transform = "translateY(0)";
            }
        });
    }, observerOptions);

    document.querySelectorAll(".card, .marketing-box, .offer-card").forEach(el => {
        el.style.opacity = "0";
        el.style.transform = "translateY(20px)";
        el.style.transition = "all 0.6s cubic-bezier(0.4, 0, 0.2, 1)";
        observer.observe(el);
    });
});