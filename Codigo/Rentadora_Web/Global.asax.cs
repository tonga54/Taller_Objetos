using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using Rentadora_Aplicacion;

namespace Rentadora_Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            string serializado = HttpRuntime.AppDomainAppPath + @"binario\serial.bin";
            string vehiculos = HttpRuntime.AppDomainAppPath + @"bitacoras\vehiculos.txt";
            string tiposVehiculos = HttpRuntime.AppDomainAppPath + @"bitacoras\tiposVehiculos.txt";
            Rentadora.Instancia.preCargarDatos();


            /*if (File.Exists(serializado))
            {
                Repositorio rep = new Repositorio(serializado);
                rep.Deserealizable();
            }else
            {
                //Rentadora.Instancia.preCargarDatos();
            }
            */

            if (File.Exists(vehiculos))
            {
                Rentadora.Instancia.leerDatosVehiculos(vehiculos);
            }else
            {

            }

            Rentadora.Instancia.preCargarAlquileres();

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            Repositorio rep = new Repositorio(HttpRuntime.AppDomainAppPath + @"binario\serial.bin");
            rep.Serializable();
        }


    }
}