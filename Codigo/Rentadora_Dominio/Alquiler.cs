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

        public Vehiculo Vehiculo
        {
            get
            {
                return this.Vehiculo;
            }
        }

        public DateTime FechaIni
        {
            get
            {
                return this.fechaIni;
            }
        }

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

        public bool devolverVehiculo()
        {
            vehiculo.Disponible = true;
            return vehiculo.Disponible;
        }

        public decimal montoFaltante()
        {
            decimal costoTipoVehiculo = this.vehiculo.costoTipoVehiculo();
            int cantidadDiasExtra = DateTime.Now.Day - this.fechaFin.Day;
            decimal costoBase = costoTipoVehiculo * cantidadDiasExtra;
            //decimal costo = costoBase * CALCULO DE COSTO POLIMORFICO;
            return costoBase;
        }

        public decimal calcularCosto()
        {
            decimal costoTipoVehiculo = this.vehiculo.costoTipoVehiculo();
            int cantidadDias = this.fechaFin.Day - this.fechaIni.Day;
            decimal costoBase = costoTipoVehiculo * cantidadDias;
            //decimal costo = costoBase * CALCULO DE COSTO POLIMORFICO;
            this.monto = costoBase;
            return costoBase;
        }

    }
}
