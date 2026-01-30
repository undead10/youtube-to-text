// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

(() => {
  const items = document.querySelectorAll('.fade-up');
  if (!items.length) return;

  const reveal = (el) => el.classList.add('is-visible');

  if ('IntersectionObserver' in window) {
    const io = new IntersectionObserver((entries) => {
      entries.forEach((entry) => {
        if (entry.isIntersecting) {
          reveal(entry.target);
          io.unobserve(entry.target);
        }
      });
    }, { threshold: 0.15 });

    items.forEach((el) => io.observe(el));
  } else {
    items.forEach(reveal);
  }
})();
