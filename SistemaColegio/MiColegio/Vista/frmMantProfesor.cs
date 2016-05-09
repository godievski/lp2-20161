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
    public partial class frmMantProfesor : Form
    {
        private GestorProfesor gestorProfe;
        private string nombreArchivo = null;
        private Profesor objProfesorSeleccionado = null;

        public frmMantProfesor()
        {
            InitializeComponent();
            this.gestorProfe = new GestorProfesor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog formAbrir = new OpenFileDialog();
            if (formAbrir.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                nombreArchivo = formAbrir.FileName;
                this.pictureBox1.Image = Image.FromFile(nombreArchivo);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            this.textBox1.Text = " ";
            this.textBox2.Text = " ";
            this.textBox3.Text = " ";
            this.textBox4.Text = " ";
            this.textBox5.Text = " ";
            this.textBox6.Text = " ";
            this.textBox7.Text = " ";
            this.textBox8.Text = " ";
            this.textBox9.Text = " ";
            this.textBox10.Text = "";
            this.textBox11.Text = "";
            this.textBox12.Text = "";
            this.textBox13.Text = "";
            this.textBox14.Text = "";
            //this.dateTimePicker1.Text = ?????
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Vienve de un nuevo !!!!
            Profesor objProfesor = new Profesor(this.textBox1.Text, this.textBox3.Text, this.dateTimePicker1.Text, this.textBox4.Text, this.textBox5.Text, this.nombreArchivo);
            if (this.textBox5.Text != "")
            {
                Experiencia objExperiencia = new Experiencia(this.textBox5.Text, int.Parse(this.textBox7.Text));
                objProfesor.AgregarExperiencia(objExperiencia);
            }                    
            if (textBox3.Enabled==true)
            {
                this.gestorProfe.AgregarProfesor(objProfesor);
                MessageBox.Show("Datos Registrados");
            }
            else
            {
                //Viene de un editar !!!!
                this.gestorProfe.ActualizarProfesor(objProfesor, this.textBox3.Text);
                MessageBox.Show("Datos Actualizados");
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBuscarProfe formBuscarProfe = new frmBuscarProfe(this.textBox15.Text);
            formBuscarProfe.ShowDialog();
            ///this.objProfesorSeleccionado = formBuscarProfe.dniBuscar;
        }

        private void SetProfesorSeleccionado(Profesor objProfesor)
        {
            this.objProfesorSeleccionado = objProfesor;
        }

    }
}
