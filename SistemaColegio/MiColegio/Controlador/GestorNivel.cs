using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiColegio.Modelo;
using System.Xml;
namespace MiColegio.Controlador
{
    class GestorNivel
    {
        private List<Nivel> niveles;

        public GestorNivel()
        {
            niveles = new List<Nivel>();
        }

        public void AgregarNivel(Nivel nivel)
        {
            this.niveles.Add(nivel);
        }

        public Nivel this [int index]
        {
            get { return this.niveles[index]; }
            set { this.niveles[index] = value; }
        }

        public int Count
        {
            get { return this.niveles.Count; }
        }

        public Nivel BuscarNivel(string value)
        {
            for (int i = 0; i < niveles.Count; i++)
                if (niveles[i].Tipo == value) return niveles[i];
            return null;
        }

        public void CargarDatosXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("estructura.xml");
            XmlNodeList objEstructura = xDoc.GetElementsByTagName("Estructura");
            XmlNodeList listaNiveles = ((XmlElement)objEstructura[0]).GetElementsByTagName("Nivel");
            foreach (XmlElement nivelXML in listaNiveles)
            {
                string tipoNivel = nivelXML.GetElementsByTagName("TipoNivel")[0].InnerText;
                XmlNodeList objGrado = nivelXML.GetElementsByTagName("Grados");
                XmlNodeList listaGrados = ((XmlElement)objGrado[0]).GetElementsByTagName("Grado");
                Nivel nivel = new Nivel(tipoNivel);
                foreach (XmlElement gradoXML in listaGrados)
                {
                    int numGrado = int.Parse(gradoXML.GetElementsByTagName("NumeroGrado")[0].InnerText);
                    Grado grado = new Grado(numGrado);
                    XmlNodeList objSeccion = gradoXML.GetElementsByTagName("Secciones");
                    XmlNodeList listaSecciones = ((XmlElement)objSeccion[0]).GetElementsByTagName("Seccion");
                    foreach(XmlElement seccionXML in listaSecciones)
                    {
                        string idSeccion = seccionXML.GetElementsByTagName("IDSeccion")[0].InnerText;
                        int aula = int.Parse(seccionXML.GetElementsByTagName("Aula")[0].InnerText);
                        Seccion seccion = new Seccion(idSeccion, aula);
                        grado.AgregarSeccion(seccion);
                    }
                    nivel.AgregarGrado(grado);
                }
                this.niveles.Add(nivel);
            }
        }
        public Nivel BucarNivel(string tipoNivel)
        {
            return null;
        }
        
    }
}
