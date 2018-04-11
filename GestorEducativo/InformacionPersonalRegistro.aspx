<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InformacionPersonalRegistro.aspx.cs" Inherits="InformacionPersonalRegistro" %>
<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 <uc:Header Titulo="" runat="server" ID="Header"/>

<body>
     <header>
            <uc:Menu Titulo="Gestor Educativo" runat="server" ID="Menu" />
        </header>
        <main class="container">
    <form id="frmMain" runat="server">
        <h3 class="center deep-purple-text text-lighten-2">Registro de Información Personal</h3>
        <div class="container row">
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:Label ID="lblName" AssociatedControlID="txtName" runat="server" Text="Nombre"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName"
                    CssClass="error-tag"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar un nombre!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator CssClass="error-tag" Display="Dynamic" ErrorMessage="Ingrese un nombre valido" ControlToValidate="txtName" ValidationExpression="^[A-Z][a-zA-Záéíóúñ ]*$" runat="server" />
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:Label ID="lblLastName" AssociatedControlID="txtLastName" runat="server" Text="Apellidos"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtLastName"
                    CssClass="error-tag"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar un apellido!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator CssClass="error-tag" Display="Dynamic" ErrorMessage="Ingrese un apellido valido" ControlToValidate="txtLastName" ValidationExpression="^[A-Z][a-zA-Záéíóúñ ]*$" runat="server" />
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtDUI" runat="server"></asp:TextBox>
                <asp:Label ID="lblDUI" AssociatedControlID="txtDUI" runat="server" Text="DUI"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtDUI"
                    CssClass="error-tag"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar un N° de DUI!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    Display="Dynamic" 
                    CssClass="error-tag"
                    ControlToValidate="txtDUI"
                    ValidationExpression="^[0-9]{8}-{1}[0-9]{1}$"
                    ErrorMessage="Debes ingresar un formato de DUI válido!"></asp:RegularExpressionValidator>
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="dtpBirthdate" CssClass="datepicker" runat="server"></asp:TextBox>
                <asp:Label ID="lblBirthdate" AssociatedControlID="dtpBirthdate" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="dtpBirthdate"
                    CssClass="error-tag"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar una fecha de nacimiento!"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" 
                    ControlToValidate="dtpBirthdate"
                    Display="Dynamic"
                    CssClass="error-tag"
                    OnServerValidate="CustomValidator1_ServerValidate"
                    runat="server" ErrorMessage="La fecha no puede ser mayor a la actual!"></asp:CustomValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ErrorMessage="El usuario debe ser mayor de edad y no debe sobrepasar los 30 años" ValidationExpression="^199[0-9]-[0-9][0-9]-[0-9][0-9]$" ControlToValidate="dtpBirthdate" runat="server" />
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtResidence" TextMode="MultiLine" CssClass="materialize-textarea" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtResidence" Text="Residencia" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtResidence"
                    CssClass="error-tag"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar una dirección de residencia!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Ingrese solo letras y numeros" ControlToValidate="txtResidence" ValidationExpression="^[A-Za-zñÑ.#,áéíóú 0-9-]*$" runat="server" />
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                <asp:Label ID="lblTelephone" AssociatedControlID="txtTelephone" runat="server" Text="Teléfono"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtTelephone"
                    CssClass="error-tag"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar un número de teléfono!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                    Display="Dynamic" 
                    CssClass="error-tag"
                    ControlToValidate="txtTelephone"
                    ValidationExpression="^(2|7|6){1}[0-9]{3}[- ]{1}[0-9]{4}$"
                    ErrorMessage="Debes ingresar un formato de teléfono válido!"></asp:RegularExpressionValidator>
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Correo Electrónico"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtEmail"
                    CssClass="error-tag"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar un email!"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator2" 
                    ControlToValidate="txtEmail"
                    Display="Dynamic"
                    CssClass="error-tag"
                    OnServerValidate="CustomValidator2_ServerValidate"
                    runat="server" ErrorMessage="Debes ingresar un formato de correo válido!"></asp:CustomValidator>
            </div>

            <div class="input-field col s12 center-align">
                <asp:button text="Registrar" ID="btnRegister" OnClick="btnRegister_Click" CssClass="btn waves-effect waves-light"  runat="server" />
            </div>
        </div>
    </form>
    </main>
</body>
</html>
