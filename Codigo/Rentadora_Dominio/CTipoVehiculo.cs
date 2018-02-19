using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class CTipoVehiculo
    {
        private List<TipoVehiculo> tiposVehiculos;
        private static CTipoVehiculo instancia = null;

        public static CTipoVehiculo Instancia
        {
            get
            {
                if(CTipoVehiculo.instancia == null)
                {
                    CTipoVehiculo.instancia = new CTipoVehiculo();
                }
                return CTipoVehiculo.instancia;
            }
        }

        private CTipoVehiculo()
        {

        }

        public List<TipoVehiculo> mostrarTipoVehiculos()
        {
            if (tiposVehiculos.Count >= 1)
            {
                return tiposVehiculos;
            }

            return null;
        }

        public 

    }
}
