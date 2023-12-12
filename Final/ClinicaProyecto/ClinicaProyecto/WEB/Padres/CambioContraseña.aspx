<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CambioContraseña.aspx.cs" Inherits="WEB.CambioContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link href="/Estilo/CambioContraseña.css" rel="stylesheet" />
    <div id="menu">
    <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
</div>
    <section class="login-container">
    <h1>Cambiar Contraseña</h1>
    <h2>Ingresa los datos</h2>
    <div class="input-group">
        <label for="email">Correo Electrónico:</label>
        <input type="email" id="Email" runat="server" name="email" required>
    </div>
    <div class="input-group">
        <label for="nuevaContrasena">Nueva Contraseña:</label>
        <input type="password" id="NuevaContrasena" runat="server" name="nuevaContrasena" required>
    </div>
    <div class="input-group">
       
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
    </div>
</section>

</asp:Content>
