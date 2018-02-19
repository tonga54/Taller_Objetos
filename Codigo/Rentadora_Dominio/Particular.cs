using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class Particular : Cliente
    {
        private int documento;
        private int tipoDocumento;
        private string pais;
        private string nombre;
        private string apellido;

        public int Documento
        {
            get
            {
                return this.Documento;
            }
        }

        public int TipoDocumento
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

        public Particular(int telefono, int documento, int tipoDocumento, string pais, string nombre, string apellido) : base(telefono)
        {
            this.documento = documento;
            this.tipoDocumento = tipoDocumento;
            this.pais = pais;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public override bool verificarDocumento(int doc)
        {
            bool retorno = false;
            if(doc == this.documento)
            {
                retorno = true;
            }

            return retorno;
        }
    }
}
