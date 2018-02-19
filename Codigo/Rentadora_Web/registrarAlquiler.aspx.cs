using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rentadora_Web
{
    public partial class registrarAlquiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //ddlTurno.Items.Add(new ListItem("Mañana", "man"));
                //ddlTurno.Items.Add(new ListItem("Tarde", "tar"));
                //ddlTurno.Items.Add(new ListItem("Noche", "noc"));
                //pnlEstandar.Visible = false;
                //ddlServicios.DataSource = Empresa.Instancia.Servicios;
                //ddlServicios.DataBind();
            }
        }

        protected void rbnEstandar_CheckedChanged(object sender, EventArgs e)
        {
            pnlEstandar.Visible = true;
            pnlPremium.Visible = false;
        }

        protected void rbnPremium_CheckedChanged(object sender, EventArgs e)
        {
            pnlEstandar.Visible = false;
            pnlPremium.Visible = true;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {/*
            DateTime fecha = DateTime.MinValue;
            DateTime.TryParse(txtFechaEvento.Text, out fecha);

            int cantAsistentesServicio = 0;
            int.TryParse(txtCantAsistentesServicio.Text, out cantAsistentesServicio);
            string cliente = txtCliente.Text;
            string descripcion = txtDescripcion.Text;
            string servicio = ddlServicios.SelectedValue;
            string turno = ddlTurno.SelectedValue;
            string respuesta = "";
            string path = "~/imgs/";
            string imagePath = path + fileImagen.FileName;
            fileImagen.SaveAs(Server.MapPath(imagePath));

            if (rbnEstandar.Checked)
            {
                int cantAsistentes = 0;
                int.TryParse(txtCantAsistentesEstandar.Text, out cantAsistentes);
                int duracion = 0;
                int.TryParse(txtDuracion.Text, out duracion);

               // respuesta = Empresa.Instancia.altaEvento(Session["user"].ToString(), fecha, turno, descripcion, cliente, cantAsistentes, duracion, servicio, cantAsistentesServicio, fileImagen.FileName);
                lblEstado.Text = respuesta;

            }
            else if (rbnPremium.Checked)
            {
                int cantAsistentes = 0;
                int.TryParse(txtCantAsistentesPremium.Text, out cantAsistentes);
               // respuesta = Empresa.Instancia.altaEvento(Session["User"].ToString(), fecha, turno, descripcion, cliente, cantAsistentes, servicio, cantAsistentesServicio, fileImagen.FileName);
                lblEstado.Text = respuesta;
            }

            if (respuesta.IndexOf("RESUMEN") > -1)
            {
                vaciarFormulario();
            }*/
        }

        private void vaciarFormulario()
        {
            txtCantAsistentesServicio.Text = "";
            txtCliente.Text = "";
            txtDescripcion.Text = "";
            txtCantAsistentesPremium.Text = "";
            txtCantAsistentesEstandar.Text = "";
            txtDuracion.Text = "";
            txtFechaEvento.Text = "";
        }
    }
}