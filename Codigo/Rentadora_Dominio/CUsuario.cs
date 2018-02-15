using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class CUsuario
    {
        private List<Usuario> usuarios;
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

        public bool registrarUsuario(string nombre,string contrasenia, int rol)
        {
            bool devolucion = false;
            bool usr = buscarUsuario(nombre);
            if (!usr)
            {
                usuarios.Add(new Usuario(nombre, contrasenia, rol));
                devolucion = true;
            }

            return devolucion;
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
            int i = 0;
            Usuario usr = null;

            while (i < usuarios.Count && usr == null)
            {
                if (usuarios[i].Nombre == nombre && usuarios[i].Contrasenia == contrasenia)
                {
                    usr = usuarios[i];
                }
                i++;
            }

            return usr;

        }

    }
}
