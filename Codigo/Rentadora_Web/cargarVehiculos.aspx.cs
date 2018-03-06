using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentadora_Aplicacion;

namespace Rentadora_Web
{
    public partial class cargarVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            string ruta = HttpRuntime.AppDomainAppPath + @"vehiculos\vehiculos.txt";
            Rentadora.Instancia.leerDatosVehiculos(ruta);
            lblEstado.Text = "<span class='green'>Vehiculos cargados</span>";
        }

    }
}