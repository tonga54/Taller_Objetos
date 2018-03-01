using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentadora_Aplicacion;

namespace Rentadora_Web
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPassword.Text;

            Rentadora_Dominio.Usuario usu = Rentadora.Instancia.autenticarse(user, password);

            if (usu != null)
            {
                string nombreUsuario = Rentadora.Instancia.nombreUsuario(usu);
                string rolUsuario = Rentadora.Instancia.rolUsuario(usu);
                if(rolUsuario != "" && nombreUsuario != "")
                {
                    Session["nombre"] = nombreUsuario;
                    Session["rol"] = rolUsuario;
                    Response.Redirect("inicio.aspx");
                }
            }
            else
            {
                lblEstado.Text = "Usuario y/o Contraseña invalido";
            }

        }

    }
}