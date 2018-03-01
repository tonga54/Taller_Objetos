using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentadora_Dominio
{
    public class Usuario
    {
        private string nombre;
        private string contrasenia;
        private string rol;

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public string Contrasenia
        {
            get
            {
                return this.contrasenia;
            }
        }

        public string Rol
        {
            get
            {
                return this.rol;
            }
        }

        public Usuario(string nombre, string contrasenia, string rol)
        {
            this.nombre = nombre;
            this.contrasenia = contrasenia;
            this.rol = rol;
        }

    }
}
