(function () {

    $(document).ready(function () {
        $('.modal').modal(); //Declara el modal
        $('selec').material_select();
 

        $(".btnIncidente").click(function () {
            let idBecario = $(this).attr('IdBecario');
            $('#txtIdBecario').val(idBecario);
            $('#modal1').modal('open'); //Abre modal
        });

        $("#btnAplicar").click(function () {
            $.ajax({
                type: 'POST',
                url: 'IncidentesRegistro.aspx/InsertarIncidente',
                cache: true,
                asyc: false,
                data: JSON.stringify({ idTipo: $("#ddlIncidentes").val(), idBecario: $('#txtIdBecario').val(), fecha: $("#dateApply").val(), descripcion: $("#details").val() }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (r) {
                    if (r.d != false) {
                        Materialize.toast("Incidente aplicado exitosamente!", 2000, '', "function () { location.href = 'IncidentesRegistro.aspx' }");
                    } else {
                        Materialize.toast('Ocurrio un Error :(!', 1000);
                    }
                }, error: function (e) {
                    console.log(e);
                }
            });
        });
    })




})();