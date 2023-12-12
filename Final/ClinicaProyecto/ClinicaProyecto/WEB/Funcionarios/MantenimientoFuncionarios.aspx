<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MantenimientoFuncionarios.aspx.cs" Inherits="WEB.Formulario_web3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Estilo/MantFuncionario.css" rel="stylesheet" />
    <div id="menu">
    <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource2"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
</div>
    <section class="login-container">
    <h1>Datos de Funcionarios</h1>
    <h2>Ingresa los datos</h2>
        <div class="input-group">
        <label for="NombreFuncionario">Nombre del Funcionario:</label>
        <input type="text" id="NombreFuncionario" runat="server" name="NombreFuncionario" required>
    </div>
    <div class="input-group">
        <label for="identificacionFuncionario">Número de identificación del Funcionario:</label>
        <input type="text" id="IdentificacionFuncionario" runat="server" name="identificacionFuncionario" required>
    </div>
        <div class="input-group">
    <label for="Password">Password:</label>
    <input type="password" id="Password" runat="server" name="Password" required>
</div>


    <div class="input-group">
        <label for="email">Correo Electrónico:</label>
        <input type="email" id="Email" name="email" runat="server" required>
    </div>
    <div class="input-group">
        <label for="estado">Estado:</label>
        <select id="Estado" name="estado" runat="server" required>
            <option value="">--Selecciona una opcion--</option>
            <option value="activo">Activo</option>
            <option value="inactivo">Inactivo</option>
        </select>
    </div>
    <div class="input-group">
        <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" />

 <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" />
    </div>
    <asp:GridView ID="GridViewFuncionarios" AutoGenerateColumns="True" AutoGenerateSelectButton="True" runat="server" OnSelectedIndexChanged="GridViewFuncionarios_SelectedIndexChanged"></asp:GridView>
</section>
</asp:Content>
