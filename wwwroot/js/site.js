$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        items: 3, 
        loop: true,
        margin: 4,
        nav: true,
        dots: false,
        autoplay: true,
        smartSpeed: 500,
        responsive: {
            0: {
                items: 1 
            },
            0: {
                items: 2 
            },
            0: {
                items: 3
            }
        }
    });
});
