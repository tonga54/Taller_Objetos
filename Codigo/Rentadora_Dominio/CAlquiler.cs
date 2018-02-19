using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class CAlquiler
    {
        private List<Alquiler> alquileres;
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
            List<Alquiler> vehiculosRetrasados = null;
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

        public Alquiler buscarAlquiler(string matricula)
        {
            int i = 0;
            Alquiler alq = null;
            while (i < alquileres.Count && alq == null)
            {
                if(alquileres[i].matriculaVehiculo() == matricula)
                {
                    alq = alquileres[i];
                }
            }
            return alq;

        }

        public bool devolverVehiculo(string matricula)
        {
            Alquiler alq = buscarAlquiler(matricula);
            bool devolucion = false;
            if (alq != null)
            {
                devolucion = alq.devolverVehiculo();
            }
            return devolucion;
        }


        public List<Vehiculo> buscarVehiculosDisponibles(DateTime fechaIni, DateTime fechaFin, string marca, string modelo)
        {
            int i = 0;
            int j = 0;
            List<Vehiculo> vehiculosDisponibles = new List<Vehiculo>();
            List<Vehiculo> vehiculosAux = new List<Vehiculo>();

            vehiculosAux = CVehiculo.Instancia.buscarVehiculo(marca, modelo);

            while (i < alquileres.Count)
            {
                while(j < vehiculosAux.Count)
                {
                    if (alquileres[i].Vehiculo != vehiculosAux[j] && fechaIni < alquileres[i].FechaIni && fechaFin < alquileres[i].FechaFin)
                    {
                        vehiculosDisponibles.Add(vehiculosAux[j]);
                    }
                }
                j++;
                
            i++;
            }


            return vehiculosDisponibles;
        }

    }
}
