(function () {

    $(document).ready(function () {
        $('.modal').modal(); //Declara el modal
        $(".btnIncidente").click(function () {
            $('#modal1').modal('open'); //Abre modal
            let idBecario = $(this).attr("IdBecario");
            console.log(idBecario);
        });
    })

})();