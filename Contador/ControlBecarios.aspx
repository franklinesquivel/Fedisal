<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ControlBecarios.aspx.cs" Inherits="Contador_ControlBecarios" %>


<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="Control de Becarios" runat="server" ID="Header" />
<body>
    <header>
        <uc:Menu Titulo="Usuarios" runat="server" ID="Menu" />
    </header>
    <br />
    <main class="container">
        <form runat="server" id="frmControl">
            <div class="row">
                <div class="input-field col s6">
                    <asp:TextBox runat="server" ID="txtBuscar"></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="txtBuscar" Text="Buscar" ID="lblTxtBuscar"></asp:Label>
                </div>
                <div class="input-field col s6">
                    <asp:DropDownList ID="cmbBuscador" runat="server">
                        <asp:ListItem Selected="True" Value="0">Nombres</asp:ListItem>
                        <asp:ListItem Value="1">Apellidos</asp:ListItem>
                        <asp:ListItem Value="2">Programa de Beca</asp:ListItem>
                        <asp:ListItem Value="3">Código de Becario</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblCmbBucador" AssociatedControlID="cmbBuscador" runat="server" Text="Filtrar por"></asp:Label>
                </div>
                <div class="row center-align">
                    <asp:Button CssClass="btn waves-effect waves-light" Text="Buscar" runat="server"  ID="btnBuscar" OnClick="btnBuscar_Click"/>
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="DGV" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="idCiclo">
                    <Columns>
                        <asp:BoundField DataField="idBecario" HeaderText="Id" SortExpression="idBecario" />
                        <asp:BoundField DataField="nombres" HeaderText="Nombre" SortExpression="nombres" />
                        <asp:BoundField DataField="apellidos" HeaderText="Apellido" SortExpression="apellidos" />
                        <asp:BoundField DataField="programa" HeaderText="Programa" SortExpression="programa" />
                        <asp:BoundField DataField="anio" HeaderText="Año" SortExpression="anio" />
                        <asp:BoundField DataField="nCiclo" HeaderText="N° Ciclo" SortExpression="nCiclo" />
                        <asp:TemplateField HeaderText="Registrar Desembolso" SortExpression="idBecario">
                            <ItemTemplate>
                                <asp:HyperLink NavigateUrl='<%#  string.Concat(string.Concat("/Contador/DesembolsoRegistro.aspx?idCiclo=", Eval("idCiclo")), string.Concat("&idBecario=", Eval("idBecario"))) %>' ID="lblCiclo" runat="server" CssClass="waves-effect waves-light btn" Text="Ver" />
                             </ItemTemplate>
                        </asp:TemplateField>  
                    </Columns>
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>"
                SelectCommand="SELECT C.idCiclo, C.anio, nCiclo, INF.nombres, INF.apellidos, PB.nombre AS [programa], B.idBecario FROM Becario B 
                INNER JOIN Ciclo C ON B.idBecario = C.idBecario
                INNER JOIN InformacionPersonal INF ON B.idInformacion = INF.idInformacion
                INNER JOIN ProgramaBecas PB ON B.idPrograma = PB.idPrograma WHERE C.evidenciaNotas = 1 ORDER BY C.nCiclo DESC;">
            </asp:SqlDataSource>
        </form>
    </main>
</body>
</html>
