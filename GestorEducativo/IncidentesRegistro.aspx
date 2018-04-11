<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncidentesRegistro.aspx.cs" Inherits="IncidentesRegistro" %>
<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
         <uc:Header Titulo="" runat="server" ID="Header"/>
    <script src="../js/modal.js"></script>
<body>
            <header>
            <uc:Menu Titulo="Gestor Educativo" runat="server" ID="Menu" />
            </header>
        <main class="container">
        <form runat="server">
            <h3 class="center light-blue-text text-lighten-2">Registro de Incidentes</h3>
            <br />
            <div class="center container">
                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox runat="server" ID="txtBuscar"></asp:TextBox>
                        <asp:Label runat="server" AssociatedControlID="txtBuscar" Text="Buscar" ID="lblTxtBuscar"></asp:Label>
                    </div>
                    <div class="input-field col s6">
                        <asp:DropDownList ID="cmbBuscador" runat="server">
                            <asp:ListItem Selected="True" Value="InformacionPersonal.nombres">Nombres</asp:ListItem>
                            <asp:ListItem Value="InformacionPersonal.apellidos">Apellidos</asp:ListItem>
                            <asp:ListItem Value="ProgramaBecas.nombre">Programa de Beca</asp:ListItem>
                            <asp:ListItem Value="Becario.idBecario">Código de Becario</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblCmbBucador" AssociatedControlID="cmbBuscador" runat="server" Text="Filtrar por"></asp:Label>
                    </div>
                    <div class="row center-align">
                        <asp:Button CssClass="btn waves-effect waves-light" Text="Buscar" runat="server"  ID="btnBuscar" OnClick="btnBuscar_Click"/>
                    </div>
                </div>
                <div class="row">
                    <asp:GridView ID="DGV"  runat="server" CssClass="striped" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="idBecario">
                        <Columns>
                            <asp:TemplateField HeaderText="idBecario" SortExpression="idBecario" Visible="False">
                                <EditItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("idBecario") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("idBecario") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="nombres" HeaderText="Nombre" SortExpression="nombres" />
                            <asp:BoundField DataField="apellidos" HeaderText="Apellido" SortExpression="apellidos" />
                            <asp:BoundField DataField="nombre" HeaderText="Programa" SortExpression="nombre" />

                            <asp:TemplateField HeaderText="Aplicar" SortExpression="idBecario">
                                <EditItemTemplate>
                                    <asp:Label ID="lblBeca" runat="server" Text='<%# Eval("idBecario") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl="#modal1" ID="lblBeca" runat="server" IdBecario='<%# Eval("idBecario") %>' CssClass="btnIncidente waves-effect waves-light btn modal-trigger" Text="Aplicar" />
                                </ItemTemplate>
                            </asp:TemplateField>   
                             <asp:TemplateField HeaderText="Incidentes" SortExpression="idBecario">
                                <EditItemTemplate>
                                    <asp:Label ID="lblBeca" runat="server" Text='<%# Eval("idBecario") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl='<%# string.Concat("/GestorEducativo/VerIncidentes.aspx?id=", Eval("idBecario")) %>' ID="lblBeca" runat="server" CssClass="waves-effect waves-light btn" Text="Ver" />
                                </ItemTemplate>
                                 
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="Expediente" SortExpression="idBecario">
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl='<%# string.Concat("/GestorEducativo/VerExpediente.aspx?id=", Eval("idBecario")) %>' ID="lblBeca" runat="server" CssClass="waves-effect waves-light btn" Text="Ver" />
                                </ItemTemplate>
                            </asp:TemplateField>  
                             <asp:TemplateField HeaderText="Historial Presupuesto" SortExpression="idBecario">
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl='<%# string.Concat("/GestorEducativo/HistorialPresupuesto.aspx?id=", Eval("idBecario")) %>' ID="lblBeca" runat="server" CssClass="waves-effect waves-light btn" Text="Ver" />
                                </ItemTemplate>
                            </asp:TemplateField>                 
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" 
                    SelectCommand="SELECT InformacionPersonal.nombres, InformacionPersonal.apellidos, ProgramaBecas.nombre, Becario.idBecario FROM Becario INNER JOIN InformacionPersonal ON Becario.idInformacion = InformacionPersonal.idInformacion INNER JOIN ProgramaBecas ON Becario.idPrograma = ProgramaBecas.idPrograma">
                </asp:SqlDataSource>
            </div>
            <%--<asp:TextBox ForeColor="White" ID="txtIdBecario" CssClass="form-control if" runat="server" />--%>
            <div id="modal1" class="modal"> <!-- Modal para registrar incidente -->
                <div class="modal-content">
                    <h4>Registro Incidente con el becado</h4>
                    <br />
                        <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                            <asp:DropDownList ID="ddlIncidentes" runat="server">
                            </asp:DropDownList>
                            <asp:Label AssociatedControlID="ddlIncidentes" Text="Seleccione el tipo de Incidente" runat="server" />
                        </div>
                        <input type="hidden" id="txtIdBecario" value="" />
                    <div class="input-field col s12 center-align">
                        <input type="button" id="btnAplicar" value="Aplicar" class="btn waves-effect waves-light"/>
                        <%--<asp:button text="Aplicar Incidente" ID="btnAplicar" OnClick="btnAplicar_Click" CssClass="btn waves-effect waves-light"  runat="server" />--%>
                    </div>
                </div>
                <div class="modal-footer">
                  <a href="#!" class="modal-action modal-close waves-effect waves-green btn-flat">Cancelar</a>
                </div>
            </div>             
        </form>
    </main>

        <!-- Dropdown Structure -->
          
    </body>
    
</html>
