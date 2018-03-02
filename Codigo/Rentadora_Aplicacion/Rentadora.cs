using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rentadora_Dominio;
using System.IO;

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

        public string nombreUsuario(Usuario usu)
        {
            string retorno = "";
            if(usu != null)
            {
                retorno = CUsuario.Instancia.nombre(usu);
            }
            return retorno;
        }

        public string rolUsuario(Usuario usu)
        {
            string retorno = "";
            if (usu != null)
            {
                retorno = CUsuario.Instancia.rol(usu);
            }
            return retorno;
        }

        public bool registrarUsuario(string nombre, string contrasenia, string rol)
        {
            bool devolucion = false;
            if(nombre != "" && contrasenia != "" && rol != "")
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
        public bool agregarCliente(int telefono, int rut, string razonSocial, string nombre, int anio)
        {
            bool devolucion = CCliente.Instancia.agregarCliente(telefono, rut, razonSocial, nombre, anio);
            return devolucion;
        }

        public List<Alquiler> listadoVehiculosRetrasados(string rol)
        {
            List<Alquiler> lista = null;
            //Gerente
            if (rol == "gerente")
            {
                lista = CAlquiler.Instancia.listadoVehiculosRetrasados();
            }
            return lista;

        }

        public TipoVehiculo buscarTipoVehiculo(string modelo,string marca)
        {
            TipoVehiculo tipoVehiculo = CTipoVehiculo.Instancia.buscarTipoVehiculo(modelo, marca);
            return tipoVehiculo;
        }

        public void grabar(string rutaArchivo, string nombre, DateTime fecha)
        {
            string fechaCorta = "";
            fechaCorta = fecha.ToShortDateString();

            if (File.Exists(rutaArchivo))
            {
                StreamWriter sw = File.AppendText(rutaArchivo);
                sw.WriteLine(nombre + "-" + fechaCorta);
                sw.Close();
            }else
            {
                FileStream fs = File.Create(rutaArchivo);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(nombre + "-" + fechaCorta);
                sw.Close();
            }

        }

        public void leerArchivo(string rutaArchivo)
        {
            StreamReader str = null;
            string linea = "";
            try
            {
                FileStream stream = new FileStream(rutaArchivo, FileMode.Open);
                str = new StreamReader(stream);

                while ((linea = str.ReadLine()) != null)
                {
                    string[] datos = linea.Split('@');   
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                if(str != null)
                {

                }
                str.Close();
            }

        }


        public void leerDatosVehiculos(string rutaArchivo)
        {

            FileStream stream = new FileStream(rutaArchivo, FileMode.Open);
            StreamReader str = new StreamReader(stream);
            string linea = "";
            try
            {
                while ((linea = str.ReadLine()) != null)
                {
                    string[] datos = linea.Split('@');                    string matricula = datos[0];
                    string marca = datos[1];
                    string modelo = datos[2];
                    int anio = 0;
                    int.TryParse(datos[3], out anio);
                    int kilometraje = 0;
                    int.TryParse(datos[4], out kilometraje);
                    List<string> fotos = new List<string>();
                    for (int i = 5; i < datos.Length; i++)
                    {
                        fotos.Add(datos[i]);
                    }
                    TipoVehiculo tipoVeh = this.buscarTipoVehiculo(marca,modelo);
                    if(tipoVeh != null)
                    {
                        this.cargarVehiculos(matricula, anio, kilometraje, fotos,tipoVeh);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                str.Close();
            }
        }


        public void leerDatosTiposVehiculos(string rutaArchivo)
        {

            FileStream stream = new FileStream(rutaArchivo, FileMode.Open);
            StreamReader str = new StreamReader(stream);
            string linea = "";
            try
            {
                while ((linea = str.ReadLine()) != null)
                {
                    string[] datos = linea.Split('@');
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                str.Close();
            }
        }
        public Vehiculo buscarVehiculoXMatricula(string matricula)
        {
            Vehiculo veh = CVehiculo.Instancia.buscarVehiculoXMatricula(matricula);
            return veh;
        }

        public List<Alquiler> buscarAlquilerXMatricula(string matricula)
        {
            Alquiler alquiler = null;
            List<Alquiler> alq = new List<Alquiler>();
            Vehiculo veh = buscarVehiculoXMatricula(matricula);
            if(veh != null)
            {
                alquiler = CAlquiler.Instancia.buscarAlquiler(veh);
                alq.Add(alquiler);
            }
            
            return alq;
        }

        public Cliente buscarCliente(int documento)
        {
            Cliente cli = CCliente.Instancia.buscarCliente(documento);
            return cli;
        }

        public bool devolverVehiculo(string matricula)
        {
            bool devolucion = false;
            Vehiculo veh = buscarVehiculoXMatricula(matricula);

            if (veh != null)
            {
                devolucion = CAlquiler.Instancia.devolverVehiculo(veh);
            }

            return devolucion;
        }

        public List<string> buscarMatriculasXCliente(int documento)
        {
            List<string> devolucion = null;
            Cliente cli = CCliente.Instancia.buscarCliente(documento);
            if(cli != null)
            {
                devolucion = CAlquiler.Instancia.buscarMatriculasXCliente(cli);
            }

            return devolucion;

        }

        public string alquilarVehiculo(DateTime fechaIni, DateTime fechaFin, int horaIni, int horaFIn, string matricula,int documento)
        {
            Vehiculo veh = CVehiculo.Instancia.comprobarDisponibilidad(matricula);
            string devolucion = "";
            if(veh != null)
            {
                Cliente cli = buscarCliente(documento);
                if (cli != null)
                {
                    CAlquiler.Instancia.registrarAlquiler(cli, veh, horaIni, horaFIn, fechaIni, fechaFin);
                }
                else
                {
                    devolucion = "No existe el cliente";
                }

            }else
            {
                devolucion = "El vehiculo ya no esta disponible";
            }

            return devolucion;
        }

        public List<Vehiculo> buscarVehiculoDisponible(string marca, string modelo)
        {
            List<Vehiculo> devolucion = CVehiculo.Instancia.vehiculosDisponibles(marca,modelo);
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

        public bool cargarVehiculos(string matricula, int anio, decimal kilometraje,List<string> fotos, TipoVehiculo tipoVehiculo)
        {
            CVehiculo.Instancia.cargarVehiculos(matricula, anio, kilometraje, fotos, tipoVehiculo);
            return false; // cambiar
        }

        public void preCargarDatos()
        {
            Rentadora.Instancia.agregarCliente(098125846, 15151212, "Empresa X", "Luis",1980);
            Rentadora.instancia.cargarTIposVehiculos("Chevrolet", "Onix", 400);
            Rentadora.Instancia.registrarUsuario("gaston", "1234", "gerente");
            Rentadora.Instancia.registrarUsuario("charly", "1234", "vendedor");
            //Rentadora.instancia.cargarTIposVehiculos("Volskwagen", "C4", 500);
            //Rentadora.instancia.cargarTIposVehiculos("Chevrolet", "V4", 200);

            //List<string> img = new List<string> { "img/1.jpeg", "img/2.jpeg", "img/3.jpeg" };
            //CVehiculo.Instancia.cargarVehiculos("CXX-4872", new DateTime(), 15000, img, CTipoVehiculo.Instancia.TipoVehiculos[0]);

            //img = new List<string> { "img/4.jpeg", "img/5.jpeg", "img/6.jpeg" };
            //CVehiculo.Instancia.cargarVehiculos("CXX-4872", new DateTime(), 15000, img, CTipoVehiculo.Instancia.TipoVehiculos[1]);
        }

        public void preCargarAlquileres()
        {
            Rentadora.Instancia.alquilarVehiculo(new DateTime(2018, 02, 01), new DateTime(2018, 02, 10), 15, 20, "ASC-3732", 15151212);
        }


    }

}
