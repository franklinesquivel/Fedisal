<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModificarUsuario.aspx.cs" Inherits="Administrador_ModificarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Fedisal - Login</title>
    <link href="/css/materialize.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" initial-scale="1.0" />
    <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <script src="/js/jquery.min.js"></script>
    <script src="/js/materialize.min.js"></script>
    <script src="/js/init.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <main class="container row">
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtNombre">Nombres</label>
            <input type="text" name="txtNombre" id="txtNombre" runat="server"/>
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtApellido">Apellidos</label>
            <input type="text" name="txtApellido" id="txtApellido" runat="server"/>
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtTel">Teléfono</label>
            <input type="text" name="txtTel" id="txtTel" runat="server"/>
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtFechaNac">Fecha de Nacimiento</label>
            <input type="date" class="datepicker" name="txtFechaNac" id="txtFechaNac" runat="server"/>
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtEmail">Correo Electrónico</label>
            <input type="text" name="txtEmail" id="txtEmail" runat="server"/>
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtResidencia">Residencia</label>
            <textarea class="materialize-textarea" type="text" name="txtResidencia" id="txtResidencia" runat="server"></textarea>
        </div>
    </main>
        <asp:SqlDataSource ID="sdsDataUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" SelectCommand="SELECT * FROM
Usuario AS u
INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario
INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion
WHERE u.idUsuario = @idTipoUsuario;">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="null" Name="idTipoUsuario" QueryStringField="idUsuario" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
