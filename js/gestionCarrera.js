(function () {
    $(document).ready(function () {
        $('.modal').modal();
    });

    function eliminarCarrera() {
        $.ajax({
            type: 'POST',
            url: 'GestionCarreras.aspx/EliminarCarrera',
            data: JSON.stringify({ idCarrera: $("#mdlEliminar #txtIdCarrera").val() }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                console.log(r);
                if (r.d == true) {
                    $('#mdlEliminar').modal('close');
                    Materialize.toast('Eliminación exitosa!', 1000, '', "function(){ location.href = '/Administrador/GestionCarreras.aspx'}");
                } else {
                    Materialize.toast('Ocurrio un Error :(!', 1000);
                }
            }
        });
    }

    $(document).on('click', '#mdlEliminar', function (e) {
        if ($(e.target).attr("id") == $("#btnEliminar").attr("id")) {
            eliminarCarrera();
        }
    });

    $(document).on('click', '.eliminarModal', function () {
        $("#mdlEliminar #txtIdCarrera").val($(this).attr('idCarrera'));
        $('#mdlEliminar').modal('open');
    });
})()
