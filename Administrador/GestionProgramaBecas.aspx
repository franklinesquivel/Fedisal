<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionProgramaBecas.aspx.cs" Inherits="GestionProgramaBecas" %>

<%@ Register Src="Header.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <uc:Header Titulo="Fedisal - Programa Becas" runat="server" ID="Header" />
    <script src="../js/gestionProgramas.js"></script>
    <body>
        <header>
            <uc:Menu Titulo="Registro de Programa de Becas" runat="server" ID="Menu" />
        </header>
        <main>
            <div class="row">
                <table class="centered">
                    <thead>
                        <tr>
                            <th>Código</th>
                            <th>Nombre</th>
                            <th>Descripción</th>
                            <th>Cantidad de Becarios</th>
                            <th colspan="2">Opciones</th>
                        </tr>
                    </thead>
                    <tbody id="listaProgramas">
                    </tbody>
                </table>
            </div>
        </main>
        <div id="modalEliminar" class="modal">
            <div class="modal-content">
                <h4 class="center-align">Eliminación de programa</h4>
                <p class="center-align">¿Desea eliminar este programa?</p>
                <input type="hidden" value="" runat="server" id="txtidPrograma" />
            </div>
            <div class="modal-footer">
                <a href="#!" class="modal-action waves-effect waves-green btn-flat" id="btnEliminar">Eliminar</a>
                <a href="#!" class="modal-action modal-close waves-effect waves-red btn-flat">Cancelar</a>
            </div>
        </div>
    </body>
</html>
