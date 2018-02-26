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

        public List<Vehiculo> buscarVehiculoDisponible(DateTime fechaInicio, DateTime fechaFin, string modelo)
        {
            List<Vehiculo> devolucion = CAlquiler.Instancia.buscarVehiculoDisponibleXFecha(fechaInicio, fechaFin, modelo);
            return devolucion;
        }

        public List<string> listarMarcas()
        {
            return CTipoVehiculo.Instancia.listarMarcas();
        }

        public List<String> listarModelos(string marca)
        {
           return CTipoVehiculo.Instancia.listarModelos(marca);
        }

        public bool cargarTIposVehiculos(string modelo, string marca, decimal precioDiario)
        {
            CTipoVehiculo.Instancia.cargarTipos(modelo, marca, precioDiario);
            return false; // cambiar
        }

        public bool cargarVehiculos(string matricula, DateTime anio, decimal kilometraje,List<string> fotos, TipoVehiculo tipoVehiculo)
        {
            CVehiculo.Instancia.cargarVehiculos(matricula, anio, kilometraje, fotos, tipoVehiculo);
            return false; // cambiar
        }

        public void preCargarDatos()
        {
            Rentadora.instancia.cargarTIposVehiculos("Chevrolet", "Corsa", 400);
            Rentadora.instancia.cargarTIposVehiculos("Volskwagen", "C4", 500);
            Rentadora.instancia.cargarTIposVehiculos("Chevrolet", "V4", 200);

            List<string> img = new List<string> { "img/1.jpeg", "img/2.jpeg", "img/3.jpeg" };
            CVehiculo.Instancia.cargarVehiculos("CXX-4872", new DateTime(), 15000, img, CTipoVehiculo.Instancia.TipoVehiculos[0]);

            img = new List<string> { "img/4.jpeg", "img/5.jpeg", "img/6.jpeg" };
            CVehiculo.Instancia.cargarVehiculos("CXX-4872", new DateTime(), 15000, img, CTipoVehiculo.Instancia.TipoVehiculos[1]);
        }


    }

}
