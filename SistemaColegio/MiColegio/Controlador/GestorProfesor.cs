using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiColegio.Modelo;
using System.Xml;
using System.Windows.Forms;

namespace MiColegio.Controlador
{
    class GestorProfesor
    {
        private List<Profesor> listaProfesores;

        public GestorProfesor()
        {
            this.listaProfesores = new List<Profesor>();
        }

        public Profesor this [int index]
        {
            get { return this.listaProfesores[index]; }
            set { this.listaProfesores[index] = value; }
        }

        public void AgregarProfesor(Profesor objProfesor)
        {
            this.listaProfesores.Add(objProfesor);
        }

        public void ActualizarProfesor(Profesor objProfesor, string DNI)
        {
            for (int i=0; i< this.listaProfesores.Count;i++)
            {
                if (this.listaProfesores[i].numDNI == DNI)
                    this.listaProfesores[i] = objProfesor;
            }
        }

        public List<Profesor> BuscarProfesor(string DNI)
        {
            List<Profesor> listaProfesEncontrados = new List<Profesor>();
            for (int i = 0; i < this.listaProfesores.Count; i++)
            {
                if (this.listaProfesores[i].numDNI == DNI)
                {
                    listaProfesEncontrados.Add(this.listaProfesores[i]);
                }
            }
            return listaProfesEncontrados;
        }
        public int Count
        {
            get
            {
                return this.listaProfesores.Count;
            }
        }
        public void CargarDatosXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("profesores.xml");
            
            XmlNodeList objProfesor = xDoc.GetElementsByTagName("Profesores");
            XmlNodeList listaProfesores = ((XmlElement)objProfesor[0]).GetElementsByTagName("Profesor");
            foreach (XmlElement nodo in listaProfesores)
            {
                string nombre = nodo.GetElementsByTagName("Nombre")[0].InnerText;
                string dni = nodo.GetElementsByTagName("DNI")[0].InnerText;
                string fechaNac = nodo.GetElementsByTagName("FechaNac")[0].InnerText;
                string dir = nodo.GetElementsByTagName("Direccion")[0].InnerText;
                Profesor objProf = new Profesor(nombre, dni, fechaNac, dir);
                this.listaProfesores.Add(objProf);
            }
        }
    }
}
