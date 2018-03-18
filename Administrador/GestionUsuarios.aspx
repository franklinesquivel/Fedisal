<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionUsuarios.aspx.cs" Inherits="Administrador_GestionUsuarios" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="" runat="server" ID="Header" />
<body>
    <header>
        <uc:Menu Titulo="Administrador" runat="server" ID="Menu" />
    </header>
    <main>
        <form id="form1" runat="server">
            <div class="container">
                <asp:GridView
                    ID="gvUsuarios" CssClass="centered" runat="server"
                    AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Código"
                    DataSourceID="sdsUsuarios">
                    <Columns>
                        <asp:BoundField DataField="Código" HeaderText="Código" ReadOnly="True" SortExpression="Código" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                        <asp:BoundField DataField="Tipo de Usuario" HeaderText="Tipo de Usuario" SortExpression="Tipo de Usuario" />
                        <asp:TemplateField AccessibleHeaderText="Acciones">
                            <ItemTemplate>
                                <asp:HyperLink NavigateUrl='<%# string.Concat("ModificarUsuario.aspx?idUsuario=", Eval("Código")) %>' ID="btnEditarGV" runat="server" Visible="true" CssClass="btnModificar waves-effect waves-light btn modal-trigger" Text='Editar' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="sdsUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" SelectCommand="SELECT u.idUsuario AS [Código], ip.nombres AS [Nombre], ip.apellidos AS [Apellido], tu.descripcion AS [Tipo de Usuario] FROM
Usuario AS u
INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario
INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion;"></asp:SqlDataSource>
            </div>
        </form>
    </main>
</body>
</html>
