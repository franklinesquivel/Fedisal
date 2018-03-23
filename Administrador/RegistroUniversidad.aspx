<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroUniversidad.aspx.cs" Inherits="Administrador_RegistroUniversidad" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <uc:Header Titulo="Fedisal - Universidad" runat="server" ID="Header" />
    <body>
        <header>
            <uc:Menu Titulo="Registro de Universidad" runat="server" ID="Menu" />
        </header>
        <main>
            <div class="row">
                <form id="frmMain" runat="server">
                    <asp:HiddenField ID="idUniversidad" runat="server" />
                <div class="container row">
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
                        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                        <asp:Label ID="lblDireccion" AssociatedControlID="txtDireccion" runat="server" Text="Direccion"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtDireccion"
                            CssClass="error-tag"
                            Display="Dynamic"
                            ErrorMessage="Debes ingresar direccion"></asp:RequiredFieldValidator>
                    </div>

                    <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                        <asp:Label ID="lblTelefono" AssociatedControlID="txtTelefono" runat="server" Text="Telefono"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtTelefono"
                            CssClass="error-tag"
                            Display="Dynamic"
                            ErrorMessage="Debes ingresar numero telefonico"></asp:RequiredFieldValidator>
                    </div>

                    <div class="input-field col s12 center-align">
                        <asp:Button Text="Registrar" ID="btnRegister" OnClick="btnRegister_Click" CssClass="btn waves-effect waves-light" runat="server" />
                    </div>
                </div>
            </form>
            </div>
        </main>
    </body>
</html>