<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionProgramaBecas.aspx.cs" Inherits="GestionProgramaBecas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Fedisal - Gestión Programas de Becas</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" initial-scale="1.0" />
    <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <script src="js/jquery.min.js"></script>
    <script src="js/materialize.min.js"></script>
    <script src="js/init.js"></script>
    <script src="js/gestionProgramas.js"></script>
</head>
<body>
    <main class="container">
        <div class="row">
            <table class="centered">
                <thead>
                    <tr>
                        <th>Código</th>
                        <th>Nombre</th>
                        <th>Descripción</th>
                        <th>Cantidad de Becarios</th>
                        <th colspan="2">Opciones</th>
                    </tr>
                </thead>
                <tbody id="listaProgramas">

                </tbody>
            </table>
        </div>
    </main>
    <div id="modalEliminar" class="modal">
        <div class="modal-content">
            <h4 class="center-align">Eliminación de programa</h4>
            <p class="center-align">¿Desea eliminar este programa?</p>
            <input type="hidden" value="" runat="server" id="txtidPrograma"/>
        </div>
        <div class="modal-footer">
            <a href="#!" class="modal-action waves-effect waves-green btn-flat" id="btnEliminar">Eliminar</a>
            <a href="#!" class="modal-action modal-close waves-effect waves-red btn-flat">Cancelar</a>
        </div>
    </div>
</body>
</html>
