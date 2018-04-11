<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="GestorEducativo_Menu" %>

<header>
    <div class="container">
        <a href="#" data-activates="user_nav" class="button-collapse top-nav full hide-on-large-only"><i class="material-icons">menu</i></a>
    </div>

    <ul id="user_nav" class="side-nav fixed">
        <li>
            <div class="userView">
                <div class="background teal">
                    <%--<img src="../files/img/coor.jpg" width="100%">--%>
                </div>
                <img class="circle" src="/img/logo.png">
                <span class="white-text name">FEDISAL</span>
                <span class="white-text email">[Gestor Educativo]</span>
            </div>
        </li>
        <li><a href="/GestorEducativo/" class="waves-effect">Inicio<i class="material-icons">home</i></a></li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Becarios<i class="material-icons">library_books</i></a>
                    <div class="collapsible-body">
                        <ul>
                            <li><a href="/GestorEducativo/BecarioRegistro.aspx" class="waves-effect">Añadir becario<i class="material-icons">person_add</i></a></li>
                            <li><a href="/GestorEducativo/InformacionPersonalRegistro.aspx" class="waves-effect">Información personal<i class="material-icons">local_library</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Historial Becarios<i class="material-icons">assignment_ind</i></a>
                    <div class="collapsible-body">
                        <ul>
                           <li><a href="/GestorEducativo/IncidentesRegistro.aspx" class="waves-effect">Incidente Becarios<i class="material-icons">public</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Presupuesto<i class="material-icons">person</i></a>
                    <div class="collapsible-body">
                        <ul>
                            <li><a href="/GestorEducativo/HistorialPresupuesto.aspx" class="waves-effect">Historial Presupuesto<i class="material-icons">account_balance</i></a></li>
                            <li><a href="/GestorEducativo/AprobarDesembolso.aspx" class="waves-effect">Desembolsos<i class="material-icons">attach_money</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li><a class="subheader">Cuenta</a></li>
        <li><a href="/GestorEducativo/Configuracion.aspx" class="waves-effect">Configuración<i class="material-icons">settings</i></a></li>
        <li>
            <div class="divider"></div>
        </li>
        <li><a class="waves-effect btnUnlog"><i class="material-icons">cancel</i>Cerrar Sesión</a></li>
    </ul>
</header>

<nav class="top-nav teal">
    <div class="container">
        <div class="nav-wrapper"><a class="page-title" id="pageTitle" runat="server"></a></div>
    </div>
</nav>
