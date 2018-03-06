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

        public static string analizarRespuesta(string respuesta)
        {
            string devolucion = "";
            if(respuesta.IndexOf("ERROR") > -1){
                devolucion += "<label class='red'>" + respuesta + "</label>";
            }else if(respuesta.IndexOf("CORRECTO") > -1)
            {
                devolucion += "<label class='green'>" + respuesta + "</label>";
            }else
            {
                devolucion = respuesta;
            }
            return devolucion;
        }
    }
}