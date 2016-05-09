using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiColegio.Vista
{
    public partial class frmBuscarProfe : Form
    {
        public string dniBuscar;
        
        public frmBuscarProfe(string dniBuscar)
        {
            InitializeComponent();
            this.dniBuscar = dniBuscar;
        }

        private void frmBuscarProfe_Load(object sender, EventArgs e)
        {
            //Cargo los profesores a la grilla, solo DNI y Nombre
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = this.dataGridView1.SelectedRows[0].Index;
            string dniSeleccionado = this.dataGridView1.Rows[filaSeleccionada].ToString();
            
        }

    }
}
