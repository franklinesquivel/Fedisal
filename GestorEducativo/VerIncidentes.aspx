<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerIncidentes.aspx.cs" Inherits="GestorEducativo_VerIncidentes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Fedisal - Vista de Incidentes</title>
        <link href="/css/materialize.min.css" rel="stylesheet" />
        <meta name="viewport" content="width=device-width" initial-scale="1.0" />
        <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
        <script src="/js/jquery.min.js"></script>
        <script src="/js/materialize.min.js"></script>
        <script src="/js/init.js"></script>
        <style>
            th{
                text-align:center;
            }
        </style>
    </head>
    <body>
        <br />
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
                <asp:GridView ID="DGV" runat="server" cssClass="centered" AllowPaging="true" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="idBitacora">
                    <Columns>
                        <asp:BoundField DataField="TipoIncidente" HeaderText="Tipo de Incidente" SortExpression="TipoIncidente" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>">
        </asp:SqlDataSource>
    </body>
</html>
