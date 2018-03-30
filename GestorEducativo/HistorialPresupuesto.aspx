<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistorialPresupuesto.aspx.cs" Inherits="GestorEducativo_HistorialPresupuesto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Fedisal - Historial de Desemmbolsos</title>
        <link href="/css/materialize.min.css" rel="stylesheet" />
        <meta name="viewport" content="width=device-width" initial-scale="1.0" />
        <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>

        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

        <script src="/js/jquery.min.js"></script>
        <script src="/js/materialize.min.js"></script>
        <script src="/js/init.js"></script>
        <script src="/js/modal.js"></script>
    </head>
    <body>
        <br />
        <form id="form1" runat="server">
            <h3 class="center light-blue-text text-lighten-2">Historial de Desembolsos</h3>
            <br />
            <div class="row">
    
            </div>
            <div class="row">
                <asp:GridView runat="server" ID="DGV" AllowPaging="true"
                     AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="idDesembolso">
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Tipo de Desembolso" SortExpression="nombre"/>
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha"/>
                        <asp:BoundField DataField="monto" HeaderText="Monto ($)" SortExpression="monto"/>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>">
            </asp:SqlDataSource>
        </form>
    </body>
</html>
