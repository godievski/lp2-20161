using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiColegio.Modelo
{
    [Serializable]
    class Horario
    {
        private string diaSemana;

        public string DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
        }

        private Nivel nivel;

        public string Nivel
        {
            get { return nivel.Tipo; }
        }

        private Grado grado;

        public int Grado
        {
            get { return grado.NumGrado; }
        }

        private Seccion seccion;

        public string Seccion
        {
            get { return seccion.IdSeccion; }
        }

        private Profesor docente;

        public string Docente
        {
            get { return docente.Nombre; }
        }

        private Curso curso;

        public string Curso
        {
            get { return curso.Nombre; }
        }

        private int numHora;

        public int NumHora
        {
            get { return numHora; }
            set { numHora = value; }
        }

        private string horaInicio;

        public string HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        private string horaFin;

        public string HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }
        
        public Horario(string diaSemana, Nivel nivel, Grado grado, Seccion seccion, Profesor docente, Curso curso,
            int numHora, string horaInicio, string horaFin)
        {
            this.diaSemana = diaSemana;
            this.nivel = nivel;
            this.grado = grado;
            this.seccion = seccion;
            this.docente = docente;
            this.curso = curso;
            this.numHora = numHora;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
        }

        public bool EsHorarioBuscado(string dia, string nivel, int grado, string seccion)
        {
            return (this.diaSemana == dia && this.nivel.Tipo == nivel && this.grado.NumGrado == grado
                    && this.seccion.IdSeccion == seccion);
        }

    }
}
