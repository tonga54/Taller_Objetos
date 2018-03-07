using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Rentadora_Dominio
{
    [Serializable]

    public class CCliente : ISerializable
    {
        private List<Cliente> clientes = new List<Cliente>();
        private static CCliente instancia = null;
        List<string> paises = new List<string>();

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
        public string agregarCliente(int telefono, string documento, string tipoDocumento, string pais, string nombre, string apellido)
        {
            string retorno = "";
            if (telefono.ToString().Length >= 8 && telefono.ToString().Length <= 15)
            {
                if (verificarDocumento(documento, tipoDocumento))
                {
                    if (buscarCliente(documento) == null)
                    {
                        if (pais != "")
                        {
                            if(nombre != "" && apellido != "")
                            {
                                Particular part = new Particular(telefono, documento, tipoDocumento, pais, nombre, apellido);
                                clientes.Add(part);
                                retorno = "CORRECTO: Cliente agregado con exito";
                            }
                            else
                            {
                                retorno = "ERROR: Nombre / Apellido vacio";
                            }
                        }
                        else
                        {
                            retorno = "ERROR: Pais invalido";
                        }
                    }
                    else
                    {
                        retorno = "ERROR: Ya existe un cliente con el documento ingresado";
                    }
                }
                else
                {
                    retorno = "ERROR: Documento / tipo documento invalido";
                }
            }
            else
            {
                retorno = "ERROR: Telefono invalido";
            }
      
            return retorno;
        }

        //Empresa
        public string agregarCliente(int telefono, long rut, string razonSocial, string nombre, int anio)
        {
            string retorno = "";
            if (telefono.ToString().Length >= 8 && telefono.ToString().Length <= 15)
            {
                if (rut.ToString().Length == 12)
                {
                    if (buscarCliente(rut.ToString()) == null)
                    {
                        if (razonSocial != "")
                        {
                            if (nombre != "")
                            {
                                if(anio > 0)
                                {
                                    Empresa emp = new Empresa(telefono, rut, razonSocial, nombre, anio);
                                    clientes.Add(emp);
                                    retorno = "CORRECTO: Cliente agregado con exito";
                                }
                                else
                                {
                                    retorno = "ERROR: Anio invalido";
                                }
                            }
                            else
                            {
                                retorno = "ERROR: Nombre / Apellido vacio";
                            }
                        }
                        else
                        {
                            retorno = "ERROR: Razon social vacia";
                        }
                    }
                    else
                    {
                        retorno = "ERROR: Ya existe un cliente con el docuento ingresado";
                    }
                }
                else
                {
                    retorno = "ERROR: Documento / tipo documento invalido";
                }
            }
            else
            {
                retorno = "ERROR: Telefono invalido";
            }

            return retorno;
        }

        public bool verificarCliente(string documento)
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

        public Cliente buscarCliente(string documento)
        {
            Cliente cl = null;
            if (documento != "")
            {
                int i = 0;
                while (i < clientes.Count && cl == null)
                {
                    if (clientes[i].verificarDocumento(documento))
                    {
                        cl = clientes[i];
                    }
                    i++;
                }
            }
            
            return cl;

        }

        public bool verificarDocumento(string documento,string tipoDocumento)
        {
            bool devolucion = false;
            if(documento != "" && tipoDocumento != "")
            {
                switch (tipoDocumento)
                {
                    case "ced":
                            if (documento.Length == 8)
                            {
                                devolucion = true;
                            }
                        break;
                    case "dni":
                            if (documento.Length == 8)
                            {
                                devolucion = true;
                            }
                        break;
                    case "pas":
                            if (documento.Length >= 6 && documento.Length <= 18)
                            {
                                devolucion = true;
                            }
                        break;
                    case "rut":
                            if(documento.Length == 12)
                            {
                                devolucion = true;
                            }
                        break;
                }

            }

            return devolucion;
        }

        public CCliente(SerializationInfo info, StreamingContext context)
        {
            //usa cuando desearealiza
            this.clientes = info.GetValue("clientes", typeof(List<Cliente>)) as List<Cliente>;
            CCliente.instancia = this;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //usa cuando serializa
            info.AddValue("clientes", this.clientes, typeof(List<Cliente>));

        }

    }
}
