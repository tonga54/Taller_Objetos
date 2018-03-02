using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    class OrdenamientoAlquiler : IComparer<Alquiler>
    {

        public OrdenamientoAlquiler()
        {

        }

        public int Compare(Alquiler alq1, Alquiler alq2)
        {
            int ordenamiento = alq1.FechaFin.CompareTo(alq2.FechaFin) * -1;
            if(ordenamiento == 0)
            {
                ordenamiento = alq1.matriculaVehiculo().CompareTo(alq2.matriculaVehiculo()) * 1;
            }
            return ordenamiento;
        }

    }
}
