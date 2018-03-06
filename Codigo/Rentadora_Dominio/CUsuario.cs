using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{

    //[Serializable]

    public class CUsuario
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private static CUsuario instancia = null;

        public static CUsuario Instancia
        {
            get
            {
                if (CUsuario.instancia == null)
                {
                    CUsuario.instancia = new CUsuario();
                }
                return CUsuario.instancia;
            }
        }

        private CUsuario()
        {

        }

        public string registrarUsuario(string nombre,string contrasenia, string rol)
        {
            string dev = "";
            if (nombre != "" && contrasenia != "" && rol != "")
            {
                bool usr = buscarUsuario(nombre);
                if (!usr)
                {
                    usuarios.Add(new Usuario(nombre, contrasenia, rol));
                    dev = "CORRECTO: Usuario registrado correctamente";
                }
            }else
            {
                dev = "ERROR: Algun dato no corresponde";
            }
            
            return dev;
        }


        public bool buscarUsuario(string nombre)
        {
            int i = 0;
            bool usr = false;

            while (i < usuarios.Count && !usr)
            {
                if (usuarios[i].Nombre == nombre)
                {
                    usr = true;
                }
                i++;
            }

            return usr;
        }

        public Usuario buscarUsuario(string nombre, string contrasenia)
        {
            Usuario usr = null;
            if (nombre != "" && contrasenia != "")
            {
                int i = 0;

                while (i < usuarios.Count && usr == null)
                {
                    if (usuarios[i].Nombre == nombre && usuarios[i].Contrasenia == contrasenia)
                    {
                        usr = usuarios[i];
                    }
                    i++;
                }
            }
            
            return usr;

        }

        public string nombre(Usuario usu)
        {
            string dev = null;
            if(usu != null)
            {
                dev = usu.Nombre;
            }

            return dev;
        }

        public string rol(Usuario usu)
        {
            string dev = null;
            if (usu != null)
            {
                dev = usu.Rol;
            }

            return dev;

        }

    }
}
