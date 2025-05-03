using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySuppiConexionBD
{
    internal class clsConexion
    {

        private string connectionString = "Server=localhost;Database=Comercio;Trusted_Connection=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
        public void VerificarConexion()
        {
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();

                    MessageBox.Show("✅ Conexión exitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        public void InertarProducto(string nombre, decimal precio, int stock, int categoria, string descripcion)
        {
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Productos (Nombre, Precio, Stock, CategoriaId, Descripcion) VALUES (@Nombre, @Precio, @Stock, @CategoriaId, @Descripcion)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Precio", precio);
                    command.Parameters.AddWithValue("@Stock", stock);
                    command.Parameters.AddWithValue("@CategoriaId", categoria);
                    command.Parameters.AddWithValue("@Descripcion", descripcion);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("✅ Producto insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error al insertar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void EditarProducto(string nombre, decimal precio)
        {
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE Productos SET Precio = @precio WHERE Nombre = @nombre";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@nombre", nombre);

                    command.ExecuteNonQuery();
                    MessageBox.Show("🔄 Producto actualizado.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error al editar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void EliminarProducto(string nombre)
        {
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Productos WHERE Nombre = @nombre";
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@nombre", nombre);

                    command.ExecuteNonQuery();
                    MessageBox.Show("🔄 Producto Eliminado.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error al eliminar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
