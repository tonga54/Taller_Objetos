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
    public partial class WebForm1 : System.Web.UI.Page
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
                btnRegistrar.Visible = false;

                pnlPaso1.Visible = true;
                pnlPaso2.Visible = false;
                pnlPaso3.Visible = false;

            }
            else
            {

                Session["tipoCliente"] = ddlTipoCliente.SelectedValue.ToString();
                
                switch (Session["tipoCliente"].ToString())
                {
                    case "P":
                        pnlPaso1.Visible = false;
                        pnlPaso2.Visible = true;
                        btnRegistrar.Visible = true;
                        break;
                    case "E":
                        pnlPaso1.Visible = false;
                        pnlPaso3.Visible = true;
                        btnRegistrar.Visible = true;
                        break;
                    default:
                        lblEstado.Text = "Debe seleccionar un tipo de cliente";
                        break;
                }
            }
        }

        protected void btnPaso3_Click(object sender, EventArgs e)
        {

            string nombre;
            string telefono;

            if (Session["tipoCliente"].ToString() == "P")
            {
                nombre = txtNombre1.Text;
                telefono = txtTelefono1.Text;
            }
            else
            {
                nombre = txtNombre2.Text;
                telefono = txtTelefono2.Text;
            }
       
            string apellido = txtApellido1.Text;
            string documento = txtDocumento1.Text;
            string tipoDocumento = ddlTipoCliente1.SelectedValue.ToString();
            string pais = ddlPais1.SelectedValue.ToString();
            string razonSocial = txtRazonSocial1.Text;
            string rut = txtRut1.Text;
            string anio = txtAnio1.Text;
            int rutAux = -1;
            int anioAux = -1;
            int telefonoAux = -1;        

            if (rut != "")
            {
                int.TryParse(rut, out rutAux);
            }

            if (anio != "")
            {
                int.TryParse(anio, out anioAux);
            }

            if (telefono != "")
            {
                int.TryParse(telefono, out telefonoAux);
            }

            switch (Session["tipoCliente"].ToString())
            {
                case "P":
                    Rentadora.Instancia.agregarCliente(telefonoAux, documento, tipoDocumento, pais, nombre, apellido);
                    break;
                case "E":
                    Rentadora.Instancia.agregarCliente(telefonoAux, rutAux, razonSocial, nombre, anioAux);
                    break;
            }

            lblEstado.Text = "<span class='green'>Cliente ingresado con éxito</span>";
            btnRegistrar.Visible = false;

        }

        protected void ddlTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}