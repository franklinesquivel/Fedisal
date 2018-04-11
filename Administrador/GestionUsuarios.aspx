<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionUsuarios.aspx.cs" Inherits="Administrador_GestionUsuarios" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<uc:Header Titulo="Gestión de Usuarios" runat="server" ID="Header" />
<body>
    <header>
        <uc:Menu Titulo="Usuarios" runat="server" ID="Menu" />
    </header>
    <main>
        <form id="form1" runat="server">
        <asp:TextBox runat="server" name="idH" id="idH" Visible="false" />
            <div class="container">
                <asp:GridView
                    ID="gvUsuarios" CssClass="centered" runat="server"
                    AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Código" 
                    CssClasss="col l10 offset-l1 m10 offset-m1 s10 offset-s1"
                    DataSourceID="sdsUsuarios">
                    <Columns>
                        <asp:BoundField DataField="Código" HeaderStyle-CssClass="center" HeaderText="Código" ReadOnly="True" SortExpression="Código" />
                        <asp:BoundField DataField="Nombre" HeaderStyle-CssClass="center" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderStyle-CssClass="center" HeaderText="Apellido" SortExpression="Apellido" />
                        <asp:BoundField DataField="Tipo de Usuario" HeaderStyle-CssClass="center" HeaderText="Tipo de Usuario" SortExpression="Tipo de Usuario" />
                        <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="center">
                            <ItemTemplate>
                                <asp:HyperLink NavigateUrl='<%# string.Concat("ModificarUsuario.aspx?idUsuario=", Eval("Código")) %>' ID="btnEditarGV" runat="server" Visible="true" CssClass="blue blue-text text-darken-4 btnModificar waves-effect waves-light btn" Text='Editar' />
                                <asp:HyperLink ID="btnEliminarGV" runat="server" Visible="true" CssClass="btnEliminar waves-effect waves-light btn red red-text text-darken-4 modal-trigger" href="#mdlEliminar" idUser='<%# Eval("Código") %>' Text='Eliminar' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="sdsUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:Fedisal_CS %>" SelectCommand="SELECT u.idUsuario AS Código, ip.nombres AS Nombre, ip.apellidos AS Apellido, tu.descripcion AS [Tipo de Usuario] FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE (u.idUsuario &lt;&gt; @idUser) AND (tu.idTipoUsuario &lt;&gt; 'A')">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="idH" DefaultValue="0" Name="idUser" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </form>
    </main>

    <div id="mdlEliminar" class="modal">
        <div class="modal-content">
            <h4 class="center-align">Eliminación de Usuario</h4>
            <p class="center-align">¿Desea eliminar este usuario?</p>
            <input type="hidden" value="" runat="server" id="txtUser" />
        </div>
        <div class="modal-footer">
            <a class="modal-action waves-effect waves-green btn-flat" id="btnMdlEliminar">Eliminar</a>
            <a class="modal-action modal-close waves-effect waves-red btn-flat">Cancelar</a>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            let id;
            $(".btnEliminar").click(function () {
                id = $(this).attr("iduser");
            })

            $("#btnMdlEliminar").click(function () {
                if(id != undefined){
                    $.ajax({
                        type: 'POST',
                        url: '/Administrador/GestionUsuarios.aspx/EliminarUsuario',
                        data: JSON.stringify({ idUsuario: id }),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function(r){
                            r = r.d;
                            if(r == true){
                                    Materialize.toast('El usuario ha sido eliminado éxitosamente!', 2000, '', function(){
                                    location.reload();
                                });

                            }else{
                                Materialize.toast('Ha ocurrido un error :$', 2000);
                            }
                        }
                    })
                }
            })
        })
    </script>
</body>
</html>
