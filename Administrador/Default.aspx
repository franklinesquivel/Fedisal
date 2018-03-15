<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrador_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Fedisal - Administrador</title>
    <script type="text/javascript" src="../js/menu.js"></script>
    <link href="../css/materialize.min.css" rel="stylesheet" />
        <meta name="viewport" content="width=device-width" initial-scale="1.0" />
        <link rel="shortcut icon" type="image/png" href="../img/favicon.ico"/>

        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

        <script src="../js/jquery.min.js"></script>
        <script src="../js/materialize.min.js"></script>
        <script src="../js/init.js"></script>
</head>
    <body>
        <!-- navbar -->
        <div class="row">
            <nav>
            <div class="nav-wrapper">
              <div class="col s12 m4 l7">
                  <div class="container center">
                      <a href="javascript:void(0)" class="breadcrumb">Administración</a>
                      <a href="Default.aspx" class="breadcrumb">Inicio</a>
                  </div>
                
              </div>
            </div>
          </nav>
        </div>

        <div class="row">
            <div class="col s12 m4 l3">
                    <ul id="slide-out" class="side-nav fixed">
            <li>
                <div class="user-view">
                    <div class="background center" style="margin-top: 6%;">
                        <img width="100px;" src="../img/logo.png">
                    </div>
                    <br />
                    <br />
                    <a href="javascript:void(0)"><span class="black-text name">Fedisal</span></a>
                    <a href="javascript:void(0)"><span class="black-text email">Administrador</span></a>
                </div>
            </li>
            <div class="divider"></div>
            <li><a class="subheader">Gestiones</a></li>
            <li><a href="#!"><i class="material-icons">people</i>Gestión de usuarios</a></li>
            <li><a href="#!"><i class="material-icons">book</i>Gestión Programa de becas</a></li>
            <li>
                <div class="divider"></div>
            </li>
            <li><a class="subheader">Acciones</a></li>
            <li><a class="waves-effect" href="#!"><i class="material-icons">settings_applications</i>Mantenimiento de tablas</a></li>
            <li><a class="waves-effect" href="#!"><i class="material-icons">power_settings_new</i>Cerrar sesión</a></li>
        </ul>
            </div>
            <div class="col s12 m4 l8">
                <p>Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto.
                    Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor
                    (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró
                    hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos,
                    quedando esencialmente igual al original. Fue popularizado en los 60s con la creación de las hojas "Letraset",
                    las cuales contenian pasajes deLorem Ipsum,
                     y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum.</p>
             </div>
        </div>
       
    </body>
</html>
