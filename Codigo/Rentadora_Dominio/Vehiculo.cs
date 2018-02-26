using System;
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

        public decimal Kilometraje
        {
            get
            {
                return this.kilometraje;
            }
        }

        public DateTime Anio
        {
            get
            {
                return this.anio;
            }
        }

        public string Fotos
        {
            get
            {
                string devolucion = null;
                for (int i = 0; i < this.fotos.Count; i++)
                {
                    devolucion += "<img src='" + this.fotos[i] + "'>";
                }
                return devolucion;
            }
        }

        public TipoVehiculo TipoVehiculo
        {
            get
            {
                return this.tipoVehiculo;
            }
        }

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

        public Vehiculo(string matricula,DateTime anio, decimal kilometraje,List<string> fotos, TipoVehiculo tipoVehiculo)
        {
            this.matricula = matricula;
            this.anio = anio;
            this.kilometraje = kilometraje;
            this.fotos = fotos;
            this.tipoVehiculo = tipoVehiculo;
        }

        public string modelo()
        {
            return this.TipoVehiculo.Modelo;
        }

        public decimal costoTipoVehiculo()
        {
            decimal costoDiario = this.tipoVehiculo.PrecioDiario;
            return costoDiario;
        }
    }
}
