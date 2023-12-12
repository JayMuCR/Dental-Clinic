<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Acercade.aspx.cs" Inherits="WEB.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Estilo/Acercade.css" rel="stylesheet" />
    <div id="menu">
        <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1"></asp:Menu>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
    <br />
    <asp:Label ID="lblAcercaDe1" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblAcercaDe2" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblAcercaDe3" runat="server" Text=""></asp:Label>
</asp:Content>
