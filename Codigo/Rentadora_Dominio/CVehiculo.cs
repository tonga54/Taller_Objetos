using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{

    //[Serializable]

    public class CVehiculo
    {
        private List<Vehiculo> vehiculos = new List<Vehiculo>();
        private static CVehiculo instancia = null;

        public static CVehiculo Instancia
        {
            get
            {
                if(CVehiculo.instancia == null)
                {
                    CVehiculo.instancia = new CVehiculo();
                }
                return CVehiculo.instancia;
            }
        }


        public List<Vehiculo> Vehiculos //BORRAR CUANDO SE TERMINE IMPLEMENTACION DE ALQUILER
        {
            get
            {
                return this.vehiculos;
            }
        }

        private CVehiculo()
        {

        }

        public Vehiculo comprobarDisponibilidad(string matricula)
        {
            int i = 0;
            Vehiculo retorno = null;

            while(i < vehiculos.Count && retorno == null)
            {
                if(vehiculos[i].Matricula == matricula && vehiculos[i].Disponible)
                {
                    retorno = vehiculos[i];
                }

                i++;
            }

            return retorno;
        }

        public List<Vehiculo> vehiculosDisponibles(string marca, string modelo)
        {
            int i = 0;
            List<Vehiculo> vehiculosAux = new List<Vehiculo>();

            while (i < vehiculos.Count)
            {
                if (vehiculos[i].TipoVehiculo.Marca == marca && vehiculos[i].TipoVehiculo.Modelo == modelo && vehiculos[i].Disponible)
                {
                    vehiculosAux.Add(vehiculos[i]);
                }
                i++;
            }

            return vehiculosAux;
        }

        public Vehiculo buscarVehiculoXMatricula(string matricula)
        {
            int i = 0;
            Vehiculo veh = null;
            while(i < vehiculos.Count && veh == null)
            {
                if(vehiculos[i].Matricula == matricula)
                {
                    veh = vehiculos[i];
                }
                i++;
            }

            return veh;
        }

        public void cargarVehiculos(string matricula, int anio, decimal kilometraje, List<string> fotos, TipoVehiculo tipoVehiculo)
        {
            Vehiculo veh = new Vehiculo(matricula,anio,kilometraje,fotos,tipoVehiculo);
            this.vehiculos.Add(veh);
        }

    }
}
