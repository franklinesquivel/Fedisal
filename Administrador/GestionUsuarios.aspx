<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionUsuarios.aspx.cs" Inherits="Administrador_GestionUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <div class="container">
        <asp:GridView
            ID="gvUsuarios"  CssClass="centered" runat="server"
            AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Código"
            DataSourceID="sdsUsuarios">
            <Columns>
                <asp:BoundField DataField="Código" HeaderText="Código" ReadOnly="True" SortExpression="Código" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Tipo de Usuario" HeaderText="Tipo de Usuario" SortExpression="Tipo de Usuario" />
                <asp:CommandField AccessibleHeaderText="Acciones" ButtonType="Button" ControlStyle-CssClass="btn" SelectText="Editar" ShowSelectButton="True" HeaderText="Acciones" >
<ControlStyle CssClass="btn"></ControlStyle>
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" SelectCommand="SELECT u.idUsuario AS [Código], ip.nombres AS [Nombre], ip.apellidos AS [Apellido], tu.descripcion AS [Tipo de Usuario] FROM
Usuario AS u
INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario
INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion;"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
