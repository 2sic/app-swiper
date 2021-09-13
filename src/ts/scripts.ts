import Swiper from 'swiper/bundle';
require('../scss/bs4.scss');

interface SwiperOptions {
  autoplay: string;
  speed: string;
  effectDefaults: any;
  fallback: any; // see effect fallback in custom app settings
}

function initAppSwiper({ moduleId, options } : { moduleId: string, options: SwiperOptions }) {
  let configured = {
    autoplay: (options.autoplay === 'True'),
    speed: options.speed
  };
  let merged = Object.assign(options.fallback, options.effectDefaults, configured);
  new Swiper (`.swiper-${moduleId}`, merged);
}

// so it can be called from the HTML when content re-initializes dynamically
const winAny = (window as any);
winAny.appSwiper2 ??= {};
winAny.appSwiper2.init ??= initAppSwiper;
