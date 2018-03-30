(function () {
    $(document).ready(function () {
        
    });

    $(document).on('click', '.btnMdlDetalle', function () {
        $.ajax({
            type: 'POST',
            url: 'VerExpediente.aspx/VerNotasCiclo',
            data: JSON.stringify({ idCiclo: $(this).attr("idCiclo") }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                console.log(r);
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
                                <td>${r.d[i]["NombreMat"]}</td>
                                <td>${r.d[i]["Nota"]}</td>
                            </tr>
                        `;
                    }
                    respuesta += `
                        </tbody>
                        </table>`;
                } else {
                    respuesta = `<h5>No hay asignaturas ingresadas</h5>`;
                }
                $("#contenMdl").html(respuesta);
            }
        });
    });
})()