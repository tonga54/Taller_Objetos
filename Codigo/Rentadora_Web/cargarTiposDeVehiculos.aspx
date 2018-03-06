<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="cargarTiposDeVehiculos.aspx.cs" Inherits="Rentadora_Web.cargarTiposDeVehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sectionTitle" runat="server">
    Cargar tipos de vehiculos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="articleContent" runat="server">
    <asp:Button ID="btnCargar" runat="server" Text="Cargar" OnClick="btnCargar_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footerContent" runat="server">
    <asp:Label ID="lblEstado" runat="server"></asp:Label>
</asp:Content>
