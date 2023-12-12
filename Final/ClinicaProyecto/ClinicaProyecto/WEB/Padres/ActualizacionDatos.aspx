<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizacionDatos.aspx.cs" Inherits="WEB.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <link href="/Estilo/Actualizacion.css" rel="stylesheet" />
    <div id="menu">
    <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
</div>

     <section class="login-container">
        <h1>Datos Personales</h1>
        <h2>Selecciona tu informacion para modificarla</h2>
        <div class="input-group">
            <label for="nombreCompleto">Nombre completo:</label>
            <input type="text" id="nombreCompleto" runat="server" name="nombreCompleto" required>
        </div>
        <div class="input-group">
            <label for="identificacion">Identificación:</label>
            <input type="text" id="identificacion" runat="server" name="identificacion" required>
        </div>
        <div class="input-group">
            <label for="direccion">Dirección:</label>
            <input type="text" id="Direccion" name="Direccion" runat="server" placeholder="Direccion" required>
          
        </div>
        <div class="input-group">
            <label for="telefono">Teléfono:</label>
            <input type="text" id="Telefono" runat="server" name="telefono" required>
        </div>
        <div class="input-group">
            <label for="correoElectronico">Correo Electrónico:</label>
            <input type="email" id="correoElectronico" runat="server" name="correoElectronico" required>
        </div>
        <div class="input-group">
            
             <asp:Button ID="BtnModificar" runat="server" Text="Actualizar" OnClick="BtnModificar_Click" />
             <br />
        <asp:GridView ID="datospadres" runat="server" AutoGenerateColumns="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="datospadres_SelectedIndexChanged"></asp:GridView>
        </div>
        
       
    </section>
</asp:Content>
