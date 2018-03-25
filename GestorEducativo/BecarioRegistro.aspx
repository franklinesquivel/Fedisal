<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BecarioRegistro.aspx.cs" Inherits="BecarioRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Fedisal - Registrar Becario</title>
    <link href="/css/materialize.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" initial-scale="1.0" />
    <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <script src="/js/jquery.min.js"></script>
    <script src="/js/materialize.min.js"></script>
    <script src="/js/init.js"></script>
</head>
<body>
    <form id="frmMain" runat="server">
        <h3 class="center deep-purple-text text-lighten-2">Registro de Becarios</h3>
        <div class="container row">
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3"> <!-- Programa de Beca -->
                <asp:DropDownList ID="ddlProgram" runat="server"></asp:DropDownList>
                <asp:Label AssociatedControlID="ddlProgram" Text="Seleccionar Programa de Beca" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    InitialValue = "0"
                    CssClass="error-tag"
                    ControlToValidate="ddlProgram"
                    ErrorMessage="Debes seleccionar un programa de beca!"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3"> <!-- DUI -->
                <asp:DropDownList ID="ddlUser" runat="server"></asp:DropDownList>
                <asp:Label AssociatedControlID="ddlUser" Text="Seleccionar DUI" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    InitialValue = "0"
                    CssClass="error-tag"
                    ControlToValidate="ddlUser"
                    ErrorMessage="Debes seleccionar un usuario!"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3"> <!-- Universidad -->
                <asp:DropDownList ID="ddlUniversity" runat="server"></asp:DropDownList>
                <asp:Label AssociatedControlID="ddlUniversity" Text="Seleccionar Universidad" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    InitialValue = "0"
                    CssClass="error-tag"
                    ControlToValidate="ddlUniversity"
                    ErrorMessage="Debes seleccionar una universidad!"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3"> <!-- Carrera -->
                <asp:DropDownList ID="ddlProfession" runat="server"></asp:DropDownList>
                <asp:Label AssociatedControlID="ddlProfession" Text="Seleccionar Carrera" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    InitialValue = "0"
                    CssClass="error-tag"
                    ControlToValidate="ddlProfession"
                    ErrorMessage="Debes seleccionar una carrera!"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3"> <!-- Nivel Educativo -->
                <asp:DropDownList ID="ddlDegree" runat="server"></asp:DropDownList>
                <asp:Label AssociatedControlID="ddlDegree" Text="Seleccionar Nivel Educativo" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    InitialValue = "0"
                    CssClass="error-tag"
                    ControlToValidate="ddlDegree"
                    ErrorMessage="Debes seleccionar nievl educativo!"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
            <div class="col s12 m12 l6 offset-s1 offset-m3 offset-l3"> <!-- Fechas -->
                <div class="input-field col l6 m12 s12"> <!-- Fecha de Inicio -->
                    <asp:TextBox ID="dtpStart" CssClass="datepicker" runat="server"></asp:TextBox>
                    <asp:Label ID="lblStartDate" AssociatedControlID="dtpStart" runat="server" Text="Fecha de Inicio de Beca"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="dtpStart"
                        CssClass="error-tag"
                        Display="Dynamic"
                        ErrorMessage="Debes ingresar una fecha de inicio!"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" 
                        ControlToValidate="dtpStart"
                        Display="Dynamic"
                        CssClass="error-tag"
                        OnServerValidate="CustomValidator1_ServerValidate"
                        runat="server" ErrorMessage="La fecha incial no puede ser mayor a la final!"></asp:CustomValidator>
                </div>
                <div class="input-field col l6 m12 s12"> <!-- Fecha Fin -->
                    <asp:TextBox ID="dtpEnd" CssClass="datepicker" runat="server"></asp:TextBox>
                    <asp:Label ID="lblEndDate" AssociatedControlID="dtpEnd" runat="server" Text="Fecha Fin de Beca"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="dtpEnd"
                        CssClass="error-tag"
                        Display="Dynamic"
                        ErrorMessage="Debes ingresar una fecha de fin!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="input-field col s12 center-align"> <!-- Botón de registro -->
                <asp:button text="Registrar" ID="btnRegister" OnClick="btnRegister_Click" CssClass="btn waves-effect waves-light"  runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
