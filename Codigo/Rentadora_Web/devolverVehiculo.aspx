<%@ Page Title="" Language="C#" MasterPageFile="~/Vendedor.Master" AutoEventWireup="true" CodeBehind="devolverVehiculo.aspx.cs" Inherits="Rentadora_Web.devolverVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table th{
            padding: 8px !important;
        }

        table{
            text-align:center;
        }

        #form{
            width: 90% !important;
        }

        #articleContent_pnlPaso1{
            width: 40%;
            margin: 0 auto;
        }

        #articleContent_pnlPaso2{
            width:40%;
            margin: 0 auto;
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
    </asp:Panel>

    <asp:Panel ID="pnlGridView" runat="server">
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
                <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Devolver" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <div style="clear:both;"></div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="footerContent" runat="server">
    <asp:Label ID="lblEstado" runat="server"></asp:Label>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/JavaScript.js"></script>
</asp:Content>
