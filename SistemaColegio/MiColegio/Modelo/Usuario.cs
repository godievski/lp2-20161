using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiColegio.Modelo
{
    class Usuario
    {
        private string user;
        private string password;
        private string nombre;
        private string apellido;

        public Usuario(string user, string password, string nombre, string apellido)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.password = password;
            this.user = user;
        }

        public string User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

    }
}
