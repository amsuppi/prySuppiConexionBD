using System;
using System.Collections;
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
        }

        private void frmContactos_Load(object sender, EventArgs e)
        {
            clsConexion.TraerCategorias(cmbCategoria);
            clsConexion.VerificarConexion();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private bool ValidationInfo()
        {
            bool isValid = true;
            string precio;
            if (txtPrecio.Text != null) precio = txtPrecio.Text;
            else
            {
                precio = null;
            }

            if (txtNombre.Text == null
                || precio == null
                || Convert.ToInt32(nudStock.Text) == 0
                || cmbCategoria.SelectedItem == null
                || rtxtDescripcion.Text == null)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }



            return isValid;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            string nombre = txtNombre.Text;
            string precio;
            if (txtPrecio.Text != null) 
            {
                precio = txtPrecio.Text; 
            }
            else {
                precio = null;
            }
            int stock = Convert.ToInt32(nudStock.Text);
            int categoria = cmbCategoria.SelectedIndex + 1;
            string descripcion = rtxtDescripcion.Text;


            if(ValidationInfo())
            {
                MessageBox.Show("❌ Error: Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK);
            } else
            {
                clsConexion.InertarProducto(nombre, Convert.ToDecimal(precio), stock, categoria, descripcion);

                txtNombre.Text = "";
                txtPrecio.Text = "";
                rtxtDescripcion.Text = "";
                cmbCategoria.SelectedIndex = -1;
                nudStock.Text = "";
            }

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frmBuscarProducto = new frmBuscarProducto();
            frmBuscarProducto.Show();
        }
    }
}
