using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySuppiConexionBD
{
    public partial class frmContactos : Form
    {
        public frmContactos()
        {
            InitializeComponent();
        }

        private void frmContactos_Load(object sender, EventArgs e)
        {
            clsConexion clsConexion = new clsConexion();
            clsConexion.VerificarConexion();
        }  
    }
}
