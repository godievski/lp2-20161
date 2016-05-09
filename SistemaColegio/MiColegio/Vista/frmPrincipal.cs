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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void CerrarVentana(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios formUsuarios = new frmUsuarios();
            formUsuarios.MdiParent = this;
            formUsuarios.Show();
        }

        private void colegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmColegio formColegios = new frmColegio();
            formColegios.MdiParent = this;
            formColegios.Show();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantProfesor formMantProfesor = new frmMantProfesor();
            formMantProfesor.MdiParent = this;
            formMantProfesor.Show();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHorario formHorario = new frmHorario();
            formHorario.MdiParent = this;
            formHorario.Show();
        }
    }
}
