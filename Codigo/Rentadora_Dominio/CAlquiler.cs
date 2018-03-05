using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{

    [Serializable]

    public class CAlquiler: ISerializable
    {
        private List<Alquiler> alquileres = new List<Alquiler>();
        private static CAlquiler instancia = null;

        public static CAlquiler Instancia
        {
            get
            {
                if(CAlquiler.instancia == null)
                {
                    CAlquiler.instancia = new CAlquiler();
                }
                return CAlquiler.instancia;
            }
        }

        private CAlquiler()
        {

        }

        public List<Alquiler> listadoVehiculosRetrasados()
        {
            List<Alquiler> vehiculosRetrasados = new List<Alquiler>();
            for(int i = 0; i < alquileres.Count; i++)
            {
                if (alquileres[i].verificarRetraso())
                {
                    vehiculosRetrasados.Add(alquileres[i]);
                }
            }

            if(vehiculosRetrasados != null && vehiculosRetrasados.Count > 1)
            {
                //Fecha de devolución en orden descendente.
                vehiculosRetrasados.Sort(new OrdenamientoAlquiler(-1, true));
                //Matrícula en forma ascendente.
                vehiculosRetrasados.Sort(new OrdenamientoAlquiler(1, false));
            }

            return vehiculosRetrasados;

        }

        public Alquiler buscarAlquiler(Vehiculo veh)
        {
            Alquiler alq = null;
            int i = 0;
            while(i < alquileres.Count && alq == null)
            {
                if (alquileres[i].Vehiculo.Equals(veh) && !alquileres[i].disponibilidadVehiculo())
                {
                    alq = alquileres[i];
                }

                i++;
            }
            
            return alq;
        }

        public bool devolverVehiculo(Vehiculo veh)
        {
            Alquiler alq = buscarAlquiler(veh);
            bool devolucion = false;

            if (alq != null)
            {
                devolucion = alq.devolverVehiculo();
            }

            return devolucion;
        }
        
        public void registrarAlquiler(Cliente cliente, Vehiculo vehiculo, int horaInicio, int horaFin, DateTime fechaInicio, DateTime fechaFin)
        {
            //int devolucion;

            Alquiler alq = new Alquiler(cliente, vehiculo, horaInicio, horaFin, fechaInicio, fechaFin);
            
                        

            /*if (verificarHoras(horaInicio, horaFin) == 0)
            {
                if (verificarFechas(fechaInicio, fechaFin))
                {*/
                    alquileres.Add(alq);
                    /*devolucion = 0;
                }
                
            }
            else
            {
                devolucion = 1;
            }*/
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public List<string> buscarMatriculasXCliente(Cliente cli)
        {
            List<string> matriculas = new List<string>();
            for(int i = 0; i < alquileres.Count; i++)
            {
                if (alquileres[i].Cliente.Equals(cli))
                {
                    if (!alquileres[i].disponibilidadVehiculo())
                    {
                        matriculas.Add(alquileres[i].matriculaVehiculo());
                    }
                }
            }

            return matriculas;
        }

        #region controles

        public int verificarDatos(string tipo, string texto, decimal numerico, int entero, DateTime fecha1, DateTime fecha2)
        {
            int devolucion = 0;

            switch (tipo)
            {
                case "T":

                    if (texto.Length >= 1)
                    {
                        devolucion = 1;
                    }

                    break;
                case "N":

                    if (numerico >= 1)
                    {
                        devolucion = 2;
                    }

                    break;
                case "E":

                    if (entero >= 1)
                    {
                        devolucion = 3;
                    }

                    break;
                case "F":

                    if (fecha1 < fecha2 && fecha1 >= DateTime.Today)
                    {
                        devolucion = 4;
                    }

                    break;
            }

            return devolucion;
        }

        public int verificarFechas(DateTime fecha1, DateTime fecha2)
        {

            int devolucion = 1;

            if (fecha1 < fecha2 && fecha1 >= DateTime.Today && fecha2 >= DateTime.Today)
            {
                devolucion = 0;
            }

            return devolucion;

        }

        public int verificarHoras(int hora1, int hora2)
        {
            int devolucion = 2;

            if(hora1 >= 1 && hora1 <= 24 && hora1 < hora2)
            {
                devolucion = 0;
            }

            return devolucion;
        }

        public int verificarTextos(string texto)
        {
            int devolucion = 3;

            if (texto.Length >= 1)
            {
                devolucion = 0;
            }

            return devolucion;
        }

        public int verificarNumericos(int entero, decimal numerico)
        {
            int devolucion = 4;

            if (entero >= 1 && numerico >= 1)
            {
                devolucion = 0;
            }

            return devolucion;
        }

        #endregion

    }
}
