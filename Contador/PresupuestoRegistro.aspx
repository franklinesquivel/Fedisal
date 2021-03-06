﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PresupuestoRegistro.aspx.cs" Inherits="PresupuestoRegistro" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="Gestión de Usuarios" runat="server" ID="Header" />
<body>
    <header>
        <uc:Menu Titulo="Usuarios" runat="server" ID="Menu" />
    </header>
    <main>
    <form id="frmMain" runat="server">
        <h3 class="center deep-purple-text text-lighten-2">Registro de Presupuesto</h3>

        <div class="container row">

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:DropDownList ID="ddlScholar" runat="server"></asp:DropDownList>
                <asp:Label AssociatedControlID="ddlScholar" Text="Selecciona un becario" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    InitialValue = "0"
                    CssClass="error-tag"
                    ControlToValidate="ddlScholar"
                    ErrorMessage="Debes seleccionar un becario!"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtLibro" TextMode="Number" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtLibro" Text="Monto en libros" runat="server"></asp:Label>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un valor"
                    Display="Dynamic"
                    ControlToValidate="txtLibro"
                    runat="server">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator
                    ErrorMessage="Debe ingresar un monto mayor a 0!"
                    ControlToValidate="txtLibro"
                    OnServerValidate="validate_positiveValue"
                    CssClass="error-tag"
                    Display="Dynamic"
                    runat="server" />
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtColegiatura" TextMode="Number" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtColegiatura" Text="Monto en colegiatura" runat="server"></asp:Label>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un valor"
                    Display="Dynamic"
                    ControlToValidate="txtColegiatura"
                    runat="server">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator
                    ErrorMessage="Debe ingresar un monto mayor a 0!"
                    ControlToValidate="txtColegiatura"
                    OnServerValidate="validate_positiveValue"
                    CssClass="error-tag"
                    Display="Dynamic"
                    runat="server" />
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtManutencion" TextMode="Number" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtManutencion" Text="Monto en manutención" runat="server"></asp:Label>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un valor"
                    Display="Dynamic"
                    ControlToValidate="txtManutencion"
                    runat="server">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator
                    ErrorMessage="Debe ingresar un monto mayor a 0!"
                    ControlToValidate="txtManutencion"
                    OnServerValidate="validate_positiveValue"
                    CssClass="error-tag"
                    Display="Dynamic"
                    runat="server" />
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtMatricula" TextMode="Number" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtMatricula" Text="Monto en matricula" runat="server"></asp:Label>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un valor"
                    Display="Dynamic"
                    ControlToValidate="txtMatricula"
                    runat="server">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator
                    ErrorMessage="Debe ingresar un monto mayor a 0!"
                    ControlToValidate="txtMatricula"
                    OnServerValidate="validate_positiveValue"
                    CssClass="error-tag"
                    Display="Dynamic"
                    runat="server" />
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtOtros" TextMode="Number" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtOtros" Text="Monto en otros" runat="server"></asp:Label>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un valor"
                    Display="Dynamic"
                    ControlToValidate="txtOtros"
                    runat="server">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator
                    ErrorMessage="Debe ingresar un monto mayor a 0!"
                    ControlToValidate="txtOtros"
                    OnServerValidate="validate_positiveValue"
                    CssClass="error-tag"
                    Display="Dynamic"
                    runat="server" />
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtGraduacion" TextMode="Number" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtOtros" Text="Monto en trabajo de graduación" runat="server"></asp:Label>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un valor"
                    Display="Dynamic"
                    ControlToValidate="txtGraduacion"
                    runat="server">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator
                    ErrorMessage="Debe ingresar un monto mayor a 0!"
                    ControlToValidate="txtGraduacion"
                    OnServerValidate="validate_positiveValue"
                    CssClass="error-tag"
                    Display="Dynamic"
                    runat="server" />
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
