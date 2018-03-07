using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{

    [Serializable]

    public class Particular : Cliente
    {
        private string tipoDocumento;
        private string documento;
        private string pais;
        private string apellido;

        public string TipoDocumento
        {
            get
            {
                return this.tipoDocumento;
            }
        }

        public string Pais
        {
            get
            {
                return this.pais;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }

        public string Documento
        {
            get
            {
                return this.documento;
            }
        }

        public Particular(int telefono, string documento, string tipoDocumento, string pais, string nombre, string apellido) : base(nombre,telefono)
        {
            this.documento = documento;
            this.tipoDocumento = tipoDocumento;
            this.pais = pais;
            this.apellido = apellido;
        }

        public override bool verificarDocumento(string doc)
        {
            bool retorno = false;
            if(doc == this.documento)
            {
                retorno = true;
            }

            return retorno;
        }

        public decimal descuentoParticular(decimal costo)
        {
            int descuento = 4;
            return costo - (100 / (descuento * costo));
        }

        public override decimal calcularCosto(decimal costo)
        {
            decimal costoTotal = 0;

            if (this.pais == "URU")
            {
                costoTotal = descuentoParticular(costo); 
            }
            else
            {
                costoTotal = costo;
            }
            
            return costoTotal;
        }
    }
}
