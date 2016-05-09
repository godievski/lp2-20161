
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiColegio.Modelo
{
    [Serializable]
    class Nivel
    {
        private List<Grado> grados;
        private string tipo;

        public Nivel(string tipo)
        {
            this.tipo = tipo;
            this.grados = new List<Grado>();
        }

        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public Grado this [int index]
        {
            get { return this.grados[index]; }
            set { this.grados[index] = value; }
        }

        public int NumGrados()
        {
            return this.grados.Count;
        }

        public void AgregarGrado(Grado grado)
        {
            this.grados.Add(grado);
        }
    }
}
