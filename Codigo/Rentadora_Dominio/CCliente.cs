using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class CCliente
    {
        private List<Cliente> clientes;
        private static CCliente instancia = null;

        public static CCliente Instancia
        {
            get
            {
                if(CCliente.instancia == null)
                {
                    CCliente.instancia = new CCliente();
                }
                return CCliente.instancia;
            }
        }

        private CCliente()
        {

        }
        
        //Particular
        public bool agregarCliente(int telefono, string documento, string tipoDocumento, string pais, string nombre, string apellido)
        {
            bool devolucion = false;
            Particular part = new Particular(telefono, documento, tipoDocumento, pais, nombre, apellido);
            if (part != null)
            {
                clientes.Add(part);
                devolucion = true;
            }
            return devolucion;
        }

        //Empresa
        public bool agregarCliente(int telefono, int rut, string razonSocial, string nombre)
        {
            bool devolucion = false;
            Empresa emp = new Empresa(telefono, rut, razonSocial, nombre);
            if(emp != null)
            {
                clientes.Add(emp);
                devolucion = true;
            }
            return devolucion;
        }

    }
}
