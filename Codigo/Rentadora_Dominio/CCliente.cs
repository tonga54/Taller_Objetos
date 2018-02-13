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



        public void agregarCliente(Cliente cliente)
        {
            this.clientes.Add(cliente);
        }

    }
}
