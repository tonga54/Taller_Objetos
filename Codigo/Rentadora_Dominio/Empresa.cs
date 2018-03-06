using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class Empresa : Cliente
    {
        private string razonSocial;
        private long rut;
        private int anio;

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

        public long Documento
        {
            get
            {
                return this.rut;
            }
        }

        public Empresa(int telefono, long rut, string razonSocial, string nombre, int anio) : base(nombre,telefono)
        {
            this.rut = rut;
            this.razonSocial = razonSocial;
            this.anio = anio;
        }

        public override bool verificarDocumento(string doc)
        {
            long rut;
            long.TryParse(doc, out rut);
            bool retorno = false;
            if (rut == this.rut)
            {
                retorno = true;
            }

            return retorno;
        }

        public override decimal calcularCosto(decimal costo)
        {
            int descuento = 2;
            decimal costoTotal = 0;

            int antiguedad = DateTime.Now.Year - this.anio;
            decimal descuentoTotal = 0;
            if (antiguedad > 0)
            {
                descuentoTotal = antiguedad * descuento;
                if (descuentoTotal > 20)
                {
                    descuentoTotal = 20;
                }
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
