using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentadora_Aplicacion;
//sustract resta dos fechas
namespace Rentadora_Web
{
    public partial class registrarAlquiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMarca.DataSource = Rentadora.Instancia.listarMarcas();
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("-- Seleccione una marca --", "0"));
                ddlModelo.Enabled = false;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text;
            string fechaFin = txtFechaFin.Text;
            string fechaInicio = txtFechaInicio.Text;
            string horaFin = txtHoraFin.Text;
            string horaInicio = txtHoraInicio.Text;
        }

        private void vaciarFormulario()
        {

        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string marca = ddlMarca.Text;
            if (marca == "0")
            {
                ddlModelo.Enabled = false;
            }
            else
            {
                ddlModelo.Enabled = true;
                ddlModelo.DataSource = Rentadora.Instancia.listarModelos(marca);
                ddlModelo.DataBind();
            }   
        }


    }
}