using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentadora_Aplicacion;

namespace Rentadora_Web
{
    public partial class Vendedor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["nombre"] == null || Session["rol"] == null)
            {
                Response.Redirect("index.aspx");
            }

            if (Session["rol"].ToString() != "vendedor") {
                Session.Clear();
                Response.Redirect("index.aspx");
            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}