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

        public bool registrarUsuario(string nombre, string contrasenia, int rol)
        {
            bool devolucion = false;
            if(nombre != "" && contrasenia != "" && rol > 0 && rol < 3)
            {
                devolucion = CUsuario.Instancia.registrarUsuario(nombre, contrasenia, rol);
            }

            return devolucion;
        }

        //Particular
        public bool agregarCliente(int telefono, int documento, int tipoDocumento, string pais, string nombre, string apellido)
        {
            bool devolucion = CCliente.Instancia.agregarCliente(telefono, documento, tipoDocumento, pais, nombre, apellido);
            return devolucion;
        }

        //Empresa
        public bool agregarCliente(int telefono, int rut, string razonSocial, string nombre)
        {
            bool devolucion = CCliente.Instancia.agregarCliente(telefono, rut, razonSocial, nombre);
            return devolucion;
        }

        public List<Alquiler> listadoVehiculosRetrasados(int rol)
        {
            List<Alquiler> lista = null;
            //Gerente
            if (rol == 3)
            {
                lista = CAlquiler.Instancia.listadoVehiculosRetrasados();
            }
            return lista;

        }

        public Alquiler buscarAlquiler(string matricula)
        {
            Alquiler alq= CAlquiler.Instancia.buscarAlquiler(matricula);
            return alq;
        }

        public bool devolverVehiculo(string matricula)
        {
            bool devolucion = CAlquiler.Instancia.devolverVehiculo(matricula);
            return devolucion;
        }

        public void alquilarVehiculo(DateTime fechaIni, DateTime fechaFin, string marca, string modelo)
        {
            
        }


    }

}
