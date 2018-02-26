using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentadora_Aplicacion;
using Rentadora_Dominio;

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
                grdVehiculos.Visible = false;
                Label4.Visible = false;
                string matricula = Request.QueryString["matricula"];
                string fechaInicio = Request.QueryString["fini"];
                string fechaFin = Request.QueryString["ffin"];

                if (matricula != null && matricula != "" && fechaInicio != null && fechaInicio != "" && fechaFin != null && fechaFin != "")
                {
                    Label1.Visible = false;
                    txtFechaInicio.Visible = false;
                    Label7.Visible = false;
                    txtFechaFin.Visible = false;
                    Label9.Visible = false;
                    ddlMarca.Visible = false;
                    Label2.Visible = false;
                    ddlModelo.Visible = false;
                }
                else
                {
                    Label1.Visible = true;
                    txtFechaInicio.Visible = true;
                    Label7.Visible = true;
                    txtFechaFin.Visible = true;
                    Label9.Visible = true;
                    ddlMarca.Visible = true;
                    Label2.Visible = true;
                    ddlModelo.Visible = true;
                }
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

            List<Vehiculo> listaVehiculos = Rentadora.Instancia.buscarVehiculoDisponible(fechaInicio, fechaFin, modelo);
            grdVehiculos.DataSource = listaVehiculos;
            grdVehiculos.DataBind();

            if (listaVehiculos != null)
            {
                grdVehiculos.Visible = true;
                Label4.Visible = true;
                grdVehiculos.DataSource = listaVehiculos;
                grdVehiculos.DataBind();
            }
            else
            {
                grdVehiculos.Visible = false;
                Label4.Visible = false;
                //ddlMatricula.Items.Insert(0, new ListItem("-- No hay vehiculos disponibles --", "0"));
                //ddlMatricula.Enabled = false;
            }

        }

        protected void grdVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {

            // string TxtNuevaDescripcion = grdEventos.Rows[e.RowIndex] //guardo en un textbox el dato ingresado en el control que agregue al ItemTemplate
        }

        protected void grdVehiculos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblEstado.Text = "";
            GridViewRow x = grdVehiculos.Rows[e.NewSelectedIndex];
            string matricula = x.Cells[0].Text;
            Response.Redirect("registrarAlquiler.aspx?matricula=" + matricula + "&fini=" + txtFechaInicio.Text + "&ffin=" + txtFechaFin.Text);
        }


    }
}