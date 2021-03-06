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
    public partial class registrarAlquiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string documento = Request.QueryString["documento"];
                if (documento != null && documento != "")
                {
                    btnRegistrar.Visible = true;

                    pnlPaso1.Visible = false;
                    pnlPaso2.Visible = true;
                    pnlPaso3.Visible = false;

                    ddlMarca.DataSource = Rentadora.Instancia.listarMarcas();
                    ddlMarca.DataBind();
                    ddlMarca.Items.Insert(0, new ListItem("-- Seleccione una marca --", "0"));
                    ddlModelo.Items.Insert(0, new ListItem("-- Seleccione un modelo --", "0"));
                    ddlModelo.Enabled = false;
                    grdVehiculos.Visible = false;
                    Label4.Visible = false;

                    string matricula = Request.QueryString["matricula"];

                    if (matricula != null && matricula != "" )
                    {
                        pnlPaso2.Visible = false;
                        pnlPaso3.Visible = true;
                    }
                    else
                    {
                        pnlPaso1.Visible = false;
                        pnlPaso2.Visible = true;
                        pnlPaso3.Visible = false;
                    }
                }
                else
                {
                    pnlPaso1.Visible = true;
                    pnlPaso2.Visible = false;
                    pnlPaso3.Visible = false;
                }
                
            }

        }

        protected void btnPaso1_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text;
            Cliente cli = Rentadora.Instancia.buscarCliente(documento);
            if(cli == null)
            {
                Response.Redirect("registrarCliente.aspx");
            }
            else{
                Response.Redirect("registrarAlquiler.aspx?documento=" + documento);
            }
        }

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

            string devolucion = Rentadora.Instancia.alquilarVehiculo(fechaInicioAux, fechaFinAux, horaInicioAux, horaFinAux, matricula, documento);

            string respuesta = Vendedor.analizarRespuesta(devolucion);
            if (respuesta.IndexOf("CORRECTO") > -1)
            {
                pnlPaso1.Visible = false;
                pnlPaso2.Visible = false;
                pnlPaso3.Visible = false;
            }

            lblEstado.Text = respuesta;
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
            string marca = ddlMarca.Text;
            string modelo = ddlModelo.Text;

            List<Vehiculo> listaVehiculos = Rentadora.Instancia.buscarVehiculoDisponible(marca,modelo);
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
            }

        }

        protected void grdVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdVehiculos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblEstado.Text = "";
            GridViewRow x = grdVehiculos.Rows[e.NewSelectedIndex];
            string matricula = x.Cells[0].Text;
            Response.Redirect("registrarAlquiler.aspx?documento=" + Request.QueryString["documento"] + "&matricula=" + matricula);
        }


    }
}