<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionUniversidad.aspx.cs" Inherits="Administrador_GestionUniversidad" %>
<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="Fedisal - Universidades" runat="server" ID="Header" />
    <script src="../js/gestionUniversidad.js"></script>
    <body>
        <header>
            <uc:Menu Titulo="Universidades" runat="server" ID="Menu" />
        </header>
        <main class="container">
            <div class="row col l10 offset-l1 m10 offset-m1 s10 offset-s1">
                <form id="form1" runat="server">
                    <asp:GridView ID="gdUniversidad" runat="server" CssClass="centered" AllowPaging="True" 
                        DataKeyNames="idUniversidad"
                        DataSourceID="sqlDataS"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField HeaderStyle-CssClass="center" DataField="idUniversidad" HeaderText="ID" SortExpression="ID"/>
                            <asp:BoundField HeaderStyle-CssClass="center" DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                            <asp:BoundField HeaderStyle-CssClass="center" DataField="direccion" HeaderText="Direccion" SortExpression="Direccion" />
                            <asp:BoundField HeaderStyle-CssClass="center" DataField="telefono" HeaderText="telefono" SortExpression="telefono" />
                            <asp:TemplateField HeaderStyle-CssClass="center" HeaderText="Acciones" SortExpression="idTipoIncidente">
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl='<%# string.Concat("/Administrador/RegistroUniversidad.aspx?idUniversidad=", Eval("idUniversidad")) %>' ID="btnModificarGV" runat="server" Visible="true" CssClass="blue blue-text text-darken-4 btnModificar waves-effect waves-light btn modal-trigger" Text='Modificar' />
                                    <asp:HyperLink NavigateUrl="#mdlEliminar" ID="btnEliminarGV" runat="server" idUniversidad='<%# Eval("idUniversidad") %>' CssClass="btnEliminar waves-effect waves-light btn red red-text text-darken-4 modal-trigger" Text='Eliminar' />
                                </ItemTemplate>
                           </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:SqlDataSource ID="sqlDataS" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>"
                        SelectCommand="
                            SELECT T.idUniversidad, T.nombre, T.direccion, T.telefono
                            FROM Universidad T
                            ORDER BY T.nombre; ">
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
                <a href="#!" class="modal-action waves-effect waves-green btn-flat" id="btnMdlEliminar">Eliminar</a>
                <a href="#!" class="modal-action modal-close waves-effect waves-red btn-flat">Cancelar</a>
            </div>
        </div>
    </body>
</html>
