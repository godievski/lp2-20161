using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiColegio.Modelo
{
    [Serializable]
    class Curso
    {
        private string nombre;
        private Nivel nivel;
       
        public Curso(string nombre)
        {
            this.nombre = nombre;
        }

        public Curso(string nombre, Nivel nivel)
        {
            this.nombre = nombre;
            this.nivel = nivel;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Nivel Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

    }
}
