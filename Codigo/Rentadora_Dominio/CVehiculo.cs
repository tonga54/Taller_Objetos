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
            List<Vehiculo> vehiculosAux = new List<Vehiculo>();
            if(marca != "" && modelo != "")
            {
                int i = 0;
                while (i < vehiculos.Count)
                {
                    if (vehiculos[i].TipoVehiculo.Marca == marca && vehiculos[i].TipoVehiculo.Modelo == modelo && vehiculos[i].Disponible)
                    {
                        vehiculosAux.Add(vehiculos[i]);
                    }
                    i++;
                }
            }
            
            return vehiculosAux;
        }

        public Vehiculo buscarVehiculoXMatricula(string matricula)
        {
            Vehiculo veh = null;
            if (matricula != "")
            {
                int i = 0;
                
                while (i < vehiculos.Count && veh == null)
                {
                    if (vehiculos[i].Matricula == matricula)
                    {
                        veh = vehiculos[i];
                    }
                    i++;
                }
            }
            
            return veh;
        }

        public string cargarVehiculo(string matricula, int anio, decimal kilometraje, List<string> fotos, TipoVehiculo tipoVehiculo)
        {
            string devolucion = "";
            if (matricula != "" && anio > 1800 && anio <= DateTime.Now.Year && kilometraje >= 0 && fotos.Count > 0 && tipoVehiculo != null)
            {
                Vehiculo veh = new Vehiculo(matricula, anio, kilometraje, fotos, tipoVehiculo);
                vehiculos.Add(veh);
                devolucion = "CORRECTO: Vehiculo cargado con exito";
            }else
            {
                devolucion = "ERROR: Algun dato ha sido ingresado de manera incorrecta";
            }

            return devolucion;
        }



    }
}
