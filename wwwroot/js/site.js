/**
 * nastya.p24.co - Main JavaScript
 * Features: Theme toggle, scroll animations, mobile improvements
 */

(function() {
    'use strict';

    // ========================================
    // Theme Management
    // ========================================
    const ThemeManager = {
        STORAGE_KEY: 'theme',
        DEFAULT_THEME: 'dark',
        
        init() {
            this.themeToggle = document.getElementById('themeToggle');
            this.html = document.documentElement;
            
            if (!this.themeToggle) return;
            
            // Load saved theme or default to dark
            const savedTheme = this.getStoredTheme();
            this.applyTheme(savedTheme);
            
            // Bind click event
            this.themeToggle.addEventListener('click', () => this.toggleTheme());
            
            // Listen for system theme changes
            this.listenToSystemTheme();
        },
        
        getStoredTheme() {
            try {
                return localStorage.getItem(this.STORAGE_KEY) || this.DEFAULT_THEME;
            } catch (e) {
                return this.DEFAULT_THEME;
            }
        },
        
        storeTheme(theme) {
            try {
                localStorage.setItem(this.STORAGE_KEY, theme);
            } catch (e) {
                // Silent fail in private mode
            }
        },
        
        applyTheme(theme) {
            this.html.setAttribute('data-theme', theme);
            this.storeTheme(theme);
            
            // Dispatch custom event for other components
            window.dispatchEvent(new CustomEvent('themechange', { 
                detail: { theme } 
            }));
        },
        
        toggleTheme() {
            const currentTheme = this.html.getAttribute('data-theme');
            const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
            
            // Add transition class for smooth color transition
            this.html.classList.add('theme-transitioning');
            
            this.applyTheme(newTheme);
            
            // Remove transition class after animation
            setTimeout(() => {
                this.html.classList.remove('theme-transitioning');
            }, 300);
        },
        
        listenToSystemTheme() {
            if (window.matchMedia) {
                const mediaQuery = window.matchMedia('(prefers-color-scheme: light)');
                
                // Only apply system preference if no stored preference
                try {
                    if (!localStorage.getItem(this.STORAGE_KEY)) {
                        this.applyTheme(mediaQuery.matches ? 'light' : 'dark');
                    }
                } catch (e) {
                    // Silent fail
                }
            }
        }
    };

    // ========================================
    // Scroll Animations (Intersection Observer)
    // ========================================
    const ScrollAnimations = {
        init() {
            const items = document.querySelectorAll('.fade-up');
            if (!items.length) return;
            
            // Check for reduced motion preference
            if (window.matchMedia('(prefers-reduced-motion: reduce)').matches) {
                items.forEach(el => el.classList.add('is-visible'));
                return;
            }
            
            const observerOptions = {
                root: null,
                rootMargin: '0px 0px -50px 0px',
                threshold: 0.15
            };
            
            const observer = new IntersectionObserver((entries) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        // Add small delay for stagger effect if element has stagger class
                        const delay = this.getStaggerDelay(entry.target);
                        
                        setTimeout(() => {
                            entry.target.classList.add('is-visible');
                        }, delay);
                        
                        observer.unobserve(entry.target);
                    }
                });
            }, observerOptions);
            
            items.forEach(el => observer.observe(el));
        },
        
        getStaggerDelay(element) {
            if (element.classList.contains('stagger-1')) return 100;
            if (element.classList.contains('stagger-2')) return 200;
            if (element.classList.contains('stagger-3')) return 300;
            return 0;
        }
    };

    // ========================================
    // Mobile Optimizations
    // ========================================
    const MobileOptimizations = {
        init() {
            this.fixViewportZoom();
            this.addTouchFeedback();
            this.optimizeForTouch();
        },
        
        // Fix iOS viewport zoom on input focus
        fixViewportZoom() {
            if (/iPad|iPhone|iPod/.test(navigator.userAgent)) {
                const viewport = document.querySelector('meta[name="viewport"]');
                if (viewport) {
                    viewport.setAttribute('content', 
                        'width=device-width, initial-scale=1.0, maximum-scale=5.0');
                }
            }
        },
        
        // Add touch feedback for interactive elements
        addTouchFeedback() {
            const touchElements = document.querySelectorAll(
                '.btn, .nav-link, .learn-list a, .theme-toggle, .navbar-toggler'
            );
            
            touchElements.forEach(el => {
                el.addEventListener('touchstart', function() {
                    this.style.transform = 'scale(0.97)';
                }, { passive: true });
                
                el.addEventListener('touchend', function() {
                    this.style.transform = '';
                }, { passive: true });
            });
        },
        
        // Optimize for touch devices
        optimizeForTouch() {
            // Add class to body for touch-specific CSS
            if ('ontouchstart' in window || navigator.maxTouchPoints > 0) {
                document.body.classList.add('touch-device');
            }
            
            // Close mobile menu on link click
            const navLinks = document.querySelectorAll('.navbar-nav .nav-link');
            const navbarCollapse = document.querySelector('.navbar-collapse');
            
            navLinks.forEach(link => {
                link.addEventListener('click', () => {
                    if (navbarCollapse && navbarCollapse.classList.contains('show')) {
                        navbarCollapse.classList.remove('show');
                    }
                });
            });
        }
    };

    // ========================================
    // Smooth Scroll for Anchor Links
    // ========================================
    const SmoothScroll = {
        init() {
            document.querySelectorAll('a[href^="#"]').forEach(anchor => {
                anchor.addEventListener('click', function(e) {
                    const targetId = this.getAttribute('href');
                    if (targetId === '#') return;
                    
                    const target = document.querySelector(targetId);
                    if (target) {
                        e.preventDefault();
                        target.scrollIntoView({
                            behavior: 'smooth',
                            block: 'start'
                        });
                    }
                });
            });
        }
    };

    // ========================================
    // Navbar Scroll Effect
    // ========================================
    const NavbarScroll = {
        init() {
            const navbar = document.querySelector('.navbar');
            if (!navbar) return;
            
            let lastScroll = 0;
            let ticking = false;
            
            window.addEventListener('scroll', () => {
                if (!ticking) {
                    window.requestAnimationFrame(() => {
                        this.handleScroll(navbar, lastScroll);
                        lastScroll = window.scrollY;
                        ticking = false;
                    });
                    ticking = true;
                }
            }, { passive: true });
        },
        
        handleScroll(navbar, lastScroll) {
            const currentScroll = window.scrollY;
            
            // Add/remove shadow on scroll
            if (currentScroll > 10) {
                navbar.style.boxShadow = 'var(--shadow)';
            } else {
                navbar.style.boxShadow = 'var(--shadow-soft)';
            }
            
            // Hide/show on scroll (mobile only)
            if (window.innerWidth < 576) {
                if (currentScroll > lastScroll && currentScroll > 100) {
                    navbar.style.transform = 'translateY(-100%)';
                } else {
                    navbar.style.transform = 'translateY(0)';
                }
            }
        }
    };

    // ========================================
    // Form Enhancements
    // ========================================
    const FormEnhancements = {
        init() {
            this.addFocusAnimations();
            this.addSubmitFeedback();
        },
        
        addFocusAnimations() {
            const inputs = document.querySelectorAll('.form-control');
            
            inputs.forEach(input => {
                input.addEventListener('focus', function() {
                    this.closest('.card')?.classList.add('input-focused');
                });
                
                input.addEventListener('blur', function() {
                    this.closest('.card')?.classList.remove('input-focused');
                });
            });
        },
        
        addSubmitFeedback() {
            const forms = document.querySelectorAll('form');
            
            forms.forEach(form => {
                form.addEventListener('submit', function(e) {
                    const submitBtn = this.querySelector('[type="submit"]');
                    if (submitBtn) {
                        submitBtn.disabled = true;
                        submitBtn.dataset.originalText = submitBtn.innerHTML;
                        submitBtn.innerHTML = '<span class="spinner"></span> Loading...';
                        
                        // Re-enable after 10 seconds (fallback)
                        setTimeout(() => {
                            submitBtn.disabled = false;
                            submitBtn.innerHTML = submitBtn.dataset.originalText;
                        }, 10000);
                    }
                });
            });
        }
    };

    // ========================================
    // Initialize Everything
    // ========================================
    function init() {
        ThemeManager.init();
        ScrollAnimations.init();
        MobileOptimizations.init();
        SmoothScroll.init();
        NavbarScroll.init();
        FormEnhancements.init();
        
        // Add loaded class for initial animations
        document.addEventListener('DOMContentLoaded', () => {
            document.body.classList.add('loaded');
        });
    }

    // Run initialization
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', init);
    } else {
        init();
    }
    
    // Expose ThemeManager globally for debugging
    window.ThemeManager = ThemeManager;
})();
