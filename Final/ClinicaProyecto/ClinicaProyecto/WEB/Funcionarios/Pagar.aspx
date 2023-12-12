<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pagar.aspx.cs" Inherits="WEB.Formulario_web14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Estilo/Pagar.css" rel="stylesheet" />
    <div id="menu">
    <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource2"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
</div>
    <section class="login-container">
    <h1>Datos de Facturación</h1>

            <div class="input-group">
                <label for="CedulaHijo">Cedula del hijo:</label>
                <input type="text" id="CedulaHijo" name="CedulaHijo" runat="server" required>
                <br />
                <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />

                <br />
                <label for="Info Costo">Total a pagar(Con IVA Incluidos):</label>
                <label for="Costo" id="Costo" runat="server">--</label>
                <br />
                <label for="Info Codigo">Codigo del servicio:</label>
                <label for="Codigo" id="Codigo" runat="server">--</label>
                <br />
            </div>

    <asp:GridView ID="GridViewFacturas" AutoGenerateColumns="True" AutoGenerateSelectButton="True" runat="server" OnSelectedIndexChanged="GridViewFacturas_SelectedIndexChanged"></asp:GridView>

      <asp:Button ID="BtnPagar" runat="server" Text="Pagar" OnClick="BtnPagar_Click" />

</section>



</asp:Content>
