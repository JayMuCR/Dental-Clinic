<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Facturar.aspx.cs" Inherits="WEB.Formulario_web13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Estilo/Factura.css" rel="stylesheet" />
    <div id="menu">
    <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource2"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
</div>
    <h1>Facturacion</h1>
    <h2>Selecciona los servicios que deseas agregar a la factura</h2>
            <div class="input-group">
                <label for="Cedula">Cedula Hijo:</label>
                <input type="text" id="Cedula" name="Cedula" runat="server" required>
            </div>

            <div class="input-group">
            <label for="codigo">Codigo:</label>
            <input type="text" id="Codigo" name="codigo" runat="server" required>
            </div>
                
            <div class="input-group">
            <label for="costo">Costo:</label>
            <input type="text" id="Costo" name="costo" runat="server" required>
            </div>




    <div>
        <asp:GridView ID="GvServicios" runat="server" AutoGenerateColumns="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GvServicios_SelectedIndexChanged"></asp:GridView>
    </div>

    <div>
        <asp:Button ID="BtnAgregar" runat="server" Text="Facturar" OnClick="BtnAgregar_Click" />
    </div>
</asp:Content>
