using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{

    //[Serializable]

    public class CTipoVehiculo
    {
        private List<TipoVehiculo> tiposVehiculos = new List<TipoVehiculo>();
        private static CTipoVehiculo instancia = null;

        public static CTipoVehiculo Instancia
        {
            get
            {
                if(CTipoVehiculo.instancia == null)
                {
                    CTipoVehiculo.instancia = new CTipoVehiculo();
                }
                return CTipoVehiculo.instancia;
            }
        }

        private CTipoVehiculo()
        {

        }

        public List<TipoVehiculo> TipoVehiculos
        {
            get
            {
                return this.tiposVehiculos;
            }
        }

        public List<string> listarMarcas()
        {
            List<string> devolucion = new List<string>();

            for(int i = 0;i < this.tiposVehiculos.Count; i++)
            {
                string marcaVehiculo = this.tiposVehiculos[i].ToString();
                bool repetido = verificarRepetido(devolucion, marcaVehiculo);
                if (!repetido)
                {
                    devolucion.Add(marcaVehiculo);
                }
            }

            return devolucion;
        }

        private bool verificarRepetido(List<string> lista,string valor)
        {
            int i = 0;
            bool bandera = false;
            while(i < lista.Count && !bandera)
            {
                if(lista[i] == valor)
                {
                    bandera = true;
                }
                i++;
            }
            return bandera;
        }

        public void cargarTipos(string marca, string modelo, decimal precio)
        {
            this.tiposVehiculos.Add(new TipoVehiculo(marca, modelo, precio));
        }

        public List<String> listarModelos(string marca)
        {
            List<String> devolucion = new List<string>();
            for(int i = 0; i < this.tiposVehiculos.Count; i++)
            {
                if(this.tiposVehiculos[i].Marca == marca)
                {
                    devolucion.Add(this.tiposVehiculos[i].Modelo);
                }
            }

            return devolucion;
        }

        public TipoVehiculo buscarTipoVehiculo(string marca, string modelo)
        {
            int i = 0;
            TipoVehiculo tipoVeh = null;
            while (i < tiposVehiculos.Count && tipoVeh == null)
            {
                if(tiposVehiculos[i].Marca == marca && tiposVehiculos[i].Modelo == modelo)
                {
                    tipoVeh = tiposVehiculos[i];
                }

                i++;
            }

            return tipoVeh;

        }

    }
}
