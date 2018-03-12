<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModificarProgramaBeca.aspx.cs" Inherits="ModificarProgramaBeca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fedisal - Modificar Programa de Becas</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" initial-scale="1.0" />
    <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <script src="js/jquery.min.js"></script>
    <script src="js/materialize.min.js"></script>
    <script src="js/init.js"></script>
</head>
<body>
    <form id="frmMain" runat="server">
        <h3 class="center deep-purple-text text-lighten-2">Modificar Programa de Becas</h3>
        <div class="container row">
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3" id="resultCode" runat="server">
                
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:Label ID="lblName" AssociatedControlID="txtName" runat="server" Text="Nombre"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName"
                    CssClass="error-tag"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar un nombre!"></asp:RequiredFieldValidator>
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" CssClass="materialize-textarea" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtDescription" Text="Descripción" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDescription"
                    CssClass="error-tag"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar una descripción!"></asp:RequiredFieldValidator>
            </div>
            <div class="input-field col s12 center-align">
                <asp:button text="Modificar" ID="btnRegister" OnClick="btnRegister_Click" CssClass="btn waves-effect waves-light"  runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
