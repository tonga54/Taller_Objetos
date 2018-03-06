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
    public partial class registrarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "vendedor")
            {
                Session.Clear();
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                pnlPaso1.Visible = true;
                pnlParticular.Visible = false;
                pnlParticular.Visible = false;
                string tipoCliente = Request.QueryString["tc"];
                if (tipoCliente != null && tipoCliente != "")
                {
                    switch (tipoCliente)
                    {
                        case "P":
                            pnlPaso1.Visible = false;
                            pnlParticular.Visible = true;
                            pnlEmpresa.Visible = false;
                            break;
                        case "E":
                            pnlPaso1.Visible = false;
                            pnlParticular.Visible = false;
                            pnlEmpresa.Visible = true;
                            break;
                        default:
                            Response.Redirect("registrarCliente.aspx");
                            break;
                    }
                }
                else
                {
                    pnlPaso1.Visible = true;
                    pnlEmpresa.Visible = false;
                    pnlParticular.Visible = false;
                }

            }
        }

        protected void btnParticular_Click(object sender, EventArgs e)
        {
            int telefono = 0;
            int.TryParse(txtTelefonoParticular.Text, out telefono);
            string documento = txtDocumento.Text;
            string tipoDocumento = ddlTipoDocumento.Text;
            string pais = ddlPais.Text;
            string nombre = txtNombreParticular.Text;
            string apellido = txtApellidoParticular.Text;
   
            string response = Rentadora.Instancia.agregarCliente(telefono, documento, tipoDocumento, pais, nombre, apellido);
            response = Vendedor.analizarRespuesta(response);
            lblEstado.Text = response;
            if (response.IndexOf("CORRECTO") > -1)
            {
                pnlPaso1.Visible = false;
                pnlEmpresa.Visible = false;
                pnlParticular.Visible = false;
            }
        }


        protected void btnEmpresa_Click(object sender, EventArgs e)
        {            
            int telefono = 0;
            int.TryParse(txtTelefonoEmpresa.Text, out telefono);
            long rut = 0;
            long.TryParse(txtRut.Text, out rut);
            string razonSocial = txtRazonSocial.Text;
            string nombre = txtNombreEmpresa.Text;
            int anio = 0;
            int.TryParse(txtAnio.Text, out anio);

            string response = "";
            response = Rentadora.Instancia.agregarCliente(telefono, rut, razonSocial, nombre, anio);
            response = Vendedor.analizarRespuesta(response);
            lblEstado.Text = response;
            if(response.IndexOf("CORRECTO") > -1)
            {
                pnlPaso1.Visible = false;
                pnlEmpresa.Visible = false;
                pnlParticular.Visible = false;
            }
        }

        protected void ddlTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("registrarCliente.aspx?tc=" + ddlTipoCliente.Text);
        }
    }
}