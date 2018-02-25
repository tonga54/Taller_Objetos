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
                ddlModelo.Items.Insert(0, new ListItem("-- Seleccione un modelo --", "0"));
                ddlModelo.Enabled = false;
                ddlMatricula.Visible = false;
                Label4.Visible = false;
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
                ddlModelo.Items.Insert(0, new ListItem("-- Seleccione un modelo --", "0"));
            }   
        }

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fechaInicio = new DateTime();
            DateTime.TryParse(txtFechaInicio.Text, out fechaInicio);

            DateTime fechaFin = new DateTime();
            DateTime.TryParse(txtFechaFin.Text, out fechaFin);

            string modelo = ddlModelo.Text;

            List<string> listaMatriculas = Rentadora.Instancia.buscarVehiculoDisponible(fechaInicio, fechaFin, modelo);

            if (listaMatriculas != null)
            {
                ddlMatricula.Visible = true;
                Label4.Visible = true;
                ddlMatricula.DataSource = listaMatriculas;
                ddlMatricula.DataBind();
            }
            else
            {
                ddlMatricula.Visible = true;
                Label4.Visible = true;
                ddlMatricula.Items.Insert(0, new ListItem("-- No hay vehiculos disponibles --", "0"));
                ddlMatricula.Enabled = false;
            }

        }



    }
}