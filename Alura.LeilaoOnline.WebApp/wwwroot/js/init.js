function readPosterURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgPoster').attr('src', e.target.result);
            $('.imagem .card-content').text(input.files[0].name);
            console.log(input.files[0].name);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

(function ($) {
    $(function(){

        $('.sidenav').sidenav();
        $('.parallax').parallax();
        $(".dropdown-trigger").dropdown();
        $('.carousel.carousel-slider').carousel({
            fullWidth: true,
            indicators: true
        });
        $('.modal').modal();
        $('select').formSelect();
        $('.datepicker').datepicker({
            "format": "dd/mm/yyyy",
            autoClose: true
        });
        $('#poster').change(function () {
            readPosterURL(this);
        });

  }); // end of document ready
})(jQuery); // end of jQuery name space
