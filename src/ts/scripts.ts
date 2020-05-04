import Swiper from 'swiper';

(window as any).appSwiperInit = function appSwiperInit(moduleID: any, autoplay: string, speed: string, effectDefaults: any, fallback: any) {
  var configured = {
    autoplay: (autoplay === 'True'),
    speed: speed
  };
  var merged = Object.assign(fallback, effectDefaults, configured);
  var mySwiper = new Swiper (`.swiper-${moduleID}`, merged);
}