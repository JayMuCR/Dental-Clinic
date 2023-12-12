<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="WEB.Formulario_web16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Estilo/Servicios.css" rel="stylesheet" />
    <style>
    .input-group {
        text-align: center; 
    }

    .centered-button {
        margin-top: 10px; 
    }
</style>
    <div id="menu">
    <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
</div>
    <div class="container">
        <div class="grid-view-header">
            <h2>Servicios de la Clínica</h2>
        </div>
        <div class="grid-view-header">
            <h2>Aquí podrás ver tu factura(Los precios ya incluyen el IVA)</h2>
            <br />
        </div>
            <div class="input-group">
            <label for="CedulaHijo">Cedula del hijo:</label>
            <input type="text" id="CedulaHijo" name="CedulaHijo" runat="server" required>
           
            <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
            </div>


        <div class="grid-view-wrapper">
            <div class="grid-view">
                <asp:GridView ID="GvServicios" runat="server" ></asp:GridView>
            </div>

            <div class="grid-view">
                <asp:GridView ID="GvFactura" runat="server"></asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
