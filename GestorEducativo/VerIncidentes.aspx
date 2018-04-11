<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerIncidentes.aspx.cs" Inherits="GestorEducativo_VerIncidentes" %>

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
            <h3 class="center light-blue-text text-lighten-2">Lista de Incidentes</h3>
            <br />
            <div class="row">
                <div class="col l6 s12 m10 offset-l3 offset-m1">
                  <div class="card">
                    <div class="card-content">
                      <span class="card-title center-align blue-grey darken-1 white-text">Datos de Becario</span>
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
                <asp:GridView ID="DGV" EmptyDataText="No hay incidentes registrados" runat="server" cssClass="centered highlight" AllowPaging="true" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="idBitacora">
                    <Columns>
                        <asp:BoundField DataField="TipoIncidente" HeaderText="Tipo de Incidente" SortExpression="TipoIncidente" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
        </main>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>">
        </asp:SqlDataSource>
    </body>
</html>
