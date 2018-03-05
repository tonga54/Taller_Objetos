using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Rentadora_Aplicacion;
using Rentadora_Dominio;

namespace Rentadora_Web
{
    public partial class listadoVehiculosRetrasados : System.Web.UI.Page
    {

        string rutaArchivo = HttpRuntime.AppDomainAppPath + @"bitacoras\log.txt";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            List<Alquiler> lista = Rentadora.Instancia.listadoVehiculosRetrasados("gerente");
            Rentadora.Instancia.grabar(rutaArchivo,Session["nombre"].ToString(),DateTime.Now);
            grdVehiculosRetrasados.DataSource = lista;
            grdVehiculosRetrasados.DataBind();
        }
    }
}