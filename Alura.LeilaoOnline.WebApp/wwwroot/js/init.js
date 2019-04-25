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
        $(".dropdown-trigger").dropdown({
            hover: true,
            constrainWidth: false,
            coverTrigger: false
        });
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
        $('#ArquivoImagem').change(function () {
            readPosterURL(this);
        });
        $('.tooltiped').tooltip();
        $('input[type=text]:not(.browser-default), textarea').characterCounter();

        $('#btnDarLance').on('click', e => {
            e.preventDefault();

            //enviar requisi��o com o lance
            $.post(
                '/Interessadas/OfertaLance',
                $('#formDarLance').serialize(),
                function () {
                    console.log('lance ofertado!');
                    M.toast({ html: 'Lance ofertado com sucesso!' });
                }
            );

        });

        $('.seguir').on('click', e => {
            e.preventDefault();

            const link = $(e.target).parent();

            //enviar requisi��o para seguir o leil�o
            $.post(
                '/Interessadas/SeguirLeilao',
                $(link).data(),
                function () {
                    console.log('leil�o foi seguido!');
                    M.toast({ html: 'Leil�o est� sendo seguido!' });
                    //mudar o �cone e a classe do link
                    e.target.textContent = 'star';
                    $(link).removeClass("seguir");
                    $(link).addClass("abandonar yellow-text text-darken-4");
                }
            );

        });

        //a��o de deixar de seguir um leil�o
        $('.abandonar').on('click', e => {
            e.preventDefault();

            const link = $(e.target).parent();

            //enviar requisi��o para deixar de seguir o leil�o
            $.post(
                '/Interessadas/AbandonarLeilao',
                $(link).data(),
                function () {
                    console.log('leil�o foi abandonado!');
                    M.toast({ html: 'Voc� deixou de seguir o leil�o!' });
                    //mudar o �cone e a classe do link
                    e.target.textContent = 'star_border';
                    $(link).removeClass("abandonar yellow-text text-darken-4");
                    $(link).addClass("seguir white-text");
                }
            );

        });

  }); // end of document ready
})(jQuery); // end of jQuery name space
