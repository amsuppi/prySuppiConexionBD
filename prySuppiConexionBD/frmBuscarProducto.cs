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
    public partial class frmBuscarProducto : Form
    {
        public frmBuscarProducto()
        {
            InitializeComponent();
        }

        private void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
           
            clsConexion clsConexion = new clsConexion();
            clsConexion.BuscarProducto(dgvProductos);
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 4)
            {
                clsConexion clsConexion = new clsConexion();
                string nombre = dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
                string precio = dgvProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
                clsConexion.EditarProducto(nombre, Convert.ToDecimal(precio), dgvProductos);

            }
            else if (e.ColumnIndex == 5)
            {
                clsConexion clsConexion = new clsConexion();
                string nombre = dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
                string precio = dgvProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
                clsConexion.EliminarProducto(nombre, dgvProductos);
            }
        }

    }
}
