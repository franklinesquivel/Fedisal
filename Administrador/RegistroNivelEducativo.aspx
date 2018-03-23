﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroNivelEducativo.aspx.cs" Inherits="Administrador_RegistroNivelEducativo" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <uc:Header Titulo="Fedisal - Nivel Educativo" runat="server" ID="Header" />
    <body>
        <header>
            <uc:Menu Titulo="Registro de Nivel Educativo" runat="server" ID="Menu" />
        </header>
        <main>
            <div class="row">
                <form id="frmMain" runat="server">
                <h3 class="center deep-purple-text text-lighten-2" runat="server" id="title">Registro de Nivel Educativo</h3>
                <div class="container row">
                    <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                        
                        <p>ingrese nombre:</p><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:Label ID="lblName" AssociatedControlID="txtName" runat="server" Text="Nombre"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtName"
                            CssClass="error-tag"
                            Display="Dynamic"
                            ErrorMessage="Debes ingresar un nombre"></asp:RequiredFieldValidator>
                    </div>

                    <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                        
                        <p>ingrese descripcion:</p><asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                        <asp:Label ID="lblDescripcion" AssociatedControlID="txtDescripcion" runat="server" Text="Descripcion"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtDescripcion"
                            CssClass="error-tag"
                            Display="Dynamic"
                            ErrorMessage="Debes ingresar descripcion"></asp:RequiredFieldValidator>
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