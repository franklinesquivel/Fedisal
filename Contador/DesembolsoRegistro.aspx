<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DesembolsoRegistro.aspx.cs" Inherits="DesembolsoRegistro" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="Registro de Desembolsos" runat="server" ID="Header" />
<body>
    <header>
        <uc:Menu Titulo="Usuarios" runat="server" ID="Menu" />
    </header>
    <main>
    <form id="frmMain" runat="server">
        <h3 class="center deep-purple-text text-lighten-2">Registro de Desembolso</h3>

        <div class="container row">

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <%--<asp:DropDownList ID="ddlScholar" runat="server"></asp:DropDownList>
                <asp:Label AssociatedControlID="ddlScholar" Text="Selecciona un becario" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    InitialValue = "0"
                    CssClass="error-tag"
                    ControlToValidate="ddlScholar"
                    ErrorMessage="Debes seleccionar un becario!"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>--%>
                <asp:HiddenField ID="idBecario" runat="server" />
                <asp:HiddenField ID="idCiclo" runat="server" />
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                <asp:Label AssociatedControlID="ddlType" Text="Selecciona un tipo de desembolso" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="customDdlValue" runat="server"
                    InitialValue = "0"
                    CssClass="error-tag"
                    ControlToValidate="ddlType"
                    ErrorMessage="Debes seleccionar un tipo de desembolso!"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtAmount" TextMode="Number" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtAmount" Text="Monto del Desembolso" runat="server"></asp:Label>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un valor"
                    Display="Dynamic"
                    ControlToValidate="txtAmount"
                    runat="server">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator
                    ID="valPositiveAmount"
                    ErrorMessage="Debe ingresar un monto mayor a 0!"
                    ControlToValidate="txtAmount"
                    OnServerValidate="validate_positiveValue"
                    CssClass="error-tag"
                    Display="Dynamic"
                    runat="server" />
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtDate" TextMode="Date" CssClass="datepicker" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtDate" Text="Fecha del desembolso [Opcional]" runat="server"></asp:Label>
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                
            </div>

            <div class="file-field input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                
            </div>

            <div class="input-field col s12">
                <center>
                    <asp:button text="Registrar" ID="btnRegisterData" CssClass="btn waves-effect waves-light" OnClick="btnRegisterData_Click" runat="server" />
                </center>
            </div>
        </div>
    </form>
    </main>
</body>
</html>
