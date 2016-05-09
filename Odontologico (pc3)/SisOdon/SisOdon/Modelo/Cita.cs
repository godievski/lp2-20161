using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisOdon.Modelo
{
    [Serializable]
    public class Cita
    {
        private int dniOdo; /*DNI del Odontólogo*/
        private int dniPac; /*DNI del Paciente*/
        private string fecha; /*fecha de la cita, formato: DD/MM/AAAA*/
        private string hora; /*hora de la cita, formato: HH:MM*/
        private int duracion; /*expresado en minutos*/
        private int estado; /*1-> paciente asistió; 2->paciente no asistió; 3->odontólogo no asistió*/
        private static int DEFDUR = 30; /*duración por defecto*/

        public Cita(int dniOdo, int dniPac, string fecha, string hora)
        {
            this.dniOdo = dniOdo;
            this.dniPac = dniPac;
            this.fecha = fecha;
            this.hora = hora;
            this.duracion = DEFDUR;
            this.estado = 0; /*cita en espera o no atendida*/
        }
        public Cita(int dniOdo, int dniPac, string fecha, string hora, int duracion)
        {
            this.dniOdo = dniOdo;
            this.dniPac = dniPac;
            this.fecha = fecha;
            this.hora = hora;
            this.duracion = duracion;
            this.estado = 0; /*cita en espera o no atendida*/
        }

        public int DniOdontologo
        {
            set
            {
                dniOdo = value;
            }
            get
            {
                return dniOdo;
            }
        }
        public int DniPaciente
        {
            set
            {
                dniPac = value;
            }
            get
            {
                return dniPac;
            }
        }
        public string FechaCita
        {
            set
            {
                fecha = value;
            }
            get
            {
                return fecha;
            }
        }
        public string HoraCita
        {
            set
            {
                hora = value;
            }
            get
            {
                return hora;
            }
        }
        public int DuracionCita
        {
            set
            {
                duracion = value;
            }
            get
            {
                return duracion;
            }
        }
        public int Estado
        {
            set
            {
                estado = value;
            }
            get
            {
                return estado;
            }
        }
    }
}
