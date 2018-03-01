using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    //[Serializable]

    public class CCliente
    {
        private List<Cliente> clientes = new List<Cliente>();
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
        public bool agregarCliente(int telefono, int documento, int tipoDocumento, string pais, string nombre, string apellido)
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
        public bool agregarCliente(int telefono, int rut, string razonSocial, string nombre, int anio)
        {
            bool devolucion = false;
            Empresa emp = new Empresa(telefono, rut, razonSocial, nombre,anio);
            if(emp != null)
            {
                clientes.Add(emp);
                devolucion = true;
            }
            return devolucion;
        }

        public bool verificarCliente(int documento)
        {
            bool encontrado = false;
            foreach (Cliente cli in clientes)
            {
                if (cli.verificarDocumento(documento))
                {
                    encontrado = true;
                }
            }

            return encontrado;
        }

        public Cliente buscarCliente(int documento)
        {
            int i = 0;
            Cliente cl = null;
            while (i < clientes.Count && cl == null)
            {
                if(clientes[i].verificarDocumento(documento))
                {
                    cl = clientes[i];
                }
                i++;
            }
            return cl;

        }

    }
}
