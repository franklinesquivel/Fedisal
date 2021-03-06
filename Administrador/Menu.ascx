﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Administrador_Menu" %>

<header>
    <div class="container">
        <a href="#" data-activates="user_nav" class="button-collapse top-nav full hide-on-large-only"><i class="material-icons">menu</i></a>
    </div>

    <ul id="user_nav" class="side-nav fixed">
        <li>
            <div class="userView">
                <div class="background grey darken-2">
                    <%--<img src="../files/img/coor.jpg" width="100%">--%>
                </div>
                <img class="circle" src="/img/logo.png">
                <span class="white-text name">FEDISAL</span>
                <span class="white-text email">[Administrador]</span>
            </div>
        </li>
        <li><a href="/Administrador/" class="waves-effect">Inicio<i class="material-icons">home</i></a></li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Programa Beca<i class="material-icons">library_books</i></a>
                    <div class="collapsible-body">
                        <ul>
                            <li><a href="/Administrador/ProgramaBecasRegistro.aspx" class="waves-effect">Añadir<i class="material-icons">library_add</i></a></li>
                            <li><a href="/Administrador/GestionProgramaBecas.aspx" class="waves-effect">Gestionar<i class="material-icons">poll</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Usuarios<i class="material-icons">person</i></a>
                    <div class="collapsible-body">
                        <ul>
                            <li><a href="/Administrador/ModificarUsuario.aspx" class="waves-effect">Añadir<i class="material-icons">library_add</i></a></li>
                            <li><a href="/Administrador/GestionUsuarios.aspx" class="waves-effect">Gestionar<i class="material-icons">poll</i></a></li>
                            <li><a href="/Administrador/ListaBecarios.aspx" class="waves-effect">Lista Becarios<i class="material-icons">format_list_numbered</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Carreras<i class="material-icons">directions_walk</i></a>
                    <div class="collapsible-body">
                        <ul>
                            <li><a href="/Administrador/RegistroCarrera.aspx" class="waves-effect">Añadir<i class="material-icons">library_add</i></a></li>
                            <li><a href="/Administrador/GestionCarreras.aspx" class="waves-effect">Gestionar<i class="material-icons">poll</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Nivel Educativo<i class="material-icons">local_library</i></a>
                    <div class="collapsible-body">
                        <ul>
                            <li><a href="/Administrador/RegistroNivelEducativo.aspx" class="waves-effect">Añadir<i class="material-icons">library_add</i></a></li>
                            <li><a href="/Administrador/GestionNivelEducativo.aspx" class="waves-effect">Gestionar<i class="material-icons">poll</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Universidad<i class="material-icons">school</i></a>
                    <div class="collapsible-body">
                        <ul>
                            <li><a href="/Administrador/RegistroUniversidad.aspx" class="waves-effect">Añadir<i class="material-icons">library_add</i></a></li>
                            <li><a href="/Administrador/GestionUniversidad.aspx" class="waves-effect">Gestionar<i class="material-icons">poll</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Tipos de Incidente<i class="material-icons">warning</i></a>
                    <div class="collapsible-body">
                        <ul>
                            <li><a href="/Administrador/RegistroTipoincidente.aspx" class="waves-effect">Añadir<i class="material-icons">library_add</i></a></li>
                            <li><a href="/Administrador/GestionTipoIncidente.aspx" class="waves-effect">Gestionar<i class="material-icons">poll</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li><a class="subheader">Cuenta</a></li>
        <li><a href="/Administrador/Configuracion.aspx" class="waves-effect">Configuración<i class="material-icons">settings</i></a></li>
        <li>
            <div class="divider"></div>
        </li>
        <li><a class="waves-effect btnUnlog"><i class="material-icons">cancel</i>Cerrar Sesión</a></li>
    </ul>
</header>

<nav class="top-nav grey darken-2">
    <div class="container">
        <div class="nav-wrapper"><a class="page-title" id="pageTitle" runat="server"></a></div>
    </div>
</nav>
