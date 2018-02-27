﻿using System;
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
            string rutaArchivo = HttpRuntime.AppDomainAppPath + @"binario\serial.bin";


            if (File.Exists(rutaArchivo))
            {
                Repositorio rep = new Repositorio(rutaArchivo);
                rep.Deserealizable();
            }else
            {
                Rentadora.Instancia.preCargarDatos();
            }

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