using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    abstract class Cliente
    {
        protected DateTime anio;
        protected int telefono;
        protected List<Alquiler> alquileres;
    }
}
