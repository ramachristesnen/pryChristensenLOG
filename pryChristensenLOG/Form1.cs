using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryChristensenLOG
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsAccesoBD objAccesoBD = new clsAccesoBD();

            objAccesoBD.ConectarBaseDatos();

            tsslBase.Text = objAccesoBD.EstadoConexion;
        }

        private void statusStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            clsAccesoBD objAccesoBD = new clsAccesoBD();
            objAccesoBD.TraerDatos(dgvRegistros);
            lblDatos.Text = objAccesoBD.DatosExtraidos;
        }
    }
}
