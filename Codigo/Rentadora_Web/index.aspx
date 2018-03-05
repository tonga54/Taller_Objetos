<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Rentadora_Web.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/fonts.css" />
    <link rel="stylesheet" href="css/index.css" />

    <script>
   
        function validar (){
            var user = document.getElementById("<%= txtUser.ClientID %>").value;
            var pass = document.getElementById("<%= txtPassword.ClientID %>").value;
            var bandera = true;
            var mensaje = "ERROR\n";

            if (user == "") {
                mensaje += "El email esta vacio";
                bandera = false;
            }

            if (pass == "") {
                mensaje += "La contraseña esta vacia";
                bandera = false;
            }

            if(!bandera){
                alert(mensaje);
            }
            return bandera;
        }

    </script>

  </head>
  <body>

    <div class="container">
        <form method="post" class="login" runat="server">
            <span class="loginTitle" id="loginTitle">Iniciar Sesion</span>
            <!-- <label for=txtUser"">Usuario</label> -->
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUser" ErrorMessage="Nombre de usuario requerido">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtUser" runat="server" ToolTip="Usuario" PlaceHolder="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password requerido">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ToolTip="Contraseña" PlaceHolder="Password"></asp:TextBox>
                <asp:Button ID="btnIngresar" runat="server" Text="Ingregar" OnClick="btnIngresar_Click"/>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

                <div id="foot">
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </div>

        </form>
    </div>

      
  </body>
</html>
