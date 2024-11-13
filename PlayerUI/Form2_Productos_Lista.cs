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
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;

        public Form2_Productos_Lista(Form1 form)
        {
            InitializeComponent();
            Form_ = form;
            ObtenerProductos();
        }

        private void InitializeChildFormPanel()
        {
            panelChildForm = new Panel
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(panelChildForm);
        }
        private void ObtenerProductos()
        {
            string connectionString = "Server=DESKTOP-4QE2QT2;" +
                "Database=Veterinaria;" +
                "Trusted_Connection=True;";

            string query = "SELECT Productos.ID, Productos.nombre, Productos.precio_unitario, Productos.stock, " +
                           "Proveedores.Nombre AS Proveedor FROM Productos INNER JOIN Proveedores ON " +
                           "Proveedores.ID = Productos.Proveedor_id";

            DataTable productosTable = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(productosTable);
                    }
                }

                //Limpiar columnas y filas existentes
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Configuración del DataGridView
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.DefaultCellStyle.BackColor = Color.LightBlue;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToOrderColumns = false;

                //Columnas visibles
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("PrecioUnitario", "Precio Unitario");
                dataGridView1.Columns.Add("Stock", "Stock");
                dataGridView1.Columns.Add("Proveedor", "Proveedor");

                //Columna invisible
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    Visible = false
                };
                dataGridView1.Columns.Add(idColumn);

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Acciones",
                    Text = "Abrir Formulario",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(buttonColumn);

                foreach (DataRow row in productosTable.Rows)
                {
                    string Nombre = row["nombre"].ToString();
                    decimal PrecioUnitario = Convert.ToDecimal(row["precio_unitario"]);
                    int Stock = Convert.ToInt32(row["stock"]);
                    string Proveedor = row["Proveedor"].ToString();
                    int ID = Convert.ToInt32(row["ID"]);

                    dataGridView1.Rows.Add(Nombre, PrecioUnitario, Stock, Proveedor, ID);
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int idValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                Form_.openChildForm(new Form2_Productos(idValue));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form_.openChildForm(new Form7_Añadir_producto(Form_));
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form_.openChildForm(new Form6_Añadir_Proveedores(Form_));
        }
        private void Buscar_Click(object sender, EventArgs e)
        {
            string variable = textBox1.Text;
            ObtenerProductos(variable);
        }
        private void ObtenerProductos(string variable)
        {
            string connectionString = "Server=DESKTOP-4QE2QT2;" +
                 "Database=Veterinaria;" +
                 "Trusted_Connection=True;";

            string query = @"
        SELECT 
            Productos.ID, 
            Productos.nombre, 
            Productos.precio_unitario, 
            Productos.stock, 
            Proveedores.Nombre AS Proveedor 
        FROM 
            Productos 
        INNER JOIN 
            Proveedores 
            ON Proveedores.ID = Productos.Proveedor_id 
        WHERE 
            Productos.Nombre LIKE @nombre";

            DataTable productosTable = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", "%" + variable + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(productosTable);
                        }
                    }
                }

                //Limpiar columnas y filas existentes
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                //Configuración del DataGridView
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.DefaultCellStyle.BackColor = Color.LightBlue;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false; // No permitir agregar filas
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToOrderColumns = false;

                //Columnas visibles
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Precio_unitario", "Precio Unitario");
                dataGridView1.Columns.Add("Stock", "Stock");
                dataGridView1.Columns.Add("Proveedor", "Proveedor");

                //Columna invisible
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    Visible = false
                };
                dataGridView1.Columns.Add(idColumn);

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Acciones",
                    Text = "Abrir Formulario",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(buttonColumn);

                //Mostrar los datos obtenidos
                foreach (DataRow row in productosTable.Rows)
                {
                    string Nombre = row["nombre"].ToString();
                    decimal PrecioUnitario = Convert.ToDecimal(row["precio_unitario"]);
                    int Stock = Convert.ToInt32(row["stock"]);
                    string Proveedor = row["Proveedor"].ToString();
                    int ID = Convert.ToInt32(row["ID"]);

                    dataGridView1.Rows.Add(Nombre, PrecioUnitario, Stock, Proveedor, ID);
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Form2_Productos_Lista_Load(object sender, EventArgs e)
        {

        }

    }
}

