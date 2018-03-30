<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AprobarDesembolso.aspx.cs" Inherits="GestorEducativo_AprobarDesembolso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Fedisal - Control de Desembolsos</title>
        <link href="/css/materialize.min.css" rel="stylesheet" />
        <meta name="viewport" content="width=device-width" initial-scale="1.0" />
        <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
        <script src="/js/jquery.min.js"></script>
        <script src="/js/materialize.min.js"></script>
        <script src="/js/init.js"></script>
        <script src="/js/controlDesembolso.js"></script>
    </head>
    <body>
        <form id="form1" runat="server">
            <br />
            <div class="container">
                <h3 class="center light-blue-text text-lighten-2">Control de Desembolsos</h3>
                <br />
                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox runat="server" ID="txtBuscar"></asp:TextBox>
                        <asp:Label runat="server" AssociatedControlID="txtBuscar" Text="Buscar" ID="lblTxtBuscar"></asp:Label>
                    </div>
                    <div class="input-field col s6">
                        <asp:DropDownList ID="cmbBuscador" runat="server">
                            <asp:ListItem Selected="True" Value="nombre">Nombres</asp:ListItem>
                            <asp:ListItem Value="apellido">Apellidos</asp:ListItem>
                            <asp:ListItem Value="programa">Programa de Beca</asp:ListItem>
                            <asp:ListItem Value="codigo">Código de Becario</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblCmbBucador" AssociatedControlID="cmbBuscador" runat="server" Text="Filtrar por"></asp:Label>
                    </div>
                    <div class="row center-align">
                        <asp:Button CssClass="btn waves-effect waves-light" Text="Buscar" runat="server"  ID="btnBuscar" OnClick="btnBuscar_Click"/>
                    </div>
                </div>
                <div class="row">
                    <asp:GridView runat="server" ID="DGV" AllowPaging="True" 
                        AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource1" DataKeyNames="idCiclo">
                        <Columns>
                            <asp:BoundField DataField="CodigoB" HeaderText="Código" SortExpression="CodigoB" />
                            <asp:BoundField DataField="NombreBecario" HeaderText="Nombre" SortExpression="NombreBecario" />
                            <asp:BoundField DataField="anio" HeaderText="Año" SortExpression="anio" />
                            <asp:BoundField DataField="nCiclo" HeaderText="N° de Ciclo" SortExpression="nCiclo" />
                            <asp:TemplateField HeaderText="Opción">
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl="#mdlDetalle" Text="Ver Detalles" 
                                        idCiclo='<%# Eval("idCiclo") %>' runat="server" 
                                        CssClass="btnMdlDetalle waves-effect waves-light btn"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" 
                SelectCommand="SELECT C.idCiclo, C.anio, nCiclo, CONCAT(I.nombres, ' ', I.apellidos) AS [NombreBecario], 
                    P.nombre AS [Programa], B.idBecario AS [CodigoB] FROM Ciclo C 
                    INNER JOIN Becario B ON C.idBecario = B.idBecario 
                    INNER JOIN ProgramaBecas P ON B.idPrograma = P.idPrograma
                    INNER JOIN InformacionPersonal I ON B.idInformacion = I.idInformacion
                    WHERE C.evidenciaNotas= 0ORDER BY C.anio, C.nCiclo, [NombreBecario]">
            </asp:SqlDataSource>
        </form>
        <div id="mdlDetalle" class="modal"> <!-- Modal para registrar incidente -->
            <div class="modal-content">
                <h4>Asignaturas registradas</h4>
                <br />
                <div id="contenMdl" class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                    
                </div>
                <div class="modal-footer">
                    <a href="#!" class="modal-action modal-close waves-effect waves-green btn-flat">Cancelar</a>
                </div>
            </div>
        </div>
    </body>
</html>
