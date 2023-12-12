<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MantenimientoServicios.aspx.cs" Inherits="WEB.Formulario_web4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Estilo/MantServicios.css" rel="stylesheet" />
    <div id="menu">
    <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource2"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
</div>
    <div class="input-group">
        <label for="servicio">Servicio:</label>
        <input type="text" id="Servicio" runat="server" name="servicio" required />
    </div>
        <div class="input-group">
        <label for="Codigo">Codigo:</label>
        <input type="text" id="Codigo" runat="server" name="Codigo" required />
    </div>

    <div class="input-group">
        <label for="costo">Costo:</label>
        <input type="text" id="Costo" runat="server" name="costo" required />
    </div>
    <div>
        <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" />

        <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" visible="false"/>
    </div>
    <div>
        <asp:GridView ID="GvServicios" AutoGenerateColumns="True" AutoGenerateSelectButton="True" runat="server" OnSelectedIndexChanged="GvServicios_SelectedIndexChanged"></asp:GridView>
    </div>


</asp:Content>

