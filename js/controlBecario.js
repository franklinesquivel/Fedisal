(function () { //Archivo de ControlBecarios.aspx (Contador)
    $(document).ready(function () {
        $('.modal').modal();
    });

    function bloquearCiclo() {
        $.ajax({
            type: 'POST',
            url: 'ControlBecarios.aspx/BloquearCiclo',
            data: JSON.stringify({ idCiclo: $("#mdlLock #txtIdCiclo").val() }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                console.log(r);
                if (r.d == true) {
                    $('#mdlLock').modal('close');
                    Materialize.toast('Bloqueo Exitoso!', 1000, '', function () { location.reload(); });
                } else {
                    Materialize.toast('Ocurrio un Error :(!', 1000);
                }
            }
        });
    }

    $(document).on('click', '#mdlLock', function (e) {
        if ($(e.target).attr("id") == $("#btnBloquear").attr("id")) {
            bloquearCiclo();
        }
    });

    $(document).on('click', '.lockOption', function () {
        $("#mdlLock #txtIdCiclo").val($(this).attr('idCiclo'));
        //$('#mdlLock').modal('open');
    });
})()