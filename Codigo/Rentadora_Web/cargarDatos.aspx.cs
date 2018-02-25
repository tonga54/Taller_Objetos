using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentadora_Aplicacion;

namespace Rentadora_Web
{
    public partial class cargarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rentadora.Instancia.cargarTiposVehiculos();
            }
        }
    }
}