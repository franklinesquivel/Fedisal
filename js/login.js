(function () {

    $(document).ready(function () {

        
    });

    
})();

function enviarDatos() {
    var usuario = {
        Username: $("#txtUsername").val(),
        Password: $("#txtPassword").val()
    }, response = false, pattUsername = new RegExp(/^[A-Z]{4}[0-9]{7}$/, 'i'); //A - Administrador, C- Contador, G - GestorAcademico

    //if(pattUsername.test(usuario.Username) && usuario.Password.length > 0){
        $.ajax({
            type: 'POST',
            url: 'Default.aspx/ValidarUsuario',
            cache: true,
            asyc: false,
            data: `{usuario: ${JSON.stringify(usuario)}}`,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                console.log(r);
            }
        });
        //response = true;
    //} else {
      //  console.log('No valido');
    //}
    return response;
}