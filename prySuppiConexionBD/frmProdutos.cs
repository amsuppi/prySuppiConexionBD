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
    public partial class frmProductos : Form
    {

        clsConexion clsConexion = new clsConexion();
        public frmProductos()
        {
            InitializeComponent();
            cmbCategoria.Items.Add("Hogar");
            cmbCategoria.Items.Add("Tecnologia");
            cmbCategoria.Items.Add("Ropa");
        }

        private void frmContactos_Load(object sender, EventArgs e)
        {
            
            clsConexion.VerificarConexion();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            int stock = Convert.ToInt32(nudStock.Text);
            int categoria = cmbCategoria.SelectedIndex;
            string descripcion = rtxtDescripcion.Text;

            clsConexion.InertarProducto(nombre, precio, stock, categoria, descripcion);


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);

            clsConexion.EditarProducto(nombre, precio);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsConexion.EliminarProducto(txtNombre.Text);
        }
    }
}
