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
using MiColegio.Modelo;

namespace MiColegio.Vista
{
    public partial class frmUsuarios : Form
    {
        private GestorUsuario usuarios;
        
        public frmUsuarios()
        {
            InitializeComponent();
            usuarios = new GestorUsuario();
        }

        private void CargarVentana(object sender, EventArgs e)
        {
            this.usuarios.CargaDatosXML();
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            this.dataGridView1.Rows.Clear();
            for (int i=0; i< this.usuarios.CantidadUsuarios(); i++)
            {
                string[] fila = new string[3];
                fila[0] = this.usuarios[i].User;
                fila[1] = this.usuarios[i].Nombre;
                fila[2] = this.usuarios[i].Apellido;
                this.dataGridView1.Rows.Add(fila);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void SeleccionarGrilla(object sender, DataGridViewCellEventArgs e)
        {
            int filaSeleccionada = this.dataGridView1.SelectedRows[0].Index;
            Usuario objUsuario = this.usuarios[filaSeleccionada];
            this.textBox3.Text = objUsuario.Nombre;
            this.textBox4.Text = objUsuario.Apellido;
            this.textBox5.Text = objUsuario.User;
            this.textBox6.Text = objUsuario.Password;
            this.tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = new Usuario(textBox5.Text, textBox6.Text, textBox3.Text, textBox4.Text);
            this.usuarios.AgregarUsuario(objUsuario);
            CargarGrilla();
        }


    }
}
