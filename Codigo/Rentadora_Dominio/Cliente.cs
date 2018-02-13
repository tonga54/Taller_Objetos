using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public abstract class Cliente
    {
        protected int anio;
        protected int telefono;
        protected List<Alquiler> alquileres = new List<Alquiler>();

        public int Anio
        {
            get
            {
                return this.anio;
            }
        }

        public int Telefono
        {
            get
            {
                return this.telefono;
            }
        }

        public Cliente(int telefono)
        {
            this.anio = DateTime.Now.Year;
            this.telefono = telefono;
        }
    }
}
