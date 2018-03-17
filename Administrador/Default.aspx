<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrador_Default" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<html xmlns="http://www.w3.org/1999/xhtml">
    
    <uc:Header Titulo="" runat="server" ID="Header"/>

    <body>
        <header>
            <uc:Menu Titulo="Administrador" runat="server" ID="Menu" />
        </header>
        <main>
        </main>

    </body>
</html>
