<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionTipoIncidente.aspx.cs" Inherits="Administrador_GestionTipoIncidente" %>
<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="Fedisal - Tipos de Incidentes" runat="server" ID="Header" />
    <script src="../js/gestionTipoIncidente.js"></script>
    <body>
        <header>
            <uc:Menu Titulo="Tipos de Incidente" runat="server" ID="Menu" />
        </header>
        <main class="container">
            <div class="row col l10 offset-l1 m10 offset-m1 s10 offset-s1">
                <form id="form1" runat="server">
                    <asp:GridView ID="gdIncidentes" runat="server" CssClass="centered" AllowPaging="True" 
                        DataKeyNames="idTipoIncidente"
                        DataSourceID="sqlDataS"
                        AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="">
                        <Columns>
                            <asp:BoundField HeaderStyle-CssClass="center" DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                            <asp:BoundField HeaderStyle-CssClass="center" DataField="InicidentesRegistrados" HeaderText="Inicidentes Relacionados" SortExpression="InicidentesRegistrados" />
                            <asp:BoundField HeaderStyle-CssClass="center" DataField="descripcion" HeaderText="Descripcion" SortExpression="descripcion" />
                            <asp:TemplateField HeaderStyle-CssClass="center" HeaderText="Acciones" SortExpression="idTipoIncidente">
                                <ItemTemplate>
                                        <asp:HyperLink NavigateUrl='<%# string.Concat("/Administrador/RegistroTipoIncidente.aspx?id=", Eval("idTipoIncidente")) %>' ID="btnModificarGV" runat="server" Visible="true" CssClass="btnModificar waves-effect modal-trigger" />
                                        <asp:HyperLink NavigateUrl="#mdlEliminar" ID="btnEliminarGV" runat="server" idTipoInicidente='<%# Eval("idTipoIncidente") %>' Visible='<%# (Convert.ToInt32(Eval("InicidentesRegistrados")) > 0) ? false : true %>' CssClass="eliminarModal waves-effect modal-trigger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:SqlDataSource ID="sqlDataS" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>"
                        SelectCommand="
                            SELECT T.idTipoIncidente, T.nombre, T.descripcion, COUNT(B.idBitacora) AS [InicidentesRegistrados]  FROM TipoIncidente T FULL JOIN BitacoraIncidentes B
                            ON T.idTipoIncidente = B.idTipoIncidente GROUP BY T.idTipoIncidente, T.nombre, T.descripcion ORDER BY T.nombre;
                        ">
                    </asp:SqlDataSource>
                </form>
            </div>
        </main>
        <div id="mdlEliminar" class="modal">
            <div class="modal-content">
                <h4 class="center-align">Eliminación de Carrera</h4>
                <p class="center-align">¿Desea eliminar este Tipo de Incidente?</p>
                <input type="hidden" value="" runat="server" id="txtIdTipo" />
            </div>
            <div class="modal-footer">
                <a href="#!" class="modal-action waves-effect waves-green btn-flat" id="btnEliminar">Eliminar</a>
                <a href="#!" class="modal-action modal-close waves-effect waves-red btn-flat">Cancelar</a>
            </div>
        </div>
    </body>
</html>
