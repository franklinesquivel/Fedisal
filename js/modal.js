(function () {

    $(document).ready(function () {
        $('.modal').modal(); //Declara el modal

        $(".btnIncidente").click(function () {
            
            $('#modal1').modal('open'); //Abre modal
            let idBecario = $(this).attr("IdBecario");
            $('#txtIdBecario').val() = idBecario;
            $.ajax({
                type: 'POST',
                url: 'App_Code/Incidentes.cs/InsertarIncidente',
                cache: true,
                asyc: false,
                data: `{inci: ${inci}}`,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (r) {
                    if (r.d !=false) {
                        console.log("Registro hecho");
                    } else {
                        console.log("no se realizo")
                    }
                }
            });

        });
    })

})();