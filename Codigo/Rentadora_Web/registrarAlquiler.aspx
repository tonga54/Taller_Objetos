<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="registrarAlquiler.aspx.cs" Inherits="Rentadora_Web.registrarAlquiler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sectionTitle" runat="server">
    Alta Evento
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="articleContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaEvento" ErrorMessage="Fecha de nacimiento vacia" Display="Dynamic" ValidationGroup="altaEvento">*</asp:RequiredFieldValidator>
    <asp:TextBox ID="txtFechaEvento" runat="server" TextMode="Date" ValidationGroup="altaEvento"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Turno"></asp:Label>
    <asp:DropDownList ID="ddlTurno" runat="server" ValidationGroup="altaEvento">
    </asp:DropDownList>
    <asp:Label ID="Label3" runat="server" Text="Descripcion"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescripcion" Display="Dynamic" ErrorMessage="Descripcion vacia" ValidationGroup="altaEvento" Width="16px">*</asp:RequiredFieldValidator>
    <asp:TextBox ID="txtDescripcion" runat="server" ValidationGroup="altaEvento"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Text="Nombre del cliente"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCliente" ErrorMessage="Nombre del cliente vacio" Display="Dynamic" ValidationGroup="altaEvento">*</asp:RequiredFieldValidator>
    <asp:TextBox ID="txtCliente" runat="server" ValidationGroup="altaEvento"></asp:TextBox>
    <asp:Label ID="Label11" runat="server" Text="Tipo de evento"></asp:Label>
    <div id="radioButtonsLine">
        <asp:Label ID="Label5" runat="server" Text="Estandar"></asp:Label>
        <asp:RadioButton ID="rbnEstandar" runat="server" GroupName="tipoEvento" OnCheckedChanged="rbnEstandar_CheckedChanged" AutoPostBack="True" ValidationGroup="altaEvento" />
        <asp:Label ID="Label6" runat="server" Text="Premium"></asp:Label>
        <asp:RadioButton ID="rbnPremium" runat="server" GroupName="tipoEvento" OnCheckedChanged="rbnPremium_CheckedChanged" AutoPostBack="True" ValidationGroup="altaEvento"/>
    </div>
    <asp:Panel ID="pnlEstandar" runat="server">
        <asp:Label ID="Label13" runat="server" Text="Cant asistentes"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCantAsistentesEstandar" ErrorMessage="Cantidad asistentes vacio" Display="Dynamic" Width="16px" ValidationGroup="altaEvento">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtCantAsistentesEstandar" ErrorMessage="Cantidad de asistentes menor a 0 o mayor a 10" MaximumValue="10" MinimumValue="1" Display="Dynamic" Type="Integer" ValidationGroup="altaEvento">*</asp:RangeValidator>
        <asp:TextBox ID="txtCantAsistentesEstandar" runat="server" TextMode="Number" ValidationGroup="altaEvento"></asp:TextBox>

        <asp:Label ID="Label8" runat="server" Text="Duracion"></asp:Label>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Rango invalido" MaximumValue="4" MinimumValue="1" ControlToValidate="txtDuracion" Width="16px" ValidationGroup="altaEvento">*</asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDuracion" ErrorMessage="Duracion menor a 0 o mayor a 4" ValidationGroup="altaEvento">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtDuracion" runat="server" TextMode="Number" ValidationGroup="altaEvento"></asp:TextBox>
    </asp:Panel>  
    <asp:Panel ID="pnlPremium" runat="server">
        <asp:Label ID="Label14" runat="server" Text="Cant asistentes"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCantAsistentesPremium" ErrorMessage="Cantidad asistentes vacio" Display="Dynamic" ValidationGroup="altaEvento">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtCantAsistentesPremium" ErrorMessage="Cantidad de asistentes menor a 0 o mayor a 100" MaximumValue="100" MinimumValue="1" Display="Dynamic" Width="16px" Type="Integer" ValidationGroup="altaEvento">*</asp:RangeValidator>
        <asp:TextBox ID="txtCantAsistentesPremium" runat="server" TextMode="Number" ValidationGroup="altaEvento"></asp:TextBox>
   </asp:Panel>  
    <asp:Label ID="Label9" runat="server" Text="Servicios"></asp:Label>
    <asp:DropDownList ID="ddlServicios" runat="server" ValidationGroup="altaEvento"></asp:DropDownList>
    <asp:Label ID="Label10" runat="server" Text="Cant asistentes para el servicio"></asp:Label>
    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtCantAsistentesServicio" ErrorMessage="Rango invalido" MaximumValue="100" MinimumValue="1" Display="Dynamic" Type="Integer" ValidationGroup="altaEvento">*</asp:RangeValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCantAsistentesServicio" ErrorMessage="Cantidad de asistentes para el servicio se encuentra vacio" Display="Dynamic" ValidationGroup="altaEvento">*</asp:RequiredFieldValidator>
    <asp:TextBox ID="txtCantAsistentesServicio" runat="server" TextMode="Number" ValidationGroup="altaEvento"></asp:TextBox>
    <asp:Label ID="Label12" runat="server" Text="Subir una foto del evento (.jpg, .png, .bmp)"></asp:Label>
    <asp:FileUpload id="fileImagen" runat="server" />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="fileImagen" ErrorMessage="Imagen requerida">*</asp:RequiredFieldValidator>

    <div style="display:block;">
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClientClick="return eventValidation();" OnClick="btnRegistrar_Click" ValidationGroup="altaEvento"/>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="altaEvento" />
    <div style="clear:both;"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footerContent" runat="server">
    <asp:Label ID="lblEstado" runat="server"></asp:Label>
</asp:Content>
