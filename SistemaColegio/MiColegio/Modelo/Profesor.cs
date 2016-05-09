using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MiColegio.Modelo
{
    [Serializable]
    class Profesor
    {
        private string nombre;      
        private string dni;
        private string fechaNac;
        private string telefono; 
        private string direccion;
        private string nombreArchivo;
        private Image imagen;
        private List<Estudio> listaEstudios;
        private List<Experiencia> listaExperiencia;

        public Profesor(string nombre, string DNI, string fechaNac, string telefono, string direccion, string nombreArchivo)
        {
            this.direccion = direccion;
            this.dni = DNI;
            this.fechaNac = fechaNac;
            this.telefono = telefono;
            this.nombre = nombre;
            this.nombreArchivo = nombreArchivo;
            this.listaEstudios = new List<Estudio>();
            this.listaExperiencia = new List<Experiencia>();
        }

        public Profesor(string Nombre, string DNI, string FechaNac,string Direccion)
        {
            this.Nombre = Nombre;
            this.dni = DNI;
            this.fechaNac = FechaNac;
            this.direccion = Direccion;
            this.listaEstudios = new List<Estudio>();
            this.listaExperiencia = new List<Experiencia>();
        }

        public void AgregarEstudios(Estudio objEstudio)
        {
            this.listaEstudios.Add(objEstudio);
        }

        public void AgregarExperiencia(Experiencia objExperiencia)
        {
            this.listaExperiencia.Add(objExperiencia);
        }

        public string numDNI
        {
            set { this.dni = value; }
            get { return this.dni; }
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
    }
}
