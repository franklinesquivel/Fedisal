(function () {
    $(document).ready(function () {
        $('.modal').modal();
        obtenerProgramas();
    });

    function obtenerProgramas() {
        $.ajax({
            type: 'POST',
            url: 'GestionProgramaBecas.aspx/ObtenerProgramas',
            cache: true,
            asyc: false,
            data: "{peticion: 1}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                if (r.d != false) {
                    var tr = '';
                    for (var i = 0; i < r.d.length; i++) {
                        tr +=
                            `
                            <tr idPrograma='${r.d[i][0]}'>
                                <td>${r.d[i][0]}</td>
                                <td>${r.d[i][1]}</td>
                                <td>${r.d[i][2]}</td>
                                <td>${r.d[i][3]}</td>
                            `;
                        if(r.d[i][3] > 0){
                            tr += `<td colspan='2'><a href='ModificarProgramaBeca.aspx?idPrograma=${r.d[i][0]}'>Modificar</a></td>`;
                        } else {
                            tr += `
                                <td colspan='1'><a href='ModificarProgramaBeca.aspx?${r.d[i][0]}'>Modificar</a></td>
                                <td colspan='1'><a href='#' class='eliminarModal'>Eliminar</a></td>
                            `;
                        }
                        tr += `</tr>`;
                    }
                    $('#listaProgramas').html(tr);
                } else {
                    console.log("Es false");
                }
            }
        });
    }

    $(document).on('click', '.eliminarModal', function () {
        $("#txtidPrograma").val($(this).parent().parent().attr('idPrograma'));
        $('#modalEliminar').modal('open');
    });

    $(document).on('click', '#modalEliminar', function (e) {
        if($(e.target).attr("id") == $("#btnEliminar").attr("id")){
            eliminarPrograma();
        }
    });

    function eliminarPrograma() {
        $.ajax({
            type: 'POST',
            url: 'GestionProgramaBecas.aspx/EliminarPrograma',
            data: JSON.stringify({ idPrograma: $("#txtidPrograma").val() }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                if (r.d == true) {
                    var element = null;
                    for (var i = 0; i < $("tbody tr").length; i++) {
                        if ($("tbody tr").eq(i).attr("idPrograma") == $("#txtidPrograma").val()) {
                            element = $("tbody tr").eq(i);
                        }
                    }
                    if(element != null){
                        $(element).fadeOut();
                    }
                    Materialize.toast('Eliminación exitosa!', 1000);
                    $('#modalEliminar').modal('close');
                } else {
                    Materialize.toast('Ocurrio un Error :(!', 1000);
                }
            }
        });
    }
})()