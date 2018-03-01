using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentadora_Aplicacion;

namespace Rentadora_Web
{
    public partial class Usuario : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["nombre"] == null || Session["rol"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                string rol = Session["rol"].ToString();

                if (rol == "gerente")
                {
                    pnlUsuario.Visible = false;
                    pnlGerente.Visible = true;
                }
                else
                {
                    pnlUsuario.Visible = true;
                    pnlGerente.Visible = false;
                }

            }

        }
    }
}