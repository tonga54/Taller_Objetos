<%@ Page Title="" Language="C#" MasterPageFile="~/Gerente.Master" AutoEventWireup="true" CodeBehind="listadoVehiculosRetrasados.aspx.cs" Inherits="Rentadora_Web.listadoVehiculosRetrasados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        #search h3, #searchx h3{
            font-family: "SourceSansPro-Bold";
            text-align: center;
        }

        .sectionContainer #section{
            padding-left: 0px !important;
        }

        #form{
            margin: 0 auto;
            width:100% !important;
            text-align:center;
        }
        table {
            font-family: "SourceSansPro-Regular";
           width: 70%;
            /*display: block;*/
            margin: 0 auto;
        }
         table th {
            padding: 8px 22px !important;
            background-color: #3c8dbc;
            color: white;
            text-align: center;
            margin-right: 50px;
            font-size:1em;
        }

         table td{
             font-size:1em;
         }

        #section {
            overflow-x: auto;
        }

        #form {
            width:85%;
        }

        #search{
            width:30%;
            margin: 0px 35%;
        }

        #searchx{
            width:30%;
            margin: 0px 35%;
        }

        section footer{
            margin-top:25px;
        }

    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="sectionTitle" runat="server">
    Listado de vehiculos retrasados
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="articleContent" runat="server">
    <div id="search">
    <asp:button runat="server" ID="btnListar" text="Listar" OnClick="btnListar_Click" />
    </div>

    <asp:GridView ID="grdVehiculosRetrasados" runat="server" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField DataField="FechaIniCorta" HeaderText="Inicio" />
            <asp:BoundField DataField="FechaFinCorta" HeaderText="Fin" />
            <asp:BoundField DataField="HoraIni" HeaderText="Hora inicio" />
            <asp:BoundField DataField="HoraFin" HeaderText="Hora fin" />
            <asp:BoundField DataField="vehiculo.Matricula" HeaderText="Matricula" />
            <asp:BoundField DataField="cliente.Documento" HeaderText="Documento" />
            <asp:BoundField DataField="vehiculo.Anio" HeaderText="Anio" />
            <asp:BoundField DataField="vehiculo.Fotos" HeaderText="Fotos" HtmlEncode="False" HtmlEncodeFormatString="False" />
        </Columns>
    </asp:GridView>
     
    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContent" runat="server">
    <asp:Label ID="lblEstado" runat="server"></asp:Label>
</asp:Content>
