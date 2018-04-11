(function () {
    $(document).ready(function () {

    });

    $(document).on('click', '.btnMdlDetalle', function () {
        var idCiclo = $(this).attr("idCiclo");
        $.ajax({
            type: 'POST',
            url: 'AprobarDesembolso.aspx/VerNotasCiclo',
            data: JSON.stringify({ idCiclo:  idCiclo}),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                let respuesta = ``;
                if (r.d != false) {
                    respuesta = `<table class='centered'>
                        <thead>
                            <th>Materia</th>
                            <th>Nota</th>
                        </thead>
                        <tbody>
                    `;
                    for (var i = 0; i < r.d.length; i++) {
                        respuesta += `
                            <tr>
                                <td> ${r.d[i]["NombreMat"]} </td>
                                <td> ${r.d[i]["Nota"]} </td>
                            </tr>
                        `;
                    }
                    respuesta += `
                        </tbody>
                        </table>
                        <button id='btnAprobarDesembolso' class ='center-align waves-effect waves-light btn'>Aprobar Desembolso</button>
                        <input type='hidden' id='txtIdCiclo' value='${idCiclo}' />`
                    ;
                } else {
                    respuesta = `<h5>No hay asignaturas ingresadas</h5>`;
                }
                $("#contenMdl").html(respuesta);
                $('.modal').modal('open');
            }
        });
    });

    $(document).on('click', '#btnAprobarDesembolso', function () {
        var idCiclo = $("#mdlDetalle #txtIdCiclo").val();

        $.ajax({
            type: 'POST',
            url: 'AprobarDesembolso.aspx/AprobarDesembolso',
            data: JSON.stringify({ idCiclo:  idCiclo}),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                if (r.d != false) {
                    $(".modal").modal('close');
                    Materialize.toast('Desembolso aprobado!', 1000);
                    desaparecerFila(idCiclo);
                } else {
                    Materialize.toast('Ocurrio un Error :(!', 1000);
                }
            }
        });
    });

    function desaparecerFila(idCiclo) {
        for (var i = 0; i < $("table#DGV tbody tr td").length; i++) {
            let elemento = $("table#DGV tbody tr td").eq(i).find("a");
            if ($(elemento).attr("idCiclo") == idCiclo) {
                $(elemento).parent().parent().fadeOut("slow");
                break;
            }
        }
    }
})();