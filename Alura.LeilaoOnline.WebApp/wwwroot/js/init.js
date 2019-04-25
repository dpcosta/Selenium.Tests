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

            //enviar requisição com o lance
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

            //enviar requisição para seguir o leilão
            $.post(
                '/Interessadas/SeguirLeilao',
                $(link).data(),
                function () {
                    console.log('leilão foi seguido!');
                    M.toast({ html: 'Leilão está sendo seguido!' });
                    //mudar o ícone e a classe do link
                    e.target.textContent = 'star';
                    $(link).removeClass("seguir");
                    $(link).addClass("abandonar yellow-text text-darken-4");
                }
            );

        });

        //ação de deixar de seguir um leilão
        $('.abandonar').on('click', e => {
            e.preventDefault();

            const link = $(e.target).parent();

            //enviar requisição para deixar de seguir o leilão
            $.post(
                '/Interessadas/AbandonarLeilao',
                $(link).data(),
                function () {
                    console.log('leilão foi abandonado!');
                    M.toast({ html: 'Você deixou de seguir o leilão!' });
                    //mudar o ícone e a classe do link
                    e.target.textContent = 'star_border';
                    $(link).removeClass("abandonar yellow-text text-darken-4");
                    $(link).addClass("seguir white-text");
                }
            );

        });

  }); // end of document ready
})(jQuery); // end of jQuery name space
