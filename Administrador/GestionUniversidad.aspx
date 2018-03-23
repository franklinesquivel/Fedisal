<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionUniversidad.aspx.cs" Inherits="Administrador_GestionUniversidad" %>
<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="Fedisal - Universidades" runat="server" ID="Header" />
    <script src="../js/gestionUniversidad.js"></script>
    <body>
        <header>
            <uc:Menu Titulo="Gestión de Universidades" runat="server" ID="Menu" />
        </header>
        <main class="container">
            <div class="row col l10 offset-l1">
                <form id="form1" runat="server">
                    <asp:GridView ID="gdUniversidad" runat="server" CssClass="centered" AllowPaging="True" 
                        DataKeyNames="idUniversidad"
                        DataSourceID="sqlDataS"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="idUniversidad" HeaderText="ID" SortExpression="ID"/>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                            <asp:BoundField DataField="direccion" HeaderText="Direccion" SortExpression="Direccion" />
                            <asp:BoundField DataField="telefono" HeaderText="telefono" SortExpression="telefono" />
                            <asp:TemplateField HeaderText="Modificar" SortExpression="idTipoIncidente">
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl='<%# string.Concat("/Administrador/GestionUniversidad.aspx?id=", Eval("idUniversidad")) %>' ID="btnModificarGV" runat="server" Visible="true" CssClass="btnModificar waves-effect waves-light btn modal-trigger" Text='Modificar' />
                                </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar" SortExpression="idUniversidad">
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl="#mdlEliminar" ID="btnEliminarGV" runat="server" idUniversidad='<%# Eval("idUniversidad") %>' Visible='<%# (Convert.ToInt32(Eval("UniversidadRegistrada")) > 0) ? false : true %>' CssClass="eliminarModal waves-effect waves-light btn modal-trigger" Text='Eliminar' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:SqlDataSource ID="sqlDataS" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>"
                        SelectCommand="
                            SELECT T.idUniversidad, T.nombre, T.direccion, T.telefono COUNT(B.idBitacora) AS [UniversidadRegistrada]  FROM Universidad T FULL JOIN BitacoraIncidentes B
                            ON T.idUniversidad = B.idUniversidad GROUP BY T.idUniversidad, T.nombre, T.direccion, T.telefono ORDER BY T.nombre; ">
                    </asp:SqlDataSource>
                </form>
            </div>
        </main>
        <div id="mdlEliminar" class="modal">
            <div class="modal-content">
                <h4 class="center-align">Eliminación de Universidad</h4>
                <p class="center-align">¿Desea eliminar esta Universidad?</p>
                <input type="hidden" value="" runat="server" id="txtIdUniversidad" />
            </div>
            <div class="modal-footer">
                <a href="#!" class="modal-action waves-effect waves-green btn-flat" id="btnEliminar">Eliminar</a>
                <a href="#!" class="modal-action modal-close waves-effect waves-red btn-flat">Cancelar</a>
            </div>
        </div>
    </body>
</html>
