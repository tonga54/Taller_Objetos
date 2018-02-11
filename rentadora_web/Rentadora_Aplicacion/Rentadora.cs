using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rentadora_Dominio;

namespace Rentadora_Aplicacion
{
    public class Rentadora
    {
        private static Rentadora instancia = null;

        public static Rentadora Instancia
        {
            get {
                if (Rentadora.instancia == null)
                {
                    Rentadora.instancia = new Rentadora();
                }
                return Rentadora.instancia;
            }

        }

        private Rentadora() { }



        public Usuario autenticarse(string nombre, string contrasenia)
        {
            Usuario usr = null;
            if (nombre != "" && contrasenia != "")
            {
                usr = CUsuario.Instancia.buscarUsuario(nombre, contrasenia);
            }

            return usr;

        }


    }


}
