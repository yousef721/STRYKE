(function () {
    'use strict';

    function initArrivalsNav() {
        var grid = document.querySelector('[data-product-grid]');
        var prev = document.querySelector('[data-arrivals-prev]');
        var next = document.querySelector('[data-arrivals-next]');
        if (!grid || !prev || !next) return;

        var scrollAmount = 280;
        prev.addEventListener('click', function () {
            grid.scrollBy({ left: -scrollAmount, behavior: 'smooth' });
        });
        next.addEventListener('click', function () {
            grid.scrollBy({ left: scrollAmount, behavior: 'smooth' });
        });
    }

    document.addEventListener('DOMContentLoaded', initArrivalsNav);
})();
