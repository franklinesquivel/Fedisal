<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Contador_Menu" %>

<header>
    <div class="container">
        <a href="#" data-activates="user_nav" class="button-collapse top-nav full hide-on-large-only"><i class="material-icons">menu</i></a>
    </div>

    <ul id="user_nav" class="side-nav fixed">
        <li>
            <div class="userView">
                <div class="background deep-purple">
                    <%--<img src="../files/img/coor.jpg" width="100%">--%>
                </div>
                <img class="circle" src="/img/logo.png">
                <span class="white-text name">FEDISAL</span>
                <span class="white-text email">[Contador]</span>
            </div>
        </li>
        <li><a href="/Contador/" class="waves-effect">Inicio<i class="material-icons">home</i></a></li>
        <li class="no-padding">
            <ul class="collapsible collapsible-accordion">
                <li>
                    <a class="collapsible-header waves-effect">Presupuestos<i class="material-icons">account_balance</i></a>
                    <div class="collapsible-body">
                        <ul>
                            <li><a href="/Contador/DesembolsoRegistro.aspx" class="waves-effect">Añadir Desembolso<i class="material-icons">attach_money</i></a></li>
                            <li><a href="/Contador/PresupuestoRegistro.aspx" class="waves-effect">Añadir Presupuesto<i class="material-icons">shopping_cart</i></a></li>
                        </ul>
                    </div>
                </li>
            </ul>
        </li>
        <li><a class="subheader">Cuenta</a></li>
        <li><a href="#!" class="waves-effect">Configuración<i class="material-icons">settings</i></a></li>
        <li>
            <div class="divider"></div>
        </li>
        <li><a class="waves-effect btnUnlog"><i class="material-icons">cancel</i>Cerrar Sesión</a></li>
    </ul>
</header>

<nav class="top-nav deep-purple">
    <div class="container">
        <div class="nav-wrapper"><a class="page-title" id="pageTitle" runat="server"></a></div>
    </div>
</nav>
