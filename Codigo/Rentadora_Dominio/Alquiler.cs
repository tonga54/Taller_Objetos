﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{

    [Serializable]

    public class Alquiler
    {
        private DateTime fechaIni;
        private DateTime fechaFin;
        private int horaIni;
        private int horaFin;
        private Vehiculo vehiculo;
        private Cliente cliente;

        public Vehiculo Vehiculo
        {
            get
            {
                return this.vehiculo;
            }
        }

        public string FechaIniCorta
        {
            get
            {
                return this.fechaIni.ToShortDateString();
            }
        }

        public string FechaFinCorta
        {
            get
            {
                return this.fechaFin.ToShortDateString();
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

        public int HoraIni
        {
            get
            {
                return this.horaIni;
            }
        }

        public int HoraFin
        {
            get
            {
                return this.horaFin;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
        }

        public Decimal Monto
        {
            get
            {
                return this.calcularCosto();
            }
        }

        public Decimal MontoFaltante
        {
            get
            {
                return this.montoFaltante();
            }
        }

        public Alquiler(Cliente cliente, Vehiculo vehiculo, int horaInicio, int horaFin, DateTime fechaInicio, DateTime fechaFin)
        {
            this.cliente = cliente;
            this.vehiculo = vehiculo;
            this.horaIni = horaInicio;
            this.horaFin = horaFin;
            this.fechaIni = fechaInicio;
            this.fechaFin = fechaFin;
            this.vehiculo.Disponible = false;
        }

        public bool verificarRetraso()
        {
            DateTime fechaActual = DateTime.Now;
            bool devolucion = false;
            if (fechaActual > this.fechaFin && !Vehiculo.Disponible)
            {
                devolucion = true;
            }
            return devolucion;

        }

        public string matriculaVehiculo()
        {
            return this.vehiculo.Matricula;
        }

        public string modeloVehiculo()
        {
            return this.vehiculo.modelo();
        }

        public bool devolverVehiculo()
        {
            vehiculo.Disponible = true;
            return vehiculo.Disponible;
        }

        public decimal montoFaltante()
        {
            decimal costoFinal = 0;
            if(DateTime.Now > fechaFin)
            {
                TimeSpan cantidadDiasExtra = DateTime.Now.Subtract(fechaFin);
                decimal costoBase = cantidadDiasExtra.Days * Vehiculo.costoTipoVehiculo();
                costoFinal = cliente.calcularCosto(costoBase);
                return Math.Round(costoFinal);
            }

            return costoFinal;
            
        }

        public decimal calcularCosto()
        {
            TimeSpan cantidadDias = fechaFin.Subtract(fechaIni);
            decimal costoBase = cantidadDias.Days * Vehiculo.costoTipoVehiculo();
            decimal costoFinal = cliente.calcularCosto(costoBase);
            return Math.Round(costoFinal);
        }

        public bool disponibilidadVehiculo()
        {
            return this.vehiculo.Disponible;
        }

    }
}
