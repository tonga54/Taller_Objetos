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

    <!--  PARTICULAR  -->


    <asp:Panel ID="pnlParticular" runat="server">

        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreParticular" ErrorMessage="Nombre vacio" Display="Dynamic" ValidationGroup="registrarParticular">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtNombreParticular" runat="server" ValidationGroup="registrarParticular"></asp:TextBox>
        <asp:Label ID="Label19" runat="server" Text="Apellido"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellidoParticular" ErrorMessage="Apellido vacio" Display="Dynamic" ValidationGroup="registrarParticular">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtApellidoParticular" runat="server" ValidationGroup="registrarParticular"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" Text="Teléfono"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTelefonoParticular" ErrorMessage="Teléfono vacio" Display="Dynamic" ValidationGroup="registrarParticular">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtTelefonoParticular" runat="server" ValidationGroup="registrarParticular" TextMode="Phone"></asp:TextBox>
        <asp:Label ID="Label17" runat="server" Text="Tipo de documento"></asp:Label>
        <asp:DropDownList ID="ddlTipoDocumento" runat="server" AutoPostBack="False" ValidationGroup="registrarParticular">
            <asp:ListItem Value="ced">Cedula</asp:ListItem>
            <asp:ListItem Value="dni">DNI</asp:ListItem>
            <asp:ListItem Value="pas">Pasaporte</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="Documento"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDocumento" ErrorMessage="Documento vacio" Display="Dynamic" ValidationGroup="registrarParticular">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtDocumento" runat="server" ValidationGroup="registrarParticular"></asp:TextBox>
        <asp:Label ID="Label18" runat="server" Text="Pais"></asp:Label>
        <asp:DropDownList ID="ddlPais" runat="server">
            <asp:ListItem Selected="True" Value="URU">Uruguay</asp:ListItem>
            <asp:ListItem Value="ARG">Argentina</asp:ListItem>
            <asp:ListItem Value="BRA">Brasil</asp:ListItem>
            <asp:ListItem Value="PAR">Paraguay</asp:ListItem>
            <asp:ListItem Value="VEN">Venezuela</asp:ListItem>
            <asp:ListItem Value="BOL">Bolivia</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnParticular" runat="server" Text="Registrar" OnClick="btnParticular_Click" ValidationGroup="registrarParticular"/>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="registrarParticular" />

    </asp:Panel>

    <!--  EMPRESA  -->

    <asp:Panel runat="server" ID="pnlEmpresa">

        <asp:Label ID="Label20" runat="server" Text="Razon Social"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="Razon social vacio" Display="Dynamic" ValidationGroup="registrarEmpresa">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtRazonSocial" runat="server" ValidationGroup="registrarEmpresa"></asp:TextBox>
        <asp:Label ID="Label21" runat="server" Text="RUT"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRut" ErrorMessage="RUT vacio" Display="Dynamic" ValidationGroup="registrarEmpresa">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtRut" runat="server" ValidationGroup="registrarEmpresa" TextMode="Number"></asp:TextBox>
        <asp:Label ID="Label23" runat="server" Text="Nombre contacto"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNombreEmpresa" ErrorMessage="Nombre vacio" Display="Dynamic" ValidationGroup="registrarEmpresa">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtNombreEmpresa" runat="server" ValidationGroup="registrarEmpresa"></asp:TextBox>
        <asp:Label ID="Label24" runat="server" Text="Teléfono"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTelefonoEmpresa" ErrorMessage="Teléfono vacio" Display="Dynamic" ValidationGroup="registrarEmpresa">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtTelefonoEmpresa" runat="server" ValidationGroup="registrarEmpresa" TextMode="Phone"></asp:TextBox>
        <asp:Label ID="Label22" runat="server" Text="Año"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAnio" ErrorMessage="Año vacio" Display="Dynamic" ValidationGroup="registrarEmpresa">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtAnio" runat="server" ValidationGroup="registrarEmpresa" TextMode="Number"></asp:TextBox>
        <asp:Button ID="btnEmpresa" runat="server" Text="Registrar" OnClick="btnEmpresa_Click" ValidationGroup="registrarAlquiler"/>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="registrarEmpresa" />
    </asp:Panel>

   

    
    <div style="clear:both;"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footerContent" runat="server">
    <asp:Label ID="lblEstado" runat="server"></asp:Label>
</asp:Content>