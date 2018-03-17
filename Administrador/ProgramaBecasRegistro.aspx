<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProgramaBecasRegistro.aspx.cs" Inherits="ProgramaBecasRegistro" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <uc:Header Titulo="Fedisal - Programa Becas" runat="server" ID="Header" />

    <body>
        <header>
            <uc:Menu Titulo="Registro de Programa de Becas" runat="server" ID="Menu" />
        </header>
        <main>
            <form id="frmMain" runat="server">
                <h3 class="center deep-purple-text text-lighten-2">Registro de Programa de Becas</h3>
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
                        <asp:Button Text="Registrar" ID="btnRegister" OnClick="btnRegister_Click" CssClass="btn waves-effect waves-light" runat="server" />
                    </div>
                </div>
            </form>
        </main>

    </body>
</html>
