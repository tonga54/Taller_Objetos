﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentadora_Aplicacion;
using Rentadora_Dominio;

namespace Rentadora_Web
{
    public partial class devolverVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                pnlGridView.Visible = false;
                string documento = Request.QueryString["documento"];
                if (documento != null && documento != "")
                {
                    pnlPaso1.Visible = false;
                    pnlPaso2.Visible = true;

                    ddlMatriculas.DataSource = Rentadora.Instancia.buscarMatriculasXCliente(documento);
                    ddlMatriculas.DataBind();
                    ddlMatriculas.Items.Insert(0, new ListItem("-- Seleccione una matricula --", "0"));
                }
                else
                {
                    pnlPaso1.Visible = true;
                    pnlPaso2.Visible = false;
                    pnlGridView.Visible = false;
                }

            }

        }

        protected void btnPaso1_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text;
            Cliente cli = Rentadora.Instancia.buscarCliente(documento);
            if (cli == null)
            {
                Response.Redirect("devolverVehiculo.aspx");
            }
            else
            {
                Response.Redirect("devolverVehiculo.aspx?documento=" + documento);
            }
        }

<<<<<<< HEAD
        protected void btnPaso3_Click(object sender, EventArgs e)
        {
            string documento = Request.QueryString["documento"];
            string matricula = Request.QueryString["matricula"];

            string fechaFin = txtFechaFin.Text;
            string fechaInicio = txtFechaInicio.Text;

            string horaInicio = txtHoraInicio.Text;
            string horaFin = txtHoraInicio.Text.Substring(0, 2);
            int horaInicioAux = -1;
            if (horaInicio != "")
            {
                horaInicio = txtHoraInicio.Text.Substring(0, 2);
                int.TryParse(horaInicio, out horaInicioAux);
            }

            int horaFinAux = -1;
            if (horaFin != "")
            {
                horaFin = txtHoraFin.Text.Substring(0, 2);
                int.TryParse(horaFin, out horaFinAux);
            }

            DateTime fechaInicioAux = new DateTime();
            DateTime fechaFinAux = new DateTime();

            DateTime.TryParse(fechaInicio, out fechaInicioAux);
            DateTime.TryParse(fechaFin, out fechaFinAux);

            Rentadora.Instancia.alquilarVehiculo(fechaInicioAux, fechaFinAux, horaInicioAux, horaFinAux, matricula, documento);

        }


=======
>>>>>>> vehdev
        protected void ddlMatriculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string matricula = ddlMatriculas.Text;
            List<Alquiler> alq = Rentadora.Instancia.buscarAlquilerXMatricula(matricula);
            if (alq != null)
            {
                pnlGridView.Visible = true;
                pnlPaso2.Visible = false;
                grdVehiculos.DataSource = alq;
                grdVehiculos.DataBind();
            }
            else
            {
                pnlGridView.Visible = false;
            }

        }

        protected void grdVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdVehiculos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblEstado.Text = "";
            GridViewRow x = grdVehiculos.Rows[e.NewSelectedIndex];
            string matricula = x.Cells[5].Text;
            bool devolucion = Rentadora.Instancia.devolverVehiculo(matricula);
            if (devolucion)
            {
                lblEstado.Text = "<span class='green'>Vehiculo devuelto correctamente</span>";
            }else
            {
                lblEstado.Text = "<span class='red'>Error al devolver vehiculo</span>";
            }
            
        }


    }
}