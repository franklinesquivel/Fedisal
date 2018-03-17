(function () {
    $(document).ready(function () {
        $('.modal').modal();
    });

    function eliminarTipo() {
        $.ajax({
            type: 'POST',
            url: 'GestionTipoIncidente.aspx/EliminarTipo',
            data: JSON.stringify({ idTipo: $("#mdlEliminar #txtIdTipo").val() }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                console.log(r);
                if (r.d == true) {
                    $('#mdlEliminar').modal('close');
                    Materialize.toast('Eliminación exitosa!', 1000, '', "function(){ location.href = '/Administrador/GestionTipoIncidente.aspx'}");
                } else {
                    Materialize.toast('Ocurrio un Error :(!', 1000);
                }
            }
        });
    }

    $(document).on('click', '#mdlEliminar', function (e) {
        if ($(e.target).attr("id") == $("#btnEliminar").attr("id")) {
            eliminarTipo();
        }
    });

    $(document).on('click', '.eliminarModal', function () {
        $("#mdlEliminar #txtIdTipo").val($(this).attr('idTipoInicidente'));
        $('#mdlEliminar').modal('open');
    });
})()