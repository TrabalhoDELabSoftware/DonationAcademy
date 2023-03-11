var nextButton = document.querySelector(".carousel-control-next");
var prevButton = document.querySelector(".carousel-control-prev");

nextButton.addEventListener("click", function () {
    $('#carouselStore').carousel('next');
});

prevButton.addEventListener("click", function () {
    $('#carouselStore').carousel('prev');
});

