<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AcercadeFuncionarios.aspx.cs" Inherits="WEB.Formulario_web18" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Estilo/Acercade.css" rel="stylesheet" />
    <div id="menu">
        <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource2"></asp:Menu>
        <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
    </div>
    <br />
    <asp:Label ID="lblAcercaDe1" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblAcercaDe2" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblAcercaDe3" runat="server" Text=""></asp:Label>
</asp:Content>
