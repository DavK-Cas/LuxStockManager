using SistemaJoyeria.Model.DTO;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaJoyería.Model.DAO
{
    public class UpdateSuppliersDAO
    {
        // Método para obtener un proveedor por su ID
        public SupplierDTO GetSupplierByID(int idProveedor)
        {
            SupplierDTO supplier = null;
            try
            {
                using (SqlConnection connection = getConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Suppliers WHERE IDSupplier = @IDSupplier";
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@IDSupplier", idProveedor);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                supplier = new SupplierDTO
                                {
                                    IDSupplier = Convert.ToInt32(reader["IDSupplier"]),
                                    CompanyName = reader["CompanyName"].ToString(),
                                    ContactName = reader["ContactName"].ToString(),
                                    DayAdded = Convert.ToDateTime(reader["DayAdded"]),
                                    Phone = reader["Phone"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Direction = reader["Direction"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al obtener proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return supplier;
        }

        // Método para actualizar un proveedor
        public int UpdateSupplier(SupplierDTO supplier)
        {
            try
            {
                using (SqlConnection connection = getConnection())
                {
                    connection.Open();
                    string query = @"
                        UPDATE Suppliers
                        SET CompanyName = @CompanyName,
                            ContactName = @ContactName,
                            DayAdded = @DayAdded,
                            Phone = @Phone,
                            Email = @Email,
                            Direction = @Direction
                        WHERE IDSupplier = @IDSupplier";
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@IDSupplier", supplier.IDSupplier);
                        sqlCommand.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                        sqlCommand.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                        sqlCommand.Parameters.AddWithValue("@DayAdded", supplier.DayAdded);
                        sqlCommand.Parameters.AddWithValue("@Phone", supplier.Phone);
                        sqlCommand.Parameters.AddWithValue("@Email", supplier.Email);
                        sqlCommand.Parameters.AddWithValue("@Direction", supplier.Direction);
                        return sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al actualizar proveedor: {ex.Message}", "Error de actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Método para registrar un nuevo proveedor
        public int RegisterSupplier(SupplierDTO supplier)
        {
            try
            {
                using (SqlConnection connection = getConnection())
                {
                    connection.Open();
                    string queryInsert = @"
                        INSERT INTO Suppliers (CompanyName, ContactName, Phone, Email, Direction, DayAdded)
                        VALUES (@CompanyName, @ContactName, @Phone, @Email, @Direction, @DayAdded)";
                    using (SqlCommand cmdInsert = new SqlCommand(queryInsert, connection))
                    {
                        cmdInsert.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                        cmdInsert.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                        cmdInsert.Parameters.AddWithValue("@DayAdded", supplier.DayAdded);
                        cmdInsert.Parameters.AddWithValue("@Phone", supplier.Phone);
                        cmdInsert.Parameters.AddWithValue("@Email", supplier.Email);
                        cmdInsert.Parameters.AddWithValue("@Direction", supplier.Direction);
                        return cmdInsert.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo registrar proveedor, verifique su conexión a internet o que los servicios estén activos", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        // Método para eliminar un proveedor
        public int DeleteSupplier(int id)
        {
            try
            {
                using (SqlConnection connection = getConnection())
                {
                    connection.Open();
                    string queryDelete = "DELETE FROM Suppliers WHERE IDSupplier = @IDSupplier";
                    using (SqlCommand cmdDelete = new SqlCommand(queryDelete, connection))
                    {
                        cmdDelete.Parameters.AddWithValue("@IDSupplier", id);
                        return cmdDelete.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo eliminar proveedor", "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        // Método para obtener la conexión a la base de datos
        private SqlConnection getConnection()
        {
            // Asegúrate de tener una cadena de conexión válida en tu archivo de configuración.
            String test = "Server = SQL8005.site4now.net; Database = db_aacc95_dbluxst; User Id = db_aacc95_dbluxst_admin; Password = leoabarca091;";
            string connectionString = "Server = SQL8005.site4now.net; Database = db_aacc95_dbluxst; User Id = db_aacc95_dbluxst_admin; Password = leoabarca091;";
            return new SqlConnection(connectionString);
        }
    }
}