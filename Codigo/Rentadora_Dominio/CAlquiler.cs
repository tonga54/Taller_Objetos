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
                if (alquileres[i].Vehiculo.Equals(veh) && !alquileres[i].vehiculoDisponible())
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
            Alquiler alq = new Alquiler(cliente, vehiculo, horaInicio, horaFin, fechaInicio, fechaFin);
            alquileres.Add(alq);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

    }
}
