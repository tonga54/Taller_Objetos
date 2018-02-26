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

        public override bool verificarDocumento(int doc)
        {
            bool retorno = false;
            if (doc == this.rut)
            {
                retorno = true;
            }

            return retorno;
        }

        public override decimal calcularCosto(decimal costo)
        {
            int descuento = 2;
            decimal costoTotal = 0;
            
            int antiguedad = DateTime.Now.Year - this.Anio;
            decimal descuentoTotal = antiguedad * descuento;

            if (descuentoTotal > 20)
            {
                descuentoTotal = 20;
            }

            if(antiguedad > 0)
            {
                costoTotal = costo - (100 / (descuentoTotal * costo));
            }
            else
            {
                costoTotal = costo;
            }

            return costoTotal;
        }

    }
}
