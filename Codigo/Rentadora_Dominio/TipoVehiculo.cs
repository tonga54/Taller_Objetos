using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class TipoVehiculo
    {
        private string marca;
        private string modelo;
        private decimal precioDiario;

        public decimal PrecioDiario
        {
            get
            {
                return this.precioDiario;
            }
        }

        public string Marca
        {
            get
            {
                return this.marca;
            }
        }

        public string Modelo
        {
            get
            {
                return this.modelo;
            }
        }

        public TipoVehiculo(string marca, string modelo, decimal precioDiario)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.precioDiario = precioDiario;
        }

        public override string ToString()
        {
            return this.marca;
        }
    }
}
