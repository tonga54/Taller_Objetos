<%@ Page Title="" Language="C#" MasterPageFile="~/Vendedor.Master" AutoEventWireup="true" CodeBehind="registrarCliente.aspx.cs" Inherits="Rentadora_Web.registrarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table th{
            padding: 8px !important;
        }

        table{
            text-align:center;
        }
    </style> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sectionTitle" runat="server">
    Registrar Cliente 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="articleContent" runat="server">

    <!--  PASO 1  -->

    <asp:Panel ID="pnlPaso1" runat="server">

        <asp:Label ID="Label3" runat="server" Text="Tipo de cliente"></asp:Label>
        <asp:DropDownList ID="ddlTipoCliente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoCliente_SelectedIndexChanged" ValidationGroup="manejoVehiculos">
            <asp:ListItem Selected="True" Value="S">Seleccionar...</asp:ListItem>
            <asp:ListItem Value="P">Particular</asp:ListItem>
            <asp:ListItem Value="E">Empresa</asp:ListItem>
        </asp:DropDownList>

        <br />

    </asp:Panel>

    <!--  PASO 2  -->


    <asp:Panel ID="pnlPaso2" runat="server">

        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre1" ErrorMessage="Nombre vacio" Display="Dynamic" ValidationGroup="registrarCliente">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtNombre1" runat="server" ValidationGroup="registrarCliente"></asp:TextBox>
        <asp:Label ID="Label19" runat="server" Text="Apellido"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido1" ErrorMessage="Apellido vacio" Display="Dynamic" ValidationGroup="registrarCliente">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtApellido1" runat="server" ValidationGroup="registrarCliente"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" Text="Teléfono"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTelefono1" ErrorMessage="Teléfono vacio" Display="Dynamic" ValidationGroup="registrarCliente">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtTelefono1" runat="server" ValidationGroup="registrarCliente"></asp:TextBox>
        <asp:Label ID="Label17" runat="server" Text="Tipo de documento"></asp:Label>
        <asp:DropDownList ID="ddlTipoCliente1" runat="server" AutoPostBack="True" ValidationGroup="registrarCliente">
            <asp:ListItem Value="1">Cedula</asp:ListItem>
            <asp:ListItem Value="2">DNI</asp:ListItem>
            <asp:ListItem Value="3">Pasaporte</asp:ListItem>
            <asp:ListItem Value="4">RUT</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="Documento"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDocumento1" ErrorMessage="Documento vacio" Display="Dynamic" ValidationGroup="registrarCliente">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtDocumento1" runat="server" ValidationGroup="registrarCliente"></asp:TextBox>
        <asp:Label ID="Label18" runat="server" Text="Pais"></asp:Label>
        <asp:DropDownList ID="ddlPais1" runat="server">
            <asp:ListItem Selected="True" Value="URU">Uruguay</asp:ListItem>
            <asp:ListItem Value="ARG">Argentina</asp:ListItem>
            <asp:ListItem Value="BRA">Brasil</asp:ListItem>
            <asp:ListItem Value="PAR">Paraguay</asp:ListItem>
            <asp:ListItem Value="VEN">Venezuela</asp:ListItem>
            <asp:ListItem Value="BOL">Bolivia</asp:ListItem>
        </asp:DropDownList>

    </asp:Panel>

    <!--  PASO 3  -->

    <asp:Panel runat="server" ID="pnlPaso3">

        <asp:Label ID="Label20" runat="server" Text="Razon Social"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRazonSocial1" ErrorMessage="Razon social vacio" Display="Dynamic" ValidationGroup="registrarCliente">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtRazonSocial1" runat="server" ValidationGroup="registrarCliente"></asp:TextBox>
        <asp:Label ID="Label21" runat="server" Text="RUT"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRut1" ErrorMessage="RUT vacio" Display="Dynamic" ValidationGroup="registrarCliente">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtRut1" runat="server" ValidationGroup="registrarCliente"></asp:TextBox>
        <asp:Label ID="Label23" runat="server" Text="Nombre contacto"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNombre2" ErrorMessage="Nombre vacio" Display="Dynamic" ValidationGroup="registrarCliente">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtNombre2" runat="server" ValidationGroup="registrarCliente"></asp:TextBox>
        <asp:Label ID="Label24" runat="server" Text="Teléfono"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTelefono2" ErrorMessage="Teléfono vacio" Display="Dynamic" ValidationGroup="registrarCliente">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtTelefono2" runat="server" ValidationGroup="registrarCliente"></asp:TextBox>
        <asp:Label ID="Label22" runat="server" Text="Año"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAnio1" ErrorMessage="Año vacio" Display="Dynamic" ValidationGroup="registrarCliente">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtAnio1" runat="server" ValidationGroup="registrarCliente"></asp:TextBox>
            
    </asp:Panel>

    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnPaso3_Click" ValidationGroup="registrarAlquiler"/>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="registrarCliente" />

    
    <div style="clear:both;"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footerContent" runat="server">
    <asp:Label ID="lblEstado" runat="server"></asp:Label>
</asp:Content>