using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiColegio.Modelo;
using System.Xml;

namespace MiColegio.Controlador
{
    class GestorUsuario
    {
        private List<Usuario> listaUsuarios;

        public GestorUsuario()
        {
            this.listaUsuarios = new List<Usuario>();
        }

        public Usuario this[int indice]
        {
            get
            {
                return this.listaUsuarios[indice];
            }
            set
            {
                this.listaUsuarios[indice] = value;
            }
        }

        public void CargaDatosXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Usuarios.xml");
            XmlNodeList objUsuario = xDoc.GetElementsByTagName("Usuarios");
            XmlNodeList listaUser = ((XmlElement)objUsuario[0]).GetElementsByTagName("Usuario");
            int i = 0;
            foreach (XmlElement nodo in listaUser)
            {
                string nombre = nodo.GetElementsByTagName("nombre")[i].InnerText;
                string user = nodo.GetElementsByTagName("user")[i].InnerText;
                string password = nodo.GetElementsByTagName("contrasena")[i].InnerText;
                string apellido = nodo.GetElementsByTagName("apellido")[i].InnerText;
                Usuario objUser = new Usuario(user, password, nombre, apellido);
                this.listaUsuarios.Add(objUser);
            }
        }

        public int CantidadUsuarios()
        {
            return this.listaUsuarios.Count;
        }

        public int ValidarUsuario(string user, string password)
        {
            int es_Valido = 0;
            for (int i = 0; i < this.listaUsuarios.Count; i++)
            {
                if (this.listaUsuarios[i].User == user && this.listaUsuarios[i].Password == password)
                {
                    es_Valido = 1;
                    break;
                }
            }
            return es_Valido;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            this.listaUsuarios.Add(usuario);
        }

    }
}
