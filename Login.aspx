<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Fedisal - Login</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" initial-scale="1.0" />
    <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <script src="js/jquery.min.js"></script>
    <script src="js/materialize.min.js"></script>
    <script src="js/init.js"></script>
    <script src="js/login.js"></script>
    <link href="css/login.css" rel="stylesheet" />
</head>
<body class="grey lighten-4">
   <main class="container">
       <div class="row login-container">
           <form  id="frmLogin" runat="server" class="white col l6 m8 s10 offset-l3 offset-m2 offset-s1">
               <div class="row title-login deep-purple">
                   <h5 class="white-text text-lighten-2 center-align">Iniciar Sesión</h5>
               </div>
               <div class="row logo-container">
                    <div class="input-field col s12">
                        <img src="img/logo.png" alt="" />
                    </div>
                </div>
               <div class="row">
                    <div class="input-field col s12">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        <label for="txtUsername">Usuario</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                            runat="server" 
                            Display="Dynamic"
                            ControlToValidate="txtUsername"
                            CssClass="error-tag"
                            ErrorMessage="Ingrese su username!"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                            runat="server" 
                            ControlToValidate="txtUsername"
                            CssClass="error-tag"
                            ValidationExpression="^([A-Z]{4}[0-9]{7})|([A]{1}[0-9]{4})|([C]{1}[0-9]{4})|([G]{1}[0-9]{4})$"
                            ErrorMessage="Ingrese un valor válido!"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col s12">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <label for="txtPassword">Contraseña</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                            runat="server" 
                            Display="Dynamic"
                            ControlToValidate="txtPassword"
                            CssClass="error-tag"
                            ErrorMessage="Ingrese su contraseña!"></asp:RequiredFieldValidator>
                    </div>
                </div>
               <div class="row center-align">
                   <asp:Button ID="btnIngresar" runat="server" Onclick="btnIngresar_Click" CssClass="waves-effect deep-purple btn" Text="Ingresar" />
                </div>
            </form>
           
       </div>
   </main>
</body>
</html>
