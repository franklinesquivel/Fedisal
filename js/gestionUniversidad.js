(function () {
    $(document).ready(function (){
        let id;
        $(".btnEliminar").click(function () {
            id = $(this).attr("iduniversidad");
        })

        $("#btnMdlEliminar").click(function () {
            if (id != undefined) {
                $.ajax({
                    type: 'POST',
                    url: 'GestionUniversidad.aspx/EliminarUniversidad',
                    data: JSON.stringify({ idUniversidad: id }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (r) {
                        r = r.d;
                        if (r == true) {
                            Materialize.toast('La universidad ha sido eliminada éxitosamente!', 1000, '', function () {
                                location.reload();
                            });

                        } else {
                            Materialize.toast('Ha ocurrido un error :$', 2000);
                        }
                    }
                })
            }
        })
    })
})()