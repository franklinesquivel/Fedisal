<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotasRegistro.aspx.cs" Inherits="NotasRegistro" %>

<!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Fedisal - Registro de Notas</title>
        <link href="css/materialize.min.css" rel="stylesheet" />
        <meta name="viewport" content="width=device-width" initial-scale="1.0" />
        <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>

        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

        <script src="js/jquery.min.js"></script>
        <script src="js/materialize.min.js"></script>
        <script src="js/init.js"></script>
    </head>
    <body>
        <br />
        <form id="frmNotas" runat="server">
            <h3 class="center light-blue-text text-lighten-2">Registro de notas</h3>
            <div class="container row">
                <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                    <asp:Label AssociatedControlID="txtNombreMateria" Text="Ingrese el Nombre de la Materia: " runat="server" />
                    <asp:TextBox ID="txtNombreMateria" CssClass="validate" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Debe ingresar el nombre de la materia!" CssClass="error-tag" ControlToValidate="txtNombreMateria" runat="server" />
                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Ingrese solo letras y numeros" ValidationExpression="^[A-Za-z12345áéíóúñÑ ]*$" ControlToValidate="txtNombreMateria" runat="server" />
                </div>

                <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                    <asp:Label AssociatedControlID="txtNotaMateria" Text="Ingrese la Nota de la Materia: " runat="server" />
                    <asp:TextBox ID="txtNotaMateria" CssClass="validate" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Debe ingresar la nota de la materia!" CssClass="error-tag" ControlToValidate="txtNotaMateria" runat="server" /><br />
                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="error-tag center" ErrorMessage="Ingrese solo numeros o la nota debe estar entre 1-10!" ValidationExpression="^[0-9.]*$" ControlToValidate="txtNotaMateria" runat="server" /><br />
                    <asp:RangeValidator CssClass="error-tag" ErrorMessage="" MinimumValue="0" MaximumValue="10" Type="Double" ControlToValidate="txtNotaMateria" runat="server" />
                </div>
                <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                    <asp:DropDownList ID="ddlTercioSuperior" runat="server">
                        <asp:ListItem Text="Cumplio" Value="True" />
                        <asp:ListItem Text="No cumplio" Value="False" />
                    </asp:DropDownList>
                <asp:Label AssociatedControlID="ddlTercioSuperior" Text="¿Cumplio el Tercio Superior?: " runat="server" />
                <asp:RequiredFieldValidator ID="rfv1" runat="server" InitialValue = "0" CssClass="error-tag" ControlToValidate="ddlTercioSuperior" ErrorMessage="Debes seleccionar un valor!" Display="Dynamic">
                </asp:RequiredFieldValidator>
                </div>
                <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                    <asp:DropDownList ID="ddlCiclo" runat="server">

                    </asp:DropDownList>
                <asp:Label AssociatedControlID="ddlCiclo" Text="Elija el ciclo: " runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue = "0" CssClass="error-tag" ControlToValidate="ddlCiclo" ErrorMessage="Debes seleccionar un valor!" Display="Dynamic">
                </asp:RequiredFieldValidator>
                </div>
                <div class="input-field col s12 center-align">
                    <asp:Button text="Ingresar Nota" ID="btnRegistrar" OnClick="btnRegistrar_Click" CssClass="btn waves-effect waves-light"  runat="server" />
            </div>
            </div>
        </form>
    </body>
    </html>
