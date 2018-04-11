<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistorialPresupuesto.aspx.cs" Inherits="GestorEducativo_HistorialPresupuesto" %>

<%@Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <uc:Header Titulo="" runat="server" ID="Header"/>
    
    <body>
        <header>
            <uc:Menu Titulo="Gestor Educativo" runat="server" ID="Menu" />
        </header>
        <main class="container">
        <form id="form1" runat="server">
            <h3 class="center light-blue-text text-lighten-2">Historial de Desembolsos</h3>
            <br />
            <div class="row">
    
            </div>
            <div class="row">
                <asp:GridView runat="server" ID="DGV" AllowPaging="true"
                     AutoGenerateColumns="False" CssClass="centered highlight" EmptyDataText="No hay desembolsos registrados" DataSourceID="SqlDataSource1" DataKeyNames="idDesembolso">
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Tipo de Desembolso" SortExpression="nombre"/>
                        <asp:BoundField DataField="fecha" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Fecha" SortExpression="fecha"/>
                        <asp:BoundField DataField="monto" DataFormatString="{0:0.00}"  HeaderText="Monto ($)" SortExpression="monto"/>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>">
            </asp:SqlDataSource>
        </form>
        </main>
    </body>
</html>
