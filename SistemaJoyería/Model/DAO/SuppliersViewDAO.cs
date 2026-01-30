using SistemaJoyeria.Model.DTO;
using SistemaJoyería.View.Suppliers;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaJoyeria.DAO
{
    public class SupplierDAO : SupplierDTO
    {
        // Objeto SqlCommand para ejecutar comandos SQL
        private SqlCommand command = new SqlCommand();

        // Método para obtener todos los proveedores
        public void GetData(FrmSuppliers vistaPasada)
        {
            try
            {
                // Establece la conexión
                command.Connection = getConnection();

                // Query SQL para seleccionar todos los proveedores
                string query = "SELECT * FROM Suppliers";

                using (SqlCommand cmdGet = new SqlCommand(query, command.Connection))
                {
                    // Ejecuta la query y obtiene un SqlDataReader
                    SqlDataReader reader = cmdGet.ExecuteReader();

                    // Limpia la lista de proveedores en la vista
                    vistaPasada.listSuppliers.Items.Clear();

                    // Lee cada fila del resultado
                    while (reader.Read())
                    {
                        // Crea un nuevo item para la lista con el ID del proveedor
                        ListViewItem item = new ListViewItem(reader["IDSupplier"].ToString());

                        // Agrega los demás datos del proveedor como subitems
                        item.SubItems.Add(reader["CompanyName"].ToString());
                        item.SubItems.Add(reader["ContactName"].ToString());
                        item.SubItems.Add(reader["DayAdded"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Direction"].ToString());

                        // Agrega el item a la lista en la vista
                        vistaPasada.listSuppliers.Items.Add(item);
                    }
                    // Cierra el reader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: muestra el mensaje de error
                MessageBox.Show(ex.ToString());
            }
        }

        // Método para buscar proveedores por nombre de empresa o nombre de contacto
        public void SearchData(FrmSuppliers vistaPasada)
        {
            try
            {
                // Establece la conexión
                command.Connection = getConnection();

                // Query SQL para buscar por nombre de empresa o nombre de contacto
                string query = "SELECT * FROM Suppliers WHERE CompanyName LIKE @searchingFor OR ContactName LIKE @searchingFor";

                using (SqlCommand cmdGet = new SqlCommand(query, command.Connection))
                {
                    // Agrega el parámetro de búsqueda
                    cmdGet.Parameters.AddWithValue("@searchingFor", "%" + vistaPasada.txtSearch.Text + "%");

                    // Ejecuta la query y obtiene un SqlDataReader
                    SqlDataReader reader = cmdGet.ExecuteReader();

                    // Limpia la lista de proveedores en la vista
                    vistaPasada.listSuppliers.Items.Clear();

                    // Lee cada fila del resultado
                    while (reader.Read())
                    {
                        // Crea un nuevo item para la lista con el ID del proveedor
                        ListViewItem item = new ListViewItem(reader["IDSupplier"].ToString());

                        // Agrega los demás datos del proveedor como subitems
                        item.SubItems.Add(reader["CompanyName"].ToString());
                        item.SubItems.Add(reader["ContactName"].ToString());
                        item.SubItems.Add(reader["DayAdded"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Direction"].ToString());

                        // Agrega el item a la lista en la vista
                        vistaPasada.listSuppliers.Items.Add(item);
                    }
                    // Cierra el reader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: muestra el mensaje de error
                MessageBox.Show(ex.ToString());
            }
        }

        // Método para eliminar un proveedor
        public void Delete(string idMala)
        {
            try
            {
                // Establece la conexión
                command.Connection = getConnection();

                // Query SQL para eliminar un proveedor
                string query = "DELETE FROM Suppliers WHERE IDSupplier = @idMala";

                using (SqlCommand cmdDelete = new SqlCommand(query, command.Connection))
                {
                    // Agrega el parámetro del ID del proveedor a eliminar
                    cmdDelete.Parameters.AddWithValue("@idMala", idMala);

                    // Ejecuta el comando
                    cmdDelete.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: muestra el mensaje de error
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
