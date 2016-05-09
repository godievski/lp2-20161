using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisOdon.Vista
{
    public partial class Form1 : Form
    {
        public frmPersonas formPersonas;
        public Form1()
        {
            InitializeComponent();
            formPersonas = null;
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formPersonas == null)
            {
                formPersonas = new frmPersonas();
                formPersonas.MdiParent = this;
            }
            formPersonas.Show();
        }
    }
}
