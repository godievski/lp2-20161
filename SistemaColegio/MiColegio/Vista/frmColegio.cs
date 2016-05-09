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
    public partial class frmColegio : Form
    {
        public frmColegio()
        {
            InitializeComponent();
            TreeNode nodo;
            nodo = this.treeView1.Nodes.Add("Colegios");
            this.treeView1.Nodes[0].Nodes.Add("MPJ");
            this.treeView1.Nodes[0].Nodes[0].Nodes.Add("Secundaria");
            this.treeView1.Nodes[0].Nodes.Add("HIGH");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {           
            //Aquí es cuando selecciono un nodo del arbol.
        }
    }
}
