using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form2_Productos : Form
    {
        private int idprod;
        public Form2_Productos(int ID)
        {
        idprod = ID;
        InitializeComponent();
        BuscarProd(idprod);
        }
        private void BuscarProd(int idprod)
        {
            // Definir la cadena de conexión
            string connectionString = "Server=DESKTOP-747DT10\\SQLEXPRESS;" +
                                      "Database=Veterinaria;" +
                                      "Trusted_Connection=True;";

            // Crear la consulta SQL
            string query = "SELECT Productos.nombre, Productos.precio_unitario, Productos.stock, " +
                           "Proveedores.Nombre AS Proveedor FROM Productos INNER JOIN Proveedores ON " +
                           "Proveedores.ID = Productos.Proveedor_id WHERE Productos.ID = @idprod";

            // Usar SqlConnection y SqlCommand para ejecutar la consulta
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable pacienteData = new DataTable();

                try
                {
                    // Crear una conexión usando SqlConnection
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Abrir la conexión
                        con.Open();

                        // Crear un SqlCommand para ejecutar la consulta
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Agregar el parámetro para la consulta
                            cmd.Parameters.AddWithValue("@idprod", idprod); // Cambié @id por @idprod

                            // Crear un SqlDataAdapter para llenar el DataTable
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                // Llenar el DataTable con los resultados de la consulta
                                da.Fill(pacienteData);
                            }
                        }
                    }

                    // Verificar si se ha encontrado un paciente
                    if (pacienteData.Rows.Count > 0)
                    {
                        // Acceder a los datos del paciente (si se encuentra en la base de datos)
                        DataRow row = pacienteData.Rows[0];
                        string nombre = row["Nombre"].ToString();
                        string precio = row["Precio_unitario"].ToString();
                        string stock = row["Stock"].ToString();
                        string proveedor = row["Proveedor"].ToString();

                        // Mostrar los datos del paciente en un mensaje (puedes actualizar controles de UI si prefieres)
                        label1.Text = "Nombre: " + nombre;
                        label2.Text = "Vendedor: " + proveedor;
                        label3.Text = "Stock: " + stock;
                        label4.Text = "Precio: $" + precio;
                    }
                    else
                    {
                        MessageBox.Show($"No se encontraron productos con el ID: {idprod}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores en caso de que ocurra un problema con la conexión o consulta
                    MessageBox.Show($"Error: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
