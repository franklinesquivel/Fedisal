<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionNivelEducativo.aspx.cs" Inherits="Administrador_GestionNivelEducativo" %>
<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="Fedisal - Nivel Educativo" runat="server" ID="Header" />
    <script src="../js/gestionNivel.js"></script>
    <body>
        <header>
            <uc:Menu Titulo="Nivel Educativo" runat="server" ID="Menu" />
        </header>
        <main class="container">
            <div class="row col l10 offset-l1 m10 offset-m1 s10 offset-s1">
                <form id="form1" runat="server">
                    <asp:GridView ID="gdNivelEducativo" runat="server" CssClass="centered" AllowPaging="True" 
                        DataKeyNames="idNivelEducativo"
                        DataSourceID="sqlDataS"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="idNivelEducativo" HeaderStyle-CssClass="center" HeaderText="ID" SortExpression="ID"/>
                            <asp:BoundField DataField="nombre" HeaderStyle-CssClass="center" HeaderText="Nombre" SortExpression="nombre" />
                            <asp:BoundField DataField="descripcion" HeaderStyle-CssClass="center" HeaderText="Descripcion" SortExpression="descripcion" />
                            <asp:TemplateField HeaderText="Modificar" HeaderStyle-CssClass="center" SortExpression="idNivelEducativo">
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl='<%# string.Concat("/Administrador/RegistroNivelEducativo.aspx?idNivel=", Eval("idNivelEducativo")) %>' ID="btnModificarGV" runat="server" Visible="true" CssClass="blue blue-text text-darken-4 btnModificar waves-effect waves-light btn modal-trigger" Text='Modificar' />
                                </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="center" HeaderText="Eliminar" SortExpression="idNivelEducativo">
                                <ItemTemplate>
                                    <asp:HyperLink NavigateUrl="#mdlEliminar" ID="btnEliminarGV" runat="server" idnivel='<%# Eval("idNivelEducativo") %>' CssClass="btnEliminar waves-effect waves-light btn red red-text text-darken-4 modal-trigger" Text='Eliminar' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:SqlDataSource ID="sqlDataS" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>"
                        SelectCommand="
                            SELECT T.idNivelEducativo, T.nombre, T.descripcion FROM NivelEducativo T GROUP BY T.idNivelEducativo, T.nombre, T.descripcion ORDER BY T.nombre; ">
                    </asp:SqlDataSource>
                </form>
            </div>
        </main>
        <div id="mdlEliminar" class="modal">
            <div class="modal-content">
                <h4 class="center-align">Eliminación de Nivel Educativo</h4>
                <p class="center-align">¿Desea eliminar este nivel educativo?</p>
                <input type="hidden" value="" runat="server" id="txtIdNivel" />
            </div>
            <div class="modal-footer">
                <a href="#!" class="modal-action waves-effect waves-green btn-flat" id="btnMdlEliminar">Eliminar</a>
                <a href="#!" class="modal-action modal-close waves-effect waves-red btn-flat">Cancelar</a>
            </div>
        </div>
    </body>
</html>
