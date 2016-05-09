using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MiColegio.Modelo;

namespace MiColegio.Controlador
{
    class GestorCurso
    { 
        private List<Curso> cursos;

        public GestorCurso()
        {
            this.cursos = new List<Curso>();
        }

        public void AgregarCurso(Curso curso)
        {
            this.cursos.Add(curso);
        }

        public Curso this [int index]
        {
            get { return this.cursos[index]; }
            set { this.cursos[index] = value; }
        }

        public int numCursos()
        {
            return this.cursos.Count;
        }

        public Curso BuscarCurso(string nombre)
        {
            for (int i = 0; i < this.cursos.Count; i++)
                if (nombre == this.cursos[i].Nombre) return this.cursos[i];
            return null;
        }

        public void CargarDatos()
        {
            FileStream Archivo = new FileStream("cursos.txt", FileMode.Open, FileAccess.Read);
            StreamReader Lector = new StreamReader(Archivo);
            while (true)
            {
                string linea = Lector.ReadLine();
                if (linea == null) break;
                string[] palabras = linea.Split(',');
                //Agregar el curso
                Nivel nivel = new Nivel(palabras[1]);
                this.AgregarCurso(new Curso(palabras[0], nivel));
            }
            Lector.Close();
            Archivo.Close();
        }
    }
}
