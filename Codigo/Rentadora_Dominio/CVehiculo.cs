using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class CVehiculo
    {
        private List<Vehiculo> vehiculos;
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

        private CVehiculo()
        {

        }

    }
}
