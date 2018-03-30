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
                    console.log(respuesta);
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
                        <button id='btnAprobarDesembolso' class ='waves-effect waves-light btn'>Aprobar Desembolso</button>
                        <input type='hidden' id='txtIdCiclo' value='${idCiclo}' />`
                    ;
                    $("")
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
                    console.log("Listo");
                    $(".modal").modal('close');
                    desaparecerFila(idCiclo);
                } else {
                    console.log('Error');
                }
            }
        });
    });

    function desaparecerFila(idCiclo) {
        for (var i = 0; i < $("table#DGV tbody tr td").length; i++) {
            let elemento = $("table#DGV tbody tr td").eq(i).find("a");
            console.log($(elemento).attr("idCiclo") == idCiclo);
            if ($(elemento).attr("idCiclo") == idCiclo) {
                $(elemento).parent().parent().fadeOut("slow");
                break;
            }
        }
    }
})();