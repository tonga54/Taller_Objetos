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
                vehiculosRetrasados.Sort(new OrdenamientoAlquiler());
            }

            return vehiculosRetrasados;

        }

        public Alquiler buscarAlquiler(Vehiculo veh)
        {
            Alquiler alq = null;
            if(veh != null)
            {
                int i = 0;
                while (i < alquileres.Count && alq == null)
                {
                    if (alquileres[i].Vehiculo.Equals(veh) && !alquileres[i].disponibilidadVehiculo())
                    {
                        alq = alquileres[i];
                    }

                    i++;
                }

            }

            return alq;
        }

        public string devolverVehiculo(Vehiculo veh)
        {
            Alquiler alq = buscarAlquiler(veh);
            string devolucion = "";

            if (alq != null)
            {
                if (alq.devolverVehiculo())
                {
                    devolucion = "CORRECTO: Vehiculo devuelto con exito";
                }else
                {
                    devolucion = "ERROR: Fallo al devolver el vehiculo";
                }
            }else
            {
                devolucion = "ERROR: Alquiler inexistente";
            }

            return devolucion;
        }
        
        public string registrarAlquiler(Cliente cliente, Vehiculo vehiculo, int horaInicio, int horaFin, DateTime fechaInicio, DateTime fechaFin)
        {
            string devolucion = "";
            if(cliente != null)
            {
                if (vehiculo != null)
                {
                    if (verificarHoras(horaInicio, horaFin))
                    {
                        if (verificarFechas(fechaInicio, fechaFin))
                        {
                            Alquiler alq = new Alquiler(cliente, vehiculo, horaInicio, horaFin, fechaInicio, fechaFin);
                            alquileres.Add(alq);
                            string costo = alq.calcularCosto().ToString();
                            devolucion = "CORRECTO: Alquiler agregado con exito<br>Costo: $" + costo;
                        }
                        else
                        {
                            devolucion = "ERROR: Fechas invalidas";
                        }
                    }
                    else
                    {
                        devolucion = "ERROR: Horas invalidas";
                    }
                }
                else
                {
                    devolucion = "ERROR: Vehiculo invalido";
                } 
            }
            else
            {
                devolucion = "ERROR: Cliente invalido";
            }

            return devolucion;
        }

        public CAlquiler(SerializationInfo info, StreamingContext context)
        {
            //usa cuando desearealiza
            this.alquileres = info.GetValue("alquileres", typeof(List<Alquiler>)) as List<Alquiler>;
            CAlquiler.instancia = this;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //usa cuando serializa
            info.AddValue("alquileres", this.alquileres, typeof(List<Alquiler>));

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

        public bool verificarFechas(DateTime fecha1, DateTime fecha2)
        {

            bool devolucion = false;

            if (fecha1 < fecha2 && fecha1 >= DateTime.Today && fecha2 > DateTime.Today)
            {
                devolucion = true;
            }

            return devolucion;

        }

        public bool verificarHoras(int hora1, int hora2)
        {
            bool devolucion = false;

            if(hora1 >= 1 && hora1 <= 24 && hora2 >= 1 && hora2 <= 24)
            {
                devolucion = true;
            }

            return devolucion;
        }

        public bool verificarTextos(string texto)
        {
            bool devolucion = false;

            if (texto.Length >= 1)
            {
                devolucion = true;
            }

            return devolucion;
        }

        public bool verificarNumericos(int entero, decimal numerico)
        {
            bool devolucion = false;

            if (entero >= 1 && numerico >= 1)
            {
                devolucion = true;
            }

            return devolucion;
        }

    }
}
