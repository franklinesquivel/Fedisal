<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncidentesRegistro.aspx.cs" Inherits="IncidentesRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Fedisal - Registro de Incidentes</title>
        <link href="css/materialize.min.css" rel="stylesheet" />
        <meta name="viewport" content="width=device-width" initial-scale="1.0" />
        <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>

        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

        <script src="js/jquery.min.js"></script>
        <script src="js/materialize.min.js"></script>
        <script src="js/init.js"></script>
        <script src="js/modal.js"></script>
</head>
<body>
    <br />
        <form runat="server">
      <h3 class="center light-blue-text text-lighten-2">Registro de Incidentes</h3>
       
       <br />
        <div class="center container">
            <asp:GridView ID="DGV" runat="server" CssClass="striped" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="nombres" HeaderText="Nombre del becario" SortExpression="nombres" />
                    <asp:BoundField DataField="apellidos" HeaderText="Apellido del becario" SortExpression="apellidos" />
                    <asp:BoundField DataField="nombre" HeaderText="Programa de becas" SortExpression="nombre" />
                    
                    <asp:TemplateField HeaderText="Accion">
                       <ItemTemplate>
                           <asp:HyperLink NavigateUrl="#modal1" CssClass="waves-effect waves-light btn modal-trigger" Text="Aplicar" runat="server" />
                       </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" SelectCommand="SELECT InformacionPersonal.nombres, InformacionPersonal.apellidos, ProgramaBecas.nombre FROM Becarios INNER JOIN InformacionPersonal ON Becarios.idInformacion = InformacionPersonal.idInformacion INNER JOIN ProgramaBecas ON Becarios.idPrograma = ProgramaBecas.idPrograma"></asp:SqlDataSource>
                </div>

      <div id="modal1" class="modal">
        <div class="modal-content">
          <h4>Registro Incidente con el becado</h4>
            <br />
                <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                    <asp:DropDownList ID="ddlIncidentes" runat="server">
                    </asp:DropDownList>
                <asp:Label AssociatedControlID="ddlIncidentes" Text="Seleccione el tipo de Incidente" runat="server" />
                <asp:RequiredFieldValidator ID="rfv1" runat="server" InitialValue = "0" CssClass="error-tag" ControlToValidate="ddlIncidentes" ErrorMessage="Debes seleccionar un valor!" Display="Dynamic">
                </asp:RequiredFieldValidator>
                </div>
            <div class="input-field col s12 center-align">
                <asp:button text="Aplicar Incidente" ID="btnAplicar" OnClick="btnAplicar_Click" CssClass="btn waves-effect waves-light"  runat="server" />
            </div>
        </div>
        <div class="modal-footer">
          <a href="#!" class="modal-action modal-close waves-effect waves-green btn-flat">Cancelar</a>
        </div>
      </div>
    </form>
</body>
</html>
