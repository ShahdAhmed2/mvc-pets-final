// Initialize GSAP
gsap.registerPlugin(ScrollTrigger);

// Navbar animations
const navbar = document.querySelector('.navbar');
gsap.from(navbar, {
    y: -100,
    opacity: 0,
    duration: 1,
    ease: "power3.out"
});

// Hero section animations
gsap.from('.hero-content', {
    y: 100,
    opacity: 0,
    duration: 1.5,
    delay: 0.5,
    ease: "power4.out"
});

// Elegant scroll animations for navbar
window.addEventListener('scroll', () => {
    if (window.scrollY > 50) {
        navbar.classList.add('scrolled');
        gsap.to(navbar, {
            boxShadow: '0 4px 16px rgba(0, 0, 0, 0.08)',
            padding: '0.75rem 0',
            duration: 0.3,
            ease: "power2.out"
        });
    } else {
        navbar.classList.remove('scrolled');
        gsap.to(navbar, {
            boxShadow: '0 2px 8px rgba(0, 0, 0, 0.06)',
            padding: '1rem 0',
            duration: 0.3,
            ease: "power2.out"
        });
    }
});

// Card animations with GSAP
gsap.utils.toArray('.card').forEach((card, i) => {
    gsap.from(card, {
        scrollTrigger: {
            trigger: card,
            start: "top bottom-=100",
            toggleActions: "play none none reverse"
        },
        y: 100,
        opacity: 0,
        duration: 0.8,
        delay: i * 0.2,
        ease: "power3.out"
    });
});

// Button hover animations
document.querySelectorAll('.btn-primary, .card button').forEach(button => {
    button.addEventListener('mouseenter', () => {
        gsap.to(button, {
            y: -5,
            boxShadow: '0 8px 16px rgba(0,0,0,0.2)',
            duration: 0.3,
            ease: "power2.out"
        });
    });

    button.addEventListener('mouseleave', () => {
        gsap.to(button, {
            y: 0,
            boxShadow: '0 4px 8px rgba(0,0,0,0.1)',
            duration: 0.3,
            ease: "power2.out"
        });
    });
});

// Smooth scroll with GSAP
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            gsap.to(window, {
                duration: 1,
                scrollTo: {
                    y: target,
                    offsetY: 70
                },
                ease: "power3.inOut"
            });
        }
    });
});

// Parallax effect for hero section
gsap.to('.hero', {
    backgroundPosition: `50% ${innerHeight / 2}px`,
    ease: "none",
    scrollTrigger: {
        trigger: ".hero",
        start: "top top",
        end: "bottom top",
        scrub: true
    }
});

// Image loading animations
document.querySelectorAll('img').forEach(img => {
    img.addEventListener('load', function() {
        gsap.from(this, {
            opacity: 0,
            scale: 0.8,
            duration: 0.8,
            ease: "power2.out"
        });
    });
});

// Footer animations
gsap.from('.footer', {
    scrollTrigger: {
        trigger: '.footer',
        start: "top bottom",
        toggleActions: "play none none reverse"
    },
    y: 50,
    opacity: 0,
    duration: 1,
    ease: "power3.out"
});

// Social media icons animation
gsap.from('.social-links a', {
    scrollTrigger: {
        trigger: '.social-links',
        start: "top bottom-=100"
    },
    y: 30,
    opacity: 0,
    duration: 0.8,
    stagger: 0.2,
    ease: "back.out(1.7)"
});

// Dropdown menu animations
document.querySelectorAll('.dropdown-menu').forEach(menu => {
    menu.addEventListener('show.bs.dropdown', () => {
        gsap.from(menu, {
            y: -20,
            opacity: 0,
            duration: 0.3,
            ease: "power2.out"
        });
    });
});

// Notification badge animation
const notificationBadge = document.querySelector('.badge');
if (notificationBadge) {
    gsap.to(notificationBadge, {
        scale: 1.2,
        duration: 0.3,
        yoyo: true,
        repeat: -1,
        ease: "power1.inOut"
    });
}

// Text gradient animation
gsap.to('.text-gradient', {
    backgroundPosition: '200% center',
    duration: 5,
    repeat: -1,
    ease: "linear"
}); 