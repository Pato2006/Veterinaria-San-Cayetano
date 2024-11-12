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
        private Form1 Form_; // Referencia a Form1

        public Form2_Productos_Lista(Form1 form_)
        {

            InitializeComponent();
            Form_ = form_;
            ObtenerProductos(); // Llama a un método para obtener y mostrar productos (puedes personalizarlo)
        }

        private void InitializeChildFormPanel()
        {
            panelChildForm = new Panel
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(panelChildForm);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el clic fue en la columna de botones (última columna)
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Crear una instancia de Form2_Productos
                // Llamar a la función que abrirá el formulario dentro del Panel del formulario actual
                Form_.openChildForm(new Form2_Productos());
            }
        }

        // Método para abrir un formulario dentro del panel
        private void OpenChildForm(Form childForm)
        {
            // Cerrar cualquier formulario hijo activo
            if (activeForm != null)
            {
                activeForm.Close();
            }

            // Configurar el nuevo formulario como hijo y mostrarlo
            activeForm = childForm;
            childForm.TopLevel = false; // Indicar que es un formulario hijo
            childForm.FormBorderStyle = FormBorderStyle.None; // Sin bordes
            childForm.Dock = DockStyle.Fill; // Ocupa todo el espacio disponible
            panelChildForm.Controls.Add(childForm); // Agregar al panel
            panelChildForm.Tag = childForm; // Establecer el panel como contenedor
            childForm.BringToFront(); // Traer el formulario hijo al frente
            childForm.Show(); // Mostrar el formulario
            this.Close();
        }


        private void ObtenerProductos()
        {
            // Cadena de conexión (ajusta según tu servidor, base de datos y autenticación)
            string connectionString = "Server=DESKTOP-747DT10\\SQLEXPRESS;" +
                                      "Database=Veterinaria;" +
                                      "Trusted_Connection=True;";

            // Consulta SQL para obtener los productos
            string query = "SELECT Productos.nombre, Productos.precio_unitario, Productos.stock, " +
                           "Proveedores.Nombre AS Proveedor FROM Productos INNER JOIN Proveedores ON " +
                           "Proveedores.ID = Productos.Proveedor_id";

            // Crear un DataTable para almacenar los resultados de la consulta
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

                // Añadir columnas específicas
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("PrecioUnitario", "Precio Unitario");
                dataGridView1.Columns.Add("Stock", "Stock");
                dataGridView1.Columns.Add("Proveedor", "Proveedor");

                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.ScrollBars = ScrollBars.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            // Añadir columna de botón
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Acciones",
                    Text = "Abrir Formulario",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(buttonColumn);

                // Mostrar los datos obtenidos
                foreach (DataRow row in productosTable.Rows)
                {
                    string Nombre = row["nombre"].ToString();
                    decimal PrecioUnitario = Convert.ToDecimal(row["precio_unitario"]);
                    int Stock = Convert.ToInt32(row["stock"]);
                    string Proveedor = row["Proveedor"].ToString();
                    dataGridView1.Rows.Add(Nombre, PrecioUnitario, Stock, Proveedor);
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.None;
        }

        // Evento para manejar el clic en la columna de botones


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
            //fojarse en Form1.cs que ahi esta la guarangada
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_.openChildForm(new Form7_Añadir_producto());
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form_.openChildForm(new Form6_Añadir_Proveedores());
        }
    }

}
