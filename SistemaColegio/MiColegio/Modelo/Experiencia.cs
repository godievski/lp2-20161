using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiColegio.Modelo
{
    [Serializable]
    class Experiencia
    {
        private string institucion;
        private int anho;        
        public Experiencia(string institucion, int anho)
        {
            this.anho = anho;
            this.institucion = institucion;
        }
    }

    
}
