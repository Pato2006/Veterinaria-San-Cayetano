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
            string connectionString = "Server=DESKTOP-3CPGI44\\SQLEXPRESS;" +
                 "Database=Veterinaria;" +
                 "Trusted_Connection=True;";

            string query = "SELECT Productos.nombre, Productos.precio_unitario, Productos.stock, " +
                           "Proveedores.Nombre AS Proveedor FROM Productos INNER JOIN Proveedores ON " +
                           "Proveedores.ID = Productos.Proveedor_id WHERE Productos.ID = @idprod";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable pacienteData = new DataTable();

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@idprod", idprod);

                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(pacienteData);
                            }
                        }
                    }

                    if (pacienteData.Rows.Count > 0)
                    {
                        DataRow row = pacienteData.Rows[0];
                        string nombre = row["Nombre"].ToString();
                        string precio = row["Precio_unitario"].ToString();
                        string stock = row["Stock"].ToString();
                        string proveedor = row["Proveedor"].ToString();

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
                    MessageBox.Show($"Error: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
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
        private void Form2_Productos_Load(object sender, EventArgs e)
        {

        }
    }
}
