<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionCarreras.aspx.cs" Inherits="Administrador_GestionCarreras" %>
<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <uc:Header Titulo="Fedisal - Carreras" runat="server" ID="Header" />
    <script src="../js/gestionCarrera.js"></script>
    <body>
        <header>
            <uc:Menu Titulo="Gestión de Carreras" runat="server" ID="Menu" />
        </header>
        <main class="container">
            <div class="row col l10 offset-l1">
                <form id="form1" runat="server">
                    <asp:GridView ID="gdCarreras" runat="server" CssClass="centered" AllowPaging="True" 
                        DataKeyNames="idCarrera"
                        DataSourceID="sqlDataS"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField HeaderStyle-CssClass="center" DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                            <asp:BoundField HeaderStyle-CssClass="center" DataField="numEstudiantes" HeaderText="Numero de Estudiantes" SortExpression="numEstudiantes" />
                            <asp:TemplateField HeaderStyle-CssClass="center" HeaderText="Acciones" SortExpression="idCarrera">
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl='<%# string.Concat("/Administrador/RegistroCarrera.aspx?id=", Eval("idCarrera")) %>' ID="btnModificarGV" runat="server" Visible="true" CssClass="blue blue-text text-darken-4 btnModificar waves-effect waves-light btn modal-trigger" Text='Modificar' />
                                    <asp:HyperLink NavigateUrl="#mdlEliminar" ID="btnEliminarGV" runat="server" idCarrera='<%# Eval("idCarrera") %>' Visible='<%# (Convert.ToInt32(Eval("numEstudiantes")) > 0) ? false : true %>' CssClass="red red-text text-darken-4 eliminarModal waves-effect waves-light btn modal-trigger" Text='Eliminar' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:SqlDataSource ID="sqlDataS" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>"
                        SelectCommand="
                            SELECT C.idCarrera, C.nombre, COUNT(idBecario) AS [numEstudiantes] FROM Carrera C FULL JOIN Becario B ON C.idCarrera = B.idBecario GROUP BY C.idCarrera, C.nombre ORDER BY C.idCarrera;
                        ">
                    </asp:SqlDataSource>
                </form>
            </div>
        </main>
        <div id="mdlEliminar" class="modal">
            <div class="modal-content">
                <h4 class="center-align">Eliminación de Tipo de Incidente</h4>
                <p class="center-align">¿Desea eliminar esta carrera?</p>
                <input type="hidden" value="" runat="server" id="txtIdCarrera" />
            </div>
            <div class="modal-footer">
                <a href="#!" class="modal-action waves-effect waves-green btn-flat" id="btnEliminar">Eliminar</a>
                <a href="#!" class="modal-action modal-close waves-effect waves-red btn-flat">Cancelar</a>
            </div>
        </div>
    </body>
</html>
