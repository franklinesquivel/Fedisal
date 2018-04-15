<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaBecarios.aspx.cs" Inherits="Administrador_usuarios" %>
<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <uc:Header Titulo="Fedisal - Becarios" runat="server" ID="Header" />
    <body>
        <header>
            <uc:Menu Titulo="Becarios" runat="server" ID="Menu" />
        </header>
        <br />
        <form id="form1" runat="server">
            <main class="container">
                <div class="row col l10 offset-l1 m10 offset-m1 s10 offset-s1">
                    <asp:GridView ID="GridView1" EmptyDataText="No hay becarios registrados" runat="server" AutoGenerateColumns="False" DataKeyNames="Código" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="Código" HeaderText="Código" ReadOnly="True" SortExpression="Código" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                            <asp:BoundField DataField="Universidad" HeaderText="Universidad" SortExpression="Universidad" />
                            <asp:BoundField DataField="Carrera" HeaderText="Carrera" SortExpression="Carrera" />
                            <asp:BoundField DataField="Programa Beca" HeaderText="Programa Beca" SortExpression="Programa Beca" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" SelectCommand="SELECT b.idBecario AS Código, i.nombres AS Nombre, i.apellidos AS Apellido, u.nombre AS Universidad, c.nombre AS Carrera, pb.nombre AS [Programa Beca] FROM Becario b
                    INNER JOIN ProgramaBecas pb ON pb.idPrograma = b.idPrograma
                    INNER JOIN InformacionPersonal i ON i.idInformacion = b.idInformacion
                    INNER JOIN Universidad u ON u.idUniversidad = b.idUniversidad
                    INNER JOIN Carrera c ON c.idCarrera = b.idCarrera"></asp:SqlDataSource>
                </div>
            </main>
        </form>
    </body>
</html>
