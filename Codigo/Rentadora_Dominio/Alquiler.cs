using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class Alquiler
    {
        private DateTime fechaIni;
        private DateTime fechaFin;
        private DateTime horaIni;
        private DateTime horaFin;
        private Vehiculo vehiculo;
        private decimal monto;

        public DateTime FechaFin
        {
            get
            {
                return this.fechaFin;
            }
        }

        public bool verificarRetraso()
        {
            DateTime fechaActual = DateTime.Now;
            bool devolucion = false;
            if (fechaActual > this.fechaFin)
            {
                devolucion = true;
            }
            return devolucion;

        }

        public string matriculaVehiculo()
        {
            return this.vehiculo.Matricula;
        }

    }
}
