using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    class OrdenamientoAlquiler : IComparer<Alquiler>
    {
        private int orden;
        private bool atributoAOrdenar;

        public OrdenamientoAlquiler(int orden, bool attr)
        {
            this.orden = orden;
            this.atributoAOrdenar = attr;
        }

        public int Compare(Alquiler alq1, Alquiler alq2)
        {
            if (this.atributoAOrdenar)
            {
                return alq1.FechaFin.CompareTo(alq2.FechaFin) * orden;
            }else
            {
                return alq1.matriculaVehiculo().CompareTo(alq2.matriculaVehiculo()) * orden;
            }

        }

    }
}
