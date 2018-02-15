﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class Vehiculo
    {
        private string matricula;
        private DateTime anio;
        private decimal kilometraje;
        private List<string> fotos;
        private TipoVehiculo tipoVehiculo;
        private bool disponible;

        public string Matricula
        {
            get
            {
                return this.matricula;
            }
        }

        public bool Disponible
        {
            get
            {
                return this.disponible;
            }
            set
            {
                this.disponible = value;
            }
        }

        public decimal costoTipoVehiculo()
        {
            decimal costoDiario = this.tipoVehiculo.PrecioDiario;
            return costoDiario;
        }
    }
}
