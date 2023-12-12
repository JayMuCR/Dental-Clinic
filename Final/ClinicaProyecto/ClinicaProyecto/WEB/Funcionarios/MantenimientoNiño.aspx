<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MantenimientoNiño.aspx.cs" Inherits="WEB.Formulario_web12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Estilo/MantNiño.css" rel="stylesheet" />
    <div id="menu">
    <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource2"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
</div>
    <section class="login-container">
        <h1>Datos de los Niños</h1>
        <h2>Ingresa los datos </h2>
        <div class="input-group">
            <label for="identificacionPadre">Número de identificación del Padre:</label>
            <input type="text" id="identificacionPadre" runat="server" name="identificacionPadre" required>
        </div>
        <div class="input-group">
            <label for="identificacionNino">Número de identificación del Niño:</label>
            <input type="text" id="identificacionNino" runat="server" name="identificacionNino" required>
        </div>
        <div class="input-group">
            <label for="nombre">Nombre Completo:</label>
            <input type="text" id="Nombre" name="nombre" runat="server" required>
        </div>
       
        <div class="input-group">
            <label for="sexo">Sexo:</label>
            <select id="Sexo" runat="server" name="sexo" required>
                <option value="">--Selecciona una opcion--</option>
                <option value="masculino">Masculino</option>
                <option value="femenino">Femenino</option>
            </select>
        </div>
        <div class="input-group">
            <label for="fechaNacimiento">Fecha de nacimiento:</label>
            <input type="date" id="FechaNacimiento" runat="server" name="fechaNacimiento" required>
            <span id="edad"></span>
        </div>
        <div class="input-group">

            <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" />
        
            <asp:Button ID="BtnModificar" runat="server" Text="Modificar" visible="false" OnClick="BtnModificar_Click" />
        </div>
        <asp:GridView ID="GvHijos" runat="server" AutoGenerateColumns="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GvHijos_SelectedIndexChanged"></asp:GridView>

    </section>

</asp:Content>
