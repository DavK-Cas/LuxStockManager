using SistemaJoyería.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaJoyería.Controller.ProductsController;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Sockets;

namespace SistemaJoyería.Model.DAO
{
    internal class ProductsViewDAO : ProductsViewDTO
    {
        SqlCommand command = new SqlCommand();
        //Mostrar datos en el data grid view
        public DataSet ShowDGV()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM vw_Products";
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                cmdSelect.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "vw_Products");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show($"Error al intentar mostrar datos, verifique su conexión a internet o acceso al servidor o base de datos estèn activos", "Error de ejecuciòn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }

        }
        //Llenar combo box
        public DataSet GetSuppliers()
        {
            try
            {

                command.Connection = getConnection();

                //Definir instruccion de lo que se quiere hacer
                string query = "Select IDSupplier, ContactName From Suppliers";

                //Creando un objeto de tipo comando donde recibe la instruccion y la conexión
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                cmdSelect.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Suppliers");
                return ds;

            }
            catch (Exception)
            {
                MessageBox.Show($"Error al obtener los proveedores, verifique su conexion a internet o que el acceso al servidor o base de datos esten activos", "Error de Ejecucion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        //Registrar productos
        public int registrerproducts()
        {
            try
            {
                //Establecemos una conexion
                command.Connection = getConnection();
                //Definir que accion se desea realizar   (un parametro para cada campo
                string queryInsert = "INSERT INTO Products Values (@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                SqlCommand cmdInsert = new SqlCommand(queryInsert, command.Connection);
                cmdInsert.Parameters.AddWithValue("Param1", NombreProducto1);
                cmdInsert.Parameters.AddWithValue("Param2", MaterialProducto1);
                cmdInsert.Parameters.AddWithValue("Param3", IDProveedor1);
                cmdInsert.Parameters.AddWithValue("Param4", DescripcionProducto1);
                cmdInsert.Parameters.AddWithValue("Param5", Stock1);
                cmdInsert.Parameters.AddWithValue("Param6", Price1);
                cmdInsert.Parameters.AddWithValue("Param7", Fecha1);
                //cmdInsert.Parameters.AddWithValue("Param8", IDProducto1);
                return cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message} No se puede registrar la iformacion del producto, verifique su conexion a internet o que los servicios esten activos", "Error de insercción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        //Eliminar Productos
        public int DeleteRecord()
        {
            try
            {
                //Establecemos una conexion
                command.Connection = getConnection();
                //Definir que accion se desea realizar   (un parametro para cada campo
                string queryInsert = "Delete Products Where IDProduct = @param1";
                SqlCommand cmdInsert = new SqlCommand(queryInsert, command.Connection);
                cmdInsert.Parameters.AddWithValue("param1", IDProducto1);
                return cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message} No se puede eliminar la iformacion del producto, verifique su conexion a internet o que los servicios esten activos", "Error de insercción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        //Acutalizar Productos
        public int UpdateProduct()
        {
            try
            {
                command.Connection = getConnection();
                string queryUpdate = "UPDATE Products SET ProductName = @param1, ProductMaterial = @param2, IDSupplier = @param3, ProductDescription = @param4, Stock = @param5, Price = @param6, Fecha = @param7  WHERE IDProduct = @param8";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, command.Connection);
                cmdUpdate.Parameters.AddWithValue("param1", NombreProducto1);
                cmdUpdate.Parameters.AddWithValue("param2", MaterialProducto1);
                cmdUpdate.Parameters.AddWithValue("param3", IDProveedor1);
                cmdUpdate.Parameters.AddWithValue("param4", DescripcionProducto1);
                cmdUpdate.Parameters.AddWithValue("param5", Stock1);
                cmdUpdate.Parameters.AddWithValue("param6", Price1);
                cmdUpdate.Parameters.AddWithValue("param7", Fecha1);
                cmdUpdate.Parameters.AddWithValue("param8", IDProducto1);

                return cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se logro actualizar la informacion del producto, verefique su conexión a internet o que los servicios estes activos", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet BuscarProducts(string valor)
        {
            try
            {
                command.Connection = getConnection();
                string query = $"SELECT * FROM vw_Products WHERE [Nombre del Producto] Like '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //cmd.Parameters.AddWithValue("@Valor", valor);
                cmd.ExecuteScalar();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "vw_Products");
                return dataSet;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
