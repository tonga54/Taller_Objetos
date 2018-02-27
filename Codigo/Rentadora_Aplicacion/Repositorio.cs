using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rentadora_Dominio;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Rentadora_Aplicacion
{
    [Serializable]

   public class Repositorio
    {
        private CAlquiler alquiler;
        private CCliente cliente;
        private CTipoVehiculo tipoVehiculo;
        private CUsuario usuario;
        private CVehiculo vehiculo;
        private string rutaArchivo;

        public Repositorio(string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
            this.tipoVehiculo = CTipoVehiculo.Instancia;
            this.vehiculo = CVehiculo.Instancia;
            this.cliente = CCliente.Instancia;
            this.usuario = CUsuario.Instancia;
            this.alquiler = CAlquiler.Instancia;
        }

        public void Serializable()
        {
            FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            //this, todos los atributos de esta clase
            fs.Close();
        }

        public void Deserealizable()
        {
            FileStream fs = new FileStream(this.rutaArchivo, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Repositorio rep = bf.Deserialize(fs) as Repositorio;
            fs.Close();
        }


    }
}
