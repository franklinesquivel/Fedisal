<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModificarUsuario.aspx.cs" Inherits="Administrador_ModificarUsuario" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="" runat="server" ID="Header" />
<body>
    <header>
        <uc:Menu Titulo="Administrador" runat="server" ID="Menu" />
    </header>
    <main class="container"><br />
    <form id="form1" runat="server">
        <h3 class="center deep-purple-text text-lighten-2" runat="server" id="tituloF">Registro de Usuarios</h3>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtNombre">Nombres</label>
            <input type="text" name="txtNombre" runat="server" id="txtNombre"/>
            <asp:RequiredFieldValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Debe ingresar un nombre" ControlToValidate="txtNombre" runat="server" />
            <asp:RegularExpressionValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Ingrese solo letras y sus dos nombres, Ejemplo: Pedro Jose" ValidationExpression="^[A-ZÑÁÉÍÓÚ]{1}[a-zñáéíóú]* [A-ZÑÁÉÍÓÚ]{1}[a-zñáéíóú]*$" ControlToValidate="txtNombre" runat="server" />
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtApellido">Apellidos</label>
            <input type="text" name="txtApellido" id="txtApellido" runat="server"/>
            <asp:RequiredFieldValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Debe ingresar un apellido" ControlToValidate="txtApellido" runat="server" />
            <asp:RegularExpressionValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Ingrese solo letras y sus dos apellidos, Ejemplo: Lopez Hernandez" ValidationExpression="^[A-ZÑÁÉÍÓÚ]{1}[a-zñáéíóú]* [A-ZÑÁÉÍÓÚ]{1}[a-zñáéíóú]*$" ControlToValidate="txtApellido" runat="server" />
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtDui">DUI</label>
            <input type="text" name="txtDui" id="txtDui" runat="server"/>
            <asp:RequiredFieldValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Debe ingresar su DUI" ControlToValidate="txtDui" runat="server" />
            <asp:RegularExpressionValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Ingrese un numero de DUI valido: 08696375-9" ValidationExpression="^[0-9]{8}[-]{1}[0-9]{1}$" ControlToValidate="txtDui" runat="server" />
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtTel">Teléfono</label>
            <input type="text" name="txtTel" id="txtTel" runat="server"/>
            <asp:RequiredFieldValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Debe ingresar un teléfono" ControlToValidate="txtTel" runat="server" />
            <asp:RegularExpressionValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Ingrese un numero de telefono valido: 7777 7777 ó 7777-7777" ValidationExpression="^[276]{1}[0-9]{3}[- ]{1}[0-9]{4}$" ControlToValidate="txtTel" runat="server" />
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtFechaNac">Fecha de Nacimiento</label>
            <input type="date" class="datepicker" name="txtFechaNac" id="txtFechaNac" runat="server"/>
            <asp:RequiredFieldValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Debe ingresar su fecha de nacimiento" ControlToValidate="txtFechaNac" runat="server" />
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtEmail">Correo Electrónico</label>
            <input type="text" name="txtEmail" id="txtEmail" runat="server"/>
            <asp:RequiredFieldValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Debe ingresar su correo electrónico" ControlToValidate="txtEmail" runat="server" />
            <asp:RegularExpressionValidator ErrorMessage="Ingrese un correo valido" Display="Dynamic" CssClass="error-tag" ValidationExpression="^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$" ControlToValidate="txtEmail" runat="server" />
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <label for="txtResidencia">Residencia</label>
            <textarea class="materialize-textarea" type="text" name="txtResidencia" id="txtResidencia" runat="server"></textarea>
            <asp:RequiredFieldValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Debe ingresar su residencia" ControlToValidate="txtResidencia" runat="server" />
            <asp:RegularExpressionValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Ingrese solo letras y numeros" ControlToValidate="txtResidencia" ValidationExpression="^[A-Za-zñÑ.#,áéíóú 0-9-]*$" runat="server" />
        </div>
        <label for="ddlTipoUsuario">Tipo de usuario</label>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            
            <asp:DropDownList CssClass="form-control" ID="ddlTipoUsuario" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator Display="Dynamic" CssClass="error-tag" ErrorMessage="Debe seleccionar un valor" ControlToValidate="ddlTipoUsuario" runat="server" />
        
        </div>
        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
            <asp:Button Text="" CssClass="btn waves-effect waves-light" ID="btnUsuarios" OnClick="btnUsuarios_Click" runat="server" />
        </div>
        <div class="clearfix"><br /></div>
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
    </main>
</body>
</html>
