using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class Particular : Cliente
    {
        private string documento;
        private string tipoDocumento;
        private string pais;
        private string nombre;
        private string apellido;

        public string Documento
        {
            get
            {
                return this.Documento;
            }
        }

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

        public Particular(int telefono, string documento, string tipoDocumento, string pais, string nombre, string apellido) : base(telefono)
        {
            this.documento = documento;
            this.tipoDocumento = tipoDocumento;
            this.pais = pais;
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}
