using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prySuppiConexionBD
{
    internal class clsCrud
    {
        clsConexion clsConexion = new clsConexion();
        SqlConnection connection = clsConexion.ObtenerConexion();

        public clsCrud() {
            
        }

        public void CreateContact()
        {
            string insertQuery = "INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaId) VALUES (@nombre, @descripcion, @precio, @stock, @categoriaId)";
            SqlCommand cmd = new SqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@nombre", "Mouse inalámbrico");
            cmd.Parameters.AddWithValue("@descripcion", "Mouse óptico USB");
            cmd.Parameters.AddWithValue("@precio", 150000);
            cmd.Parameters.AddWithValue("@stock", 20);
            cmd.Parameters.AddWithValue("@categoriaId", 1); // Tecnología
            cmd.ExecuteNonQuery();
            Console.WriteLine("✅ Producto agregado con éxito.");

        }

        public void ReactContact()
        {
            string selectQuery = "SELECT P.Nombre, P.Precio, P.Stock, C.Nombre AS Categoria FROM Productos P JOIN Categorias C ON P.CategoriaId = C.Id";
            SqlCommand cmd = new SqlCommand(selectQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Nombre"]} - ${reader["Precio"]} - Stock: {reader["Stock"]} - Categoría: {reader["Categoria"]}");
            }
            reader.Close();

        }
    }
}
