<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerExpediente.aspx.cs" Inherits="GestorEducativo_VerExpediente" %>
<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <uc:Header Titulo="" runat="server" ID="Header"/>
    <script src="../js/VerExpediente.js"></script>
    <body>
        <header>
            <uc:Menu Titulo="Gestor Educativo" runat="server" ID="Menu" />
        </header>
        <main class="container">
        <form id="form1" runat="server">
            <h3 class="center light-blue-text text-lighten-2">Vista de Expediente</h3>
            <br />
            <div class="row">
                <div class="col l6 s12 m10 offset-l3 offset-m1">
                  <div class="card teal lighten-5">
                    <div class="card-content">
                      <b><span class="card-title center-align teal-text">Datos de Becario</span></b>
                      <div class="row">
                          <ul>
                              <li runat="server" id="nombreB"></li>
                              <li runat="server" id="nivelB"></li>
                              <li runat="server" id="carreraB"></li>
                              <li runat="server" id="universidadB"></li>
                              <li runat="server" id="programaB"></li>
                              <li runat="server" id="fechaInicioB"></li>
                              <li runat="server" id="fechaFinB"></li>
                          </ul>
                      </div>
                    </div>
                  </div>
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="DGV" runat="server" EmptyDataText="No hay ciclos registrados" cssClass="centered highlight" AllowPaging="true" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="idCiclo">
                    <Columns>
                        <asp:BoundField DataField="Anio" HeaderText="Año" SortExpression="Anio" />
                        <asp:BoundField DataField="nCiclo" HeaderText="N° de Ciclo" SortExpression="ciclo" />
                        <asp:TemplateField HeaderText="Presupuesto Aprobado">
                            <ItemTemplate>
                                <asp:Label ID="lblAprobado" runat="server" Text='<%# Boolean.Parse(Eval("Aprobado").ToString()) ? "Si" : "No" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ver más">
                            <ItemTemplate>
                                <asp:HyperLink NavigateUrl="#mdlDetalle" ID="btnVerDetalles" runat="server" idCiclo='<%# Eval("idCiclo") %>' CssClass="btnMdlDetalle waves-effect modal-trigger" Text='Ver Detalles' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" >
            </asp:SqlDataSource>
        </form>
        </main>
        <div id="mdlDetalle" class="modal"> <!-- Modal para registrar incidente -->
            <div class="modal-content">
                <h4 class="center-align">Detalle de Ciclo</h4>
                <br />
                <div id="contenMdl" class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                        
                </div>
            </div>
            <div class="modal-footer">
                <a href="#!" class="modal-action modal-close waves-effect waves-green btn-flat">Cancelar</a>
            </div>
        </div>  
    </body>
</html>
