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
    public partial class Form2_Productos_Lista : Form
    {

        private Form1 Form_;

        public Form2_Productos_Lista(Form1 form)
        {
            InitializeComponent();
            ObtenerProductos();
            Form_ = form;
        }

        private void ObtenerProductos()
        {
            // Cadena de conexión (ajusta según tu servidor, base de datos y autenticación)
            string connectionString = "Server=PC-F-06\\SQLEXPRESS;" +
                "Database=Cayetano;" +
                "Trusted_Connection=True;";

            // Consulta SQL para obtener los productos
            string query = "SELECT ID, nombre, precio_unitario, stock, proveedor_id FROM Productos";

            // Crear un DataTable para almacenar los resultados de la consulta
            DataTable productosTable = new DataTable();

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
                        // Crear un SqlDataAdapter para llenar el DataTable
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            // Llenar el DataTable con los resultados de la consulta
                            da.Fill(productosTable);
                        }
                    }
                }

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Estilo 
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.DefaultCellStyle.BackColor = Color.LightBlue;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToResizeColumns = false;

                dataGridView1.ReadOnly = true;          // Hace que todas las celdas sean solo lectura
                dataGridView1.AllowUserToAddRows = false;  // Desactiva la opción de agregar nuevas filas
                dataGridView1.AllowUserToDeleteRows = false; // Desactiva la opción de eliminar filas
                dataGridView1.AllowUserToOrderColumns = false;
                // Añadir columnas específicas
                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("PrecioUnitario", "Precio Unitario");
                dataGridView1.Columns.Add("Stock", "Stock");
                dataGridView1.Columns.Add("ProveedorID", "Proveedor ID");

                // Mostrar los datos obtenidos
                foreach (DataRow row in productosTable.Rows)
                {
                    int ID = Convert.ToInt32(row["ID"]);
                    string Nombre = row["nombre"].ToString();
                    decimal PrecioUnitario = Convert.ToDecimal(row["precio_unitario"]);
                    int Stock = Convert.ToInt32(row["stock"]);
                    int ProveedorID = Convert.ToInt32(row["proveedor_id"]);

                    // Agrega la fila con datos en las columnas
                    dataGridView1.Rows.Add(ID, Nombre, PrecioUnitario, Stock, ProveedorID);
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.None;
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que ocurra un problema con la conexión o consulta
                MessageBox.Show($"Error: {ex.Message}");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Productos_Lista_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_.openChildForm(new Form2_Productos());
        }
    }

}
