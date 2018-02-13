using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class Empresa : Cliente
    {
        private int rut;
        private string razonSocial;
        private string nombre;

        public int Rut
        {
            get
            {
                return this.rut;
            }
        }

        public string RazonSocial
        {
            get
            {
                return this.razonSocial;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public Empresa(int telefono, int rut, string razonSocial, string nombre) : base(telefono)
        {
            this.rut = rut;
            this.razonSocial = razonSocial;
            this.nombre = nombre;
        }
    }
}
