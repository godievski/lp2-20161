using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiColegio.Modelo;

namespace MiColegio.Controlador
{
    [Serializable]
    class GestorHorario
    {
        private List<Horario> horarios;

        public static int maxClases = 7;
        private static int horaInicioClases = 8*60;
        private static int duracion = 40;

        public GestorHorario()
        {
            horarios = new List<Horario>();
        }

        public static string calcularHoraInicio(int i)
        {
            int inicio = horaInicioClases + i*duracion;
            return ("" + inicio / 60 + ":" + inicio % 60);
        }

        public static string calcularHoraFin(int i)
        {
            int inicio = horaInicioClases + (i+1) * duracion;
            return ("" + inicio / 60 + ":" + inicio % 60);
        }

        public int ObtenerNumHorarios(string dia, string nivel, int grado, string seccion)
        {
            int contador = 0;
            for (int i = 0; i < this.horarios.Count; i++)
                if (this.horarios[i].EsHorarioBuscado(dia, nivel, grado, seccion)) contador++;
            return contador;
        }

        public void AnadirHorario(Horario horario)
        {
            horarios.Add(horario);
        }

        public List<Horario> ObtenerHorarios(string dia, string nivel, int grado, string seccion)
        {
            List<Horario> horarios = new List<Horario>();
            for (int i = 0; i < this.horarios.Count; i++)
                if (this.horarios[i].EsHorarioBuscado(dia, nivel, grado, seccion)) horarios.Add(this.horarios[i]);
            return horarios;
        }
    }
}
