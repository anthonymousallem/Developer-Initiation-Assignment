function initLayout() {
  (function ($) {
    'use strict';

    function getScrollBarWidth() {
      var outer = document.createElement('div');
      outer.style.visibility = 'hidden';
      outer.style.width = '100px';
      outer.style.msOverflowStyle = 'scrollbar'; // needed for WinJS apps

      document.body.appendChild(outer);
      var widthNoScroll = outer.offsetWidth; // force scrollbars

      outer.style.overflow = 'scroll'; // add innerdiv

      var inner = document.createElement('div');
      inner.style.width = '100%';
      outer.appendChild(inner);
      var widthWithScroll = inner.offsetWidth; // remove divs

      outer.parentNode.removeChild(outer);
      return widthNoScroll - widthWithScroll;
    }
    var detectMobile = {
      isMobile: /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)
    };
    if (detectMobile.isMobile) {
      $('html').addClass('mobile');
    } else {
      $('body').addClass('no-mobile');
    }
    // revolution-slider
    (function () {
      var sliderElementSelector = '.revolution-slider__slider';
      var sliderElement = document.querySelector(sliderElementSelector);

      if (sliderElement) {
        let revapi,
          tpj = jQuery;

        tpj(document).ready(function () {
          if (tpj(sliderElementSelector).revolution == undefined) {
            revslider_showDoubleJqueryError(sliderElementSelector);
          } else {
            $(sliderElementSelector).each(function (index, item) {
              revapi = tpj(item).show().revolution({
                sliderType: 'standard',
                jsFileLocation: '//tpserver.local/R_5452/wp-content/plugins/revslider/public/assets/js/',
                sliderLayout: sliderElement.classList.contains('revolution-slider__slider_autoheight') ? null : 'fullscreen',
                dottedOverlay: 'none',
                delay: 9000,
                navigation: {
                  keyboardNavigation: 'off',
                  keyboard_direction: 'horizontal',
                  mouseScrollNavigation: 'off',
                  mouseScrollReverse: 'default',
                  onHoverStop: 'off',
                  arrows: {
                    style: 'metis',
                    enable: true,
                    hide_onmobile: false,
                    hide_onleave: false,
                    tmp: '',
                    left: {
                      container: 'layergrid',
                      h_align: 'right',
                      v_align: 'bottom',
                      h_offset: 61,
                      v_offset: 1
                    },
                    right: {
                      container: 'layergrid',
                      h_align: 'right',
                      v_align: 'bottom',
                      h_offset: 0,
                      v_offset: 1
                    }
                  }
                },
                responsiveLevels: [1200, 992, 768, 576],
                visibilityLevels: [1200, 992, 768, 576],
                gridwidth: [1200, 992, 768, 576],
                gridheight: [800, 768, 960, 720],
                lazyType: 'single',
                shadow: 0,
                spinner: 'spinner5',
                stopLoop: 'on',
                stopAfterLoops: 0,
                stopAtSlide: 1,
                shuffle: 'off',
                autoHeight: 'off',
                disableProgressBar: 'on',
                hideThumbsOnMobile: 'off',
                hideSliderAtLimit: 0,
                hideCaptionAtLimit: 0,
                hideAllCaptionAtLilmit: 0,
                debugMode: false,
                fallbacks: {
                  simplifyAll: 'off',
                  nextSlideOnWindowFocus: 'off',
                  disableFocusListener: false
                }
              });

              if (revapi.revSliderSlicey) {
                revapi.revSliderSlicey();
              }

              $('.revolution-prev').on('click', function () {
                revapi.revprev();
              });

              $('.revolution-next').on('click', function () {
                revapi.revnext();
              });
            });
          }

          RsAddonPanorama(tpj, revapi);

          window.revapi = revapi;

          // panorama-slider
          (function () {
            if (window.revapi) {
              window.revapi.bind('revolution.slide.onchange', function (e, data) {
                $('.panorama-slider__content').each(function (index, item) {
                  if (index === data.slideIndex - 1) {
                    setTimeout(function () {
                      $(item).fadeIn(300);
                    }, 300);
                  } else {
                    $(item).fadeOut(300);
                  }
                });
              });
            }
          })();
        }); /* ready*/

        jQuery(window).on('scroll', function () {
          var wh = jQuery(this).height();
          jQuery('.tp-parallax-container').each(function () {
            var layer = jQuery(this);
            var po = Math.abs(layer.data('parallaxoffset'));
            if (po > 100) po = 100;
            if (po < 20) po = 0;
            po = (100 - po) / 100;
            TweenLite.to(layer, 0.2, { opacity: po });
          });
        });
      }
    })();
    // header
    (function () {
      var button = $('.header__menu-button');
      var panel = $('.header__menu');
      var overlay = $('.header__overlay');

      function openMenu() {
        var scrollBarWidth = window.innerWidth > document.querySelector('body').offsetWidth ? getScrollBarWidth() : 0;
        $('body').css({
          overflow: 'hidden',
          paddingRight: "".concat(scrollBarWidth, "px")
        });
        button.css({
          marginRight: "".concat(scrollBarWidth, "px")
        });
        $(overlay).fadeIn(300);
      };

      function hideMenu() {
        $('body').css({
          overflow: '',
          paddingRight: ''
        });
        button.css({
          marginRight: ''
        });
        $(overlay).fadeOut(300);
      };

      button.on('click', function () {
        button.toggleClass('header__menu-button_cross');
        button.toggleClass('header__menu-button_burger', !button.hasClass('header__menu-button_cross'));
        panel.toggleClass('header__menu_opened');

        if (button.hasClass('header__menu-button_cross')) {
          openMenu();
        } else {
          hideMenu();
        }
      });

      overlay.on('click', function () {
        button.toggleClass('header__menu-button_cross');
        button.toggleClass('header__menu-button_burger', !button.hasClass('header__menu-button_cross'));
        panel.toggleClass('header__menu_opened');

        if (button.hasClass('header__menu-button_cross')) {
          openMenu();
        } else {
          hideMenu();
        }
      });

      if ($('.header_fixed').length) {
        var headerElement = document.querySelector('.header');
        var nav_offset_top = headerElement.classList.contains('header_offset') ? window.innerHeight : headerElement.offsetHeight + 30;
        var headerContainer = document.querySelector('.header__container');
        $(window).scroll(function () {
          var scroll = $(window).scrollTop();

          if (scroll >= nav_offset_top) {
            $('.header_fixed').addClass('header_is_fixed');
            headerContainer.style.top = "-".concat(headerContainer.offsetHeight, "px");
          } else {
            $('.header_fixed').removeClass('header_is_fixed');
            headerContainer.style.top = '';
          }
        });
      }
    })();
  })(jQuery);
}
