(function () {
    'use strict';

    function initImageFallbacks() {
        document.querySelectorAll('img[data-img-fallback]').forEach(function (img) {
            if (img.complete && img.naturalWidth === 0) {
                showPlaceholder(img);
                return;
            }
            img.addEventListener('error', function () {
                showPlaceholder(img);
            });
        });
    }

    function showPlaceholder(img) {
        var wrap = img.closest('[data-img-wrap]');
        if (!wrap) return;
        var placeholder = wrap.querySelector('.placeholder-img');
        if (placeholder) {
            placeholder.style.display = 'flex';
        }
        img.style.display = 'none';
    }

    function initTechImageFallback() {
        document.querySelectorAll('[data-tech-img]').forEach(function (wrap) {
            var img = wrap.querySelector('img');
            if (!img) return;
            img.addEventListener('error', function () {
                wrap.innerHTML = '<div class="placeholder-img" style="height:100%">Fabric Detail</div>';
            });
        });
    }

    function initHeroImageFallback() {
        var heroImg = document.querySelector('.hero__image');
        if (heroImg) {
            heroImg.addEventListener('error', function () {
                heroImg.style.display = 'none';
            });
        }
    }

    document.addEventListener('DOMContentLoaded', function () {
        initImageFallbacks();
        initTechImageFallback();
        initHeroImageFallback();
    });
})();
