<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="WEB.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio Sesion</title>
     <link href="Login.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Iniciar Sesión</h2>
            <asp:Login ID="Login" runat="server" DisplayRememberMe="False" LoginButtonText="Iniciar Sesion" OnAuthenticate="Login_Authenticate" PasswordLabelText="Contrasena:" RememberMeText="" TitleText="" UserNameLabelText="Correo:" FailureText="Informacion erronea, intentalo nuevamente.">
            </asp:Login>
        </div>
    </form>
</body>
</html>
