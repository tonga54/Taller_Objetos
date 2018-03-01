﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class Particular : Cliente
    {
        private int tipoDocumento;
        private int documento;
        private string pais;
        private string apellido;

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

        public int Documento
        {
            get
            {
                return this.documento;
            }
        }

        public Particular(int telefono, int documento, int tipoDocumento, string pais, string nombre, string apellido) : base(nombre,telefono)
        {
            this.documento = documento;
            this.tipoDocumento = tipoDocumento;
            this.pais = pais;
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
