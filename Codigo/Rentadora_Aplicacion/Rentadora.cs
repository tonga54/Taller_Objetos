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

        public void agregarCliente(int tipo, int rut, string razonSocial, int telefono, string nombre, string apellido, string tipoDocumento, string documento, string pais)
        {
            
            switch (tipo)
            {
                case 1:
                    Empresa empresa;
                    empresa = new Empresa(telefono, rut, razonSocial, nombre);
                    CCliente.Instancia.agregarCliente(empresa);
                    break;
                case 2:
                    Particular particular;
                    particular = new Particular(telefono, documento, tipoDocumento, pais, nombre, apellido);
                    CCliente.Instancia.agregarCliente(particular);
                    break;
            }
        }


    }


}
