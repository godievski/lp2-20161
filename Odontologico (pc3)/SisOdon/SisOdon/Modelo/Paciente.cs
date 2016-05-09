using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisOdon.Modelo
{
    [Serializable]
    public class Paciente : Persona
    {
        private Odontograma odont;
        public Paciente(int dni, string nombre, string apPat, string apMat, string fecha, string sexo, string dir)
            : base(dni, nombre, apPat, apMat, fecha, sexo, dir)
        {
            odont = new Odontograma();
        }
        public Odontograma Odont
        {
            set
            {
                odont = value;
            }
            get
            {
                return odont;
            }
        }
    }
}
