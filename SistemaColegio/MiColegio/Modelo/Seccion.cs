using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiColegio.Modelo
{
    [Serializable]
    class Seccion
    {
        string idSeccion;
        int aula;

        public Seccion(string idSeccion, int aula)
        {
            this.idSeccion = idSeccion;
            this.aula = aula;
        }
        public string IdSeccion
        {
            get
            {
                return this.idSeccion;
            }
            set
            {
                this.idSeccion = value;
            }
        }
        public int Aula
        {
            get
            {
                return this.aula;
            }
            set
            {
                this.aula = value;  
            }
        }
    }
}
