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
            usr = CUsuario.Instancia.buscarUsuario(nombre, contrasenia);
            return usr;
        }

        public string nombreUsuario(Usuario usu)
        {
            string retorno = CUsuario.Instancia.nombre(usu);   
            return retorno;
        }

        public string rolUsuario(Usuario usu)
        {
            string retorno = CUsuario.Instancia.rol(usu);
            return retorno;
        }

        public string registrarUsuario(string nombre, string contrasenia, string rol)
        {
            string devolucion = CUsuario.Instancia.registrarUsuario(nombre, contrasenia, rol);
            return devolucion;
        }

        //Particular
        public string agregarCliente(int telefono, string documento, string tipoDocumento, string pais, string nombre, string apellido)
        {
            string devolucion = CCliente.Instancia.agregarCliente(telefono, documento, tipoDocumento, pais, nombre, apellido);
            return devolucion;
        }

        //Empresa
        public string agregarCliente(int telefono, long rut, string razonSocial, string nombre, int anio)
        {
            string devolucion = CCliente.Instancia.agregarCliente(telefono, rut, razonSocial, nombre, anio);
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
                        if (buscarVehiculoXMatricula(matricula) == null)
                        {
                            this.cargarVehiculo(matricula, anio, kilometraje, fotos, tipoVeh);
                        }
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
                    string marca = datos[0];
                    string modelo = datos[1];
                    decimal precioDiario = 0;
                    decimal.TryParse(datos[2], out precioDiario);

                    if (buscarTipoVehiculo(modelo, marca) == null)
                    {
                        this.cargarTipoVehiculo(marca, modelo, precioDiario);
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

        public Cliente buscarCliente(string documento)
        {
            Cliente cli = CCliente.Instancia.buscarCliente(documento);
            return cli;
        }

        public string devolverVehiculo(string matricula)
        {
            Vehiculo veh = buscarVehiculoXMatricula(matricula);
            string devolucion = CAlquiler.Instancia.devolverVehiculo(veh);
            return devolucion;
        }

        public List<string> buscarMatriculasXCliente(string documento)
        {
            List<string> devolucion = null;
            Cliente cli = CCliente.Instancia.buscarCliente(documento);
            if(cli != null)
            {
                devolucion = CAlquiler.Instancia.buscarMatriculasXCliente(cli);
            }

            return devolucion;

        }

        public string alquilarVehiculo(DateTime fechaIni, DateTime fechaFin, int horaIni, int horaFIn, string matricula, string documento)
        {
            Vehiculo veh = CVehiculo.Instancia.comprobarDisponibilidad(matricula);
            Cliente cli = buscarCliente(documento);
            string devolucion = CAlquiler.Instancia.registrarAlquiler(cli, veh, horaIni, horaFIn, fechaIni, fechaFin);
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

        public string cargarTipoVehiculo(string modelo, string marca, decimal precioDiario)
        {
           string resultado = CTipoVehiculo.Instancia.cargarTipo(modelo, marca, precioDiario);
           return resultado;
        }

        public string cargarVehiculo(string matricula, int anio, decimal kilometraje,List<string> fotos, TipoVehiculo tipoVehiculo)
        {
            string resultado = CVehiculo.Instancia.cargarVehiculo(matricula, anio, kilometraje, fotos, tipoVehiculo);
            return resultado;
        }

        public void preCargarDatos()
        {
            Rentadora.Instancia.agregarCliente(098125846, 123456789123, "Empresa X", "Luis",1980);
            Rentadora.Instancia.registrarUsuario("gerente1", "gerente1", "gerente");
            Rentadora.Instancia.registrarUsuario("administrador1", "administrador1", "administrador");
            Rentadora.Instancia.registrarUsuario("vendedor1", "vendedor1", "vendedor");
        }

        public void preCargarAlquileres()
        {
            Rentadora.Instancia.alquilarVehiculo(DateTime.Now, new DateTime(2018, 03, 13), 15, 20, "ASC-3732", "123456789123");
        }


    }

}
