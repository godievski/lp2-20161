using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiColegio.Controlador;
using MiColegio.Vista;

namespace MiColegio.Vista
{
    public partial class Form1 : Form
    {
        private GestorUsuario usuarios;
        public Form1()
        {
            InitializeComponent();
            this.usuarios = new GestorUsuario();
        }

        private void CargarVentana(object sender, EventArgs e)
        {
            this.usuarios.CargaDatosXML();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int es_Valido = this.usuarios.ValidarUsuario(textBox1.Text, textBox2.Text);
            if (es_Valido == 1)
            {
                MessageBox.Show("Bienvenido !!!!");
                frmPrincipal formPrincipal = new frmPrincipal();
                formPrincipal.Show();
                this.Hide();
            }                
            else
                MessageBox.Show("Usuario Inválido");
        }
    }
}
