<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="devolverVehiculo.aspx.cs" Inherits="Rentadora_Web.devolverVehiculo" %>
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
    Devolver vehiculo
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="articleContent" runat="server">

    <!--  PASO 1  -->

    <asp:Panel ID="pnlPaso1" runat="server">

        <asp:Label ID="Label3" runat="server" Text="Documento"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDocumento" Display="Dynamic" ErrorMessage="Documento vacio" ValidationGroup="verificarDocumento" Width="16px">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Rango invalido" MinimumValue="0" MaximumValue="999999999999" ControlToValidate="txtDocumento" ValidationGroup="verificarDocumento" Width="16px">*</asp:RangeValidator>
        <asp:TextBox ID="txtDocumento" runat="server" ValidationGroup="verificarDocumento" TextMode="Number"></asp:TextBox>

        <asp:Button ID="btnPaso1" runat="server" Text="Siguiente" OnClick="btnPaso1_Click" ValidationGroup="verificarDocumento"/>

        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="verificarDocumento" />
    </asp:Panel>

    <!--  PASO 2  -->


    <asp:Panel ID="pnlPaso2" runat="server">

        <asp:Label ID="Label9" runat="server" Text="Vehiculos"></asp:Label>
        <asp:DropDownList ID="ddlMatriculas" runat="server" ValidationGroup="manejoVehiculos" AutoPostBack="True" OnSelectedIndexChanged="ddlMatriculas_SelectedIndexChanged" ></asp:DropDownList>

        <asp:Label ID="Label4" runat="server" Text="Coches"></asp:Label>
        <asp:GridView ID="grdVehiculos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdVehiculos_SelectedIndexChanged" OnSelectedIndexChanging="grdVehiculos_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="FechaIniCorta" HeaderText="Inicio" />
                <asp:BoundField DataField="FechaFinCorta" HeaderText="Fin" />
                <asp:BoundField DataField="HoraIni" HeaderText="Hora inicio" />
                <asp:BoundField DataField="HoraFin" HeaderText="Hora fin" />
                <asp:BoundField DataField="cliente.Documento" HeaderText="Documento" />
                <asp:BoundField DataField="vehiculo.Matricula" HeaderText="Matricula" />
                <asp:BoundField DataField="vehiculo.Anio" HeaderText="Anio" />
                <asp:BoundField DataField="vehiculo.Fotos" HeaderText="Fotos" HtmlEncode="False" HtmlEncodeFormatString="False" />
                <asp:BoundField DataField="Monto" HeaderText="Costo" HtmlEncode="False" HtmlEncodeFormatString="False" />
                <asp:BoundField DataField="MontoFaltante" HeaderText="Monto Faltante" HtmlEncode="False" HtmlEncodeFormatString="False" />
                
            </Columns>
        </asp:GridView>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnlPaso3">

        <asp:Label ID="Label1" runat="server" Text="Fecha inicio"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="Fecha inicio vacia" Display="Dynamic" ValidationGroup="registrarAlquiler">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" ValidationGroup="registrarAlquiler"></asp:TextBox>

        <asp:Label ID="Label7" runat="server" Text="Fecha fin"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="Fecha de fin vacia" Display="Dynamic" ValidationGroup="registrarAlquiler">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" ValidationGroup="registrarAlquiler"></asp:TextBox>

        <asp:Label ID="Label15" runat="server" Text="Hora inicio"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtHoraInicio" ErrorMessage="Hora de inicio vacia" Display="Dynamic" ValidationGroup="registrarAlquiler">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtHoraInicio" runat="server" TextMode="Time" ValidationGroup="registrarAlquiler"></asp:TextBox>

        <asp:Label ID="Label16" runat="server" Text="Hora fin"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtHoraFin" ErrorMessage="Hora de fin vacia" Display="Dynamic" ValidationGroup="registrarAlquiler">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtHoraFin" runat="server" TextMode="Time" ValidationGroup="registrarAlquiler"></asp:TextBox>
    
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnPaso3_Click" ValidationGroup="registrarAlquiler"/>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="registrarAlquiler" />
    </asp:Panel>

    
    <div style="clear:both;"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footerContent" runat="server">
    <asp:Label ID="lblEstado" runat="server"></asp:Label>
</asp:Content>
