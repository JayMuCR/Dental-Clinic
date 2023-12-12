<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PrincipalInicioFuncionarios.aspx.cs" Inherits="WEB.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <link href="/Estilo/Princip.css" rel="stylesheet" />
    <div id="menu">
    <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource2"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
</div>


   
        <div class="Acerca-content">
            <h1>Clinica Dental</h1>
            <asp:Button ID="btnacercade" runat="server" Text="Acerca de nosotros" OnClick="btnRedireccionar_Click" />

        </div>
  
        <div class="Servicios-content">
           
        
            
        </div>
    
           <div class="Niño-content">
            <div class="input-group">
            </div>
               <div class="input-group">
    <asp:Button ID="BtnContraseña" runat="server" Text="Dale click aquí si quieres modificar tu contraseña de Inicio Sesion" OnClick="btnRedireccionarContraseña_Click" />
                       <br />
    <asp:Button ID="Facturacion" runat="server" Text="Dale click aquí si quieres crear una factura" OnClick="btnRedireccionarFacturacion_Click" />
                       <br />
    <asp:Button ID="MantenimientoFuncionarios" runat="server" Text="Dale click aquí si quieres modificar funcionarios" OnClick="btnRedireccionarFuncionarios_Click" />
                       <br />
    <asp:Button ID="MantenimientoNiños" runat="server" Text="Dale click aquí si quieres modificar hijos" OnClick="btnRedireccionarHijos_Click" />
                       <br />
    <asp:Button ID="MantenimientoPadres" runat="server" Text="Dale click aquí si quieres modificar y agregar padres" OnClick="btnRedireccionarPadres_Click" />
                       <br />
    <asp:Button ID="MantenimientoServicios" runat="server" Text="Dale click aquí si quieres modificar servicios" OnClick="btnRedireccionarServicios_Click" />
                       <br />
    <asp:Button ID="Pagar" runat="server" Text="Dale click aquí si quieres pagar una factura" OnClick="btnRedireccionarPagar_Click" />
                       <br />
</div>
        </div>
</asp:Content>
