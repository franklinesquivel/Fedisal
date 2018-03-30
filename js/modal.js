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
                data: JSON.stringify({ idTipo: $("#ddlIncidentes").val(), idBecario: $('#txtIdBecario').val() }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (r) {
                    console.log(r);
                    if (r.d != false) {
                        console.log("Registro hecho");
                    } else {
                        console.log("no se realizo el registro")
                    }
                }, error: function (e) {
                    console.log(e);
                }
            });
        });
    })




})();