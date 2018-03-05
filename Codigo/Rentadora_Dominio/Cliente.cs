using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public abstract class Cliente
    {
        protected int telefono;
        protected string nombre;

        public int Telefono
        {
            get
            {
                return this.telefono;
            }
        }

        public Cliente(string nombre, int telefono)
        {
            this.nombre = nombre;
            this.telefono = telefono;
        }

        public abstract bool verificarDocumento(string doc);
        public abstract decimal calcularCosto(decimal costo);

    }
}
