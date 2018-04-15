<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PresupuestoInicial.aspx.cs" Inherits="GestorEducativo_presupuestoinicial" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="[Gestor Educativo]" runat="server" ID="Header" />
<body>
    <header>
        <uc:Menu Titulo="Presupuesto Inicial" runat="server" ID="Menu" />
    </header>
    <main class="container">
        <br />
    <form id="form1" runat="server">
        <div class="row col l10 offset-l1 m10 offset-m1 s10 offset-s1">
            <asp:GridView EmptyDataText="No hay un presupuesto asignado" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idPresupuesto" DataSourceID="SqlDataSource1">
                <Columns>
                    <%--<asp:BoundField DataField="idPresupuesto" HeaderText="idPresupuesto" InsertVisible="False" ReadOnly="True" SortExpression="idPresupuesto" />--%>
                    <asp:BoundField DataField="libro" DataFormatString="{0:0.00}" HeaderText="Libro" SortExpression="libro" />
                    <asp:BoundField DataField="colegiatura" DataFormatString="{0:0.00}" HeaderText="Colegiatura" SortExpression="colegiatura" />
                    <asp:BoundField DataField="manutencion" DataFormatString="{0:0.00}" HeaderText="Manuntención" SortExpression="manutencion" />
                    <asp:BoundField DataField="matricula" DataFormatString="{0:0.00}" HeaderText="Mattrícula" SortExpression="matricula" />
                    <asp:BoundField DataField="otros" DataFormatString="{0:0.00}" HeaderText="Otros" SortExpression="otros" />
                    <asp:BoundField DataField="trabajoGraduacion" DataFormatString="{0:0.00}" HeaderText="Trabajo de Graduación" SortExpression="trabajoGraduacion" />
                    <%--<asp:BoundField DataField="idBecario" HeaderText="idBecario" SortExpression="idBecario" />--%>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" SelectCommand="SELECT * FROM [PresupuestoBecas] WHERE ([idBecario] = @idBecario)">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="idBecario" QueryStringField="id" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
    </main>
</body>
</html>
