(function () {
    $(document).ready(function (){
        let id;
        $(".eliminarModal").click(function () {
            id = $(this).attr("idnivel");
        })

        $("#btnMdlEliminar").click(function () {
            if (id != undefined) {
                $.ajax({
                    type: 'POST',
                    url: 'GestionNivelEducativo.aspx/EliminarNivel',
                    data: JSON.stringify({ idNivel: id }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (r) {
                        r = r.d;
                        if (r == true) {
                            Materialize.toast('El nivel ha sido eliminado éxitosamente!', 1000, '', function () {
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