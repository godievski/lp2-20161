using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SisOdon.Modelo;

namespace SisOdon.Controlador
{
    public class GestorCitas
    {
        private List<Cita> citas;

        public GestorCitas()
        {
            this.citas = new List<Cita>();
        }
        public void RegistrarCita(int dniOdo, int dniPac, string fecha, string hora)
        {
            Cita nuevaCita = new Cita(dniOdo, dniPac, fecha, hora);
            citas.Add(nuevaCita);
        }
        public void ModificarCita(int dniPac, string fecha)
        {
            Cita cita = ObtenerCita(dniPac, fecha);
            if (cita != null)
            {
                Console.Write("Ingrese nuevo DNI del odontologo (Actual: {0}): ",cita.DniOdontologo);
                cita.DniOdontologo = int.Parse(Console.ReadLine());
                Console.Write("Ingrese nueva fecha de la cita (DD/MM/AAAA, Actual: {0}): ",cita.FechaCita);
                cita.FechaCita = Console.ReadLine();
                Console.Write("Ingrese nueva hora de la cita (HH:MM, Actual: {0}): ",cita.HoraCita);
                cita.HoraCita = Console.ReadLine();
                Console.Write("Ingrese nueva duracion de la cita (Actual: {0}): ", cita.DuracionCita);
                cita.DuracionCita = int.Parse(Console.ReadLine());
                Console.WriteLine("Modifique estado de la cita (Actual: {0}", cita.Estado);
                Console.Write("1-> paciente asistió; 2->paciente no asistió; 3->odontólogo no asistió: ");
                cita.Estado = int.Parse(Console.ReadLine());
            }
        }
        public Cita ObtenerCita(int dniPac, string fecha)
        {
            for (int i = 0; i < citas.Count; i++)
            {
                if (citas[i].DniPaciente == dniPac && citas[i].FechaCita == fecha) return citas[i];
            }
            return null;
        }
        public void ImprimirCitaPorFecha(string fecha)
        {
            for (int i = 0; i < citas.Count; i++)
            {
                if (citas[i].FechaCita == fecha)
                {
                    Console.WriteLine("Cita N° {0}", i + 1);
                    Console.WriteLine("Dni Odontologo: {0}", citas[i].DniOdontologo);
                    Console.WriteLine("Dni Paciente: {0}", citas[i].DniPaciente);
                    Console.WriteLine("Fecha: {0}", citas[i].FechaCita);
                    Console.WriteLine("Hora: {0}", citas[i].HoraCita);
                    Console.WriteLine("Duracion: {0}", citas[i].DuracionCita);
                    Console.WriteLine("Estado: {0}", citas[i].Estado);
                    Console.WriteLine("----------------------------------");
                }
            }
        }
    }
}
