<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PrincipalInicio.aspx.cs" Inherits="WEB.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="/Estilo/Princip.css" rel="stylesheet" />

    <div id="menu">
    <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
</div>

   
        <div class="Acerca-content">
            <h1>Clinica Dental</h1>
            <asp:Button ID="btnacercade" runat="server" Text="Acerca de nosotros" OnClick="btnRedireccionar_Click" />

        </div>
  
        <div class="Servicios-content">
             <asp:Button ID="BtnServicios" runat="server" Text="Servicios" OnClick="btnRedireccionarServicios_Click" CssClass="boton-blanco" />


            <p>Dándole click a Información de Servicios podrás ver los servicios que brinda la Clínica, además de sus precios y tu Factura.</p>
           
        
            
        </div>
    
           <div class="Niño-content">
            <div class="input-group">
                <h1 style="height: 38px">¡Bienvenidos a su Clinica Dental Infantil Happy Teeth!</h1>
                &nbsp;
      
            </div>
               <div class="input-group">
             <asp:Button ID="BtnAgregarHijo" runat="server" Text="Dale click aquí si quieres agregar un hijo o modificar su informacion" OnClick="btnRedireccionarHijo_Click" />
                </div>

            <div class="input-group">
                <asp:Button ID="BtnModificarPadre" runat="server" Text="Dale click aquí si quieres modificar tus datos personales" OnClick="btnRedireccionarDatos_Click" />
            </div>
               <div class="input-group">
    <asp:Button ID="BtnContraseña" runat="server" Text="Dale click aquí si quieres modificar tu contraseña de Inicio Sesion" OnClick="btnRedireccionarContraseña_Click" />
</div>
        </div>
   


</asp:Content>


