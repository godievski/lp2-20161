using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiColegio.Modelo
{
    [Serializable]
    class Grado
    {
        private int numGrado;
        private List<Seccion> secciones;

        public Grado(int numGrado)
        {
            this.numGrado = numGrado;
            this.secciones = new List<Seccion>();
        }

        public int NumGrado
        {
            get { return this.numGrado; }
            set { this.numGrado = value; }
        }

        public Seccion this [int index]
        {
            get { return this.secciones[index]; }
            set { this.secciones[index] = value; }
        }

        public int NumSecciones() {
            return this.secciones.Count;
        }

        public void AgregarSeccion(Seccion seccion)
        {
            this.secciones.Add(seccion);
        }

    }
}
