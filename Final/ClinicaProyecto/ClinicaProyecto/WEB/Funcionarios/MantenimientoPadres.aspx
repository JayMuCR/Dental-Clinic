<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MantenimientoPadres.aspx.cs" Inherits="WEB.Funcionarios.MantenimientoPadres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Estilo/MantPadre.css" rel="stylesheet" />
    <div id="menu">
    <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource2"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
</div>

    <h1>Datos de Padres</h1>
    <h2>Ingresa los datos</h2>
    <div class="input-group">
        <label for="nombreCompleto">Nombre completo:</label>
        <input type="text" id="NombreCompleto" runat="server" name="nombreCompleto" required />
    </div>
    <div class="input-group">
        <label for="identificacion">Identificación:</label>
        <input type="text" id="Identificacion" runat="server" name="identificacion" required />
    </div>
    <div class="input-group">
        <label for="direccion">Dirección:</label>
        <input type="text" id="Dirección" runat="server" name="Dirección" placeholder="Dirección" required />
    </div>
    <div class="input-group">
        <label for="telefono">Teléfono:</label>
        <input type="text" id="Telefono" runat="server" name="telefono" required />
    </div>
    <div class="input-group">
        <label for="correoElectronico">Correo Electrónico:</label>
        <input type="email" id="CorreoElectronico" runat="server" name="correoElectronico" required />
    </div>
        <div class="input-group">
        <label for="Password">Password:</label>
        <input type="text" id="Password" runat="server" name="Password" required />
    </div>

    <div class="input-group">
        <label for="padreActivo">Estado:</label>
        <select id="PadreActivo" runat="server" name="padreActivo">
            <option value="">--Favor selecciona una opcion--</option>
            <option value="activo">Activo</option>
            <option value="inactivo">Inactivo</option>
        </select>
    </div>
    <div class="input-group">
        <asp:Button ID="BtnAgregar" runat="server"  Text="Agregar" OnClick="BtnAgregar_Click" />

        <asp:Button ID="BtnModificar" runat="server" Text="Modificar" visible="false" OnClick="BtnModificar_Click"/>
    </div>
    <div>
        <asp:GridView ID="datospadres" runat="server" AutoGenerateColumns="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="datospadres_SelectedIndexChanged"></asp:GridView>
    </div>


</asp:Content>