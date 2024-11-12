using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PlayerUI
{
    public partial class Form3_pacientes : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;

        // Definir la variable para almacenar el valor del TextBox
        private string variable = string.Empty;

        public Form3_pacientes(Form1 form_)
        {
            InitializeComponent();
            InitializeChildFormPanel();
            hideSubMenu();
            ObtenerTurnos();
            Form_ = form_;
        }

        private void hideSubMenu()
        {
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void InitializeChildFormPanel()
        {
            panelChildForm = new Panel
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(panelChildForm);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Guardar el contenido del TextBox en la variable
            variable = textBox1.Text;

            ObtenerTurnos();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form_.openChildForm(new Form5_Añadir_Paciente());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // Acción al presionar el botón
                MessageBox.Show($"Botón presionado en la fila {e.RowIndex + 1}");
            }
        }

        // Evento TextChanged del TextBox1 para asignar el valor a la variable
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            variable = textBox1.Text;  // Asigna el valor del TextBox a la variable
        }

        private void ObtenerTurnos()
        {
            // Cadena de conexión (ajusta según tu servidor, base de datos y autenticación)
            string connectionString = "Server=DESKTOP-747DT10\\SQLEXPRESS;" +
                "Database=Veterinaria;" +
                "Trusted_Connection=True;";

            // Consulta SQL para obtener los turnos
            string query = "SELECT Animal, Raza, Nombre, Edad, Telefono FROM Pacientes";

            // Verificar si la variable contiene algo
            if (!string.IsNullOrEmpty(variable))
            {
                query += " WHERE Nombre LIKE @nombre"; // Filtrar por el nombre del paciente
            }

            // Crear un DataTable para almacenar los resultados de la consulta
            DataTable turnosTable = new DataTable();

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
                        // Si hay un filtro, añadir el parámetro
                        if (!string.IsNullOrEmpty(variable))
                        {
                            cmd.Parameters.AddWithValue("@nombre", "%" + variable + "%");
                        }

                        // Crear un SqlDataAdapter para llenar el DataTable
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            // Llenar el DataTable con los resultados de la consulta
                            da.Fill(turnosTable);
                        }
                    }
                }

                // Limpiar columnas y filas existentes
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Estilo del DataGridView
                dataGridView1.BackgroundColor = Color.White; // Color de fondo
                dataGridView1.DefaultCellStyle.BackColor = Color.LightBlue; // Color de celdas
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Color de texto
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen; // Color al seleccionar
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black; // Color de texto al seleccionar
                dataGridView1.RowHeadersVisible = false; // Ocultar las cabeceras de fila
                dataGridView1.AllowUserToResizeColumns = false; // Evitar el cambio de tamaño de columnas

                dataGridView1.ReadOnly = true;          // Hace que todas las celdas sean solo lectura
                dataGridView1.AllowUserToAddRows = false;  // Desactiva la opción de agregar nuevas filas
                dataGridView1.AllowUserToDeleteRows = false; // Desactiva la opción de eliminar filas
                dataGridView1.AllowUserToOrderColumns = false;

                // Añadir columnas
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Animal", "Animal");
                dataGridView1.Columns.Add("Raza", "Raza");
                dataGridView1.Columns.Add("Edad", "Edad");
                dataGridView1.Columns.Add("Telefono", "Telefono");

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Historia";
                buttonColumn.Text = "Ver";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);

                // Mostrar los datos obtenidos
                foreach (DataRow row in turnosTable.Rows)
                {
                    string Nombre = row["Nombre"].ToString();
                    string Animal = row["Animal"].ToString();
                    string Raza = row["Raza"].ToString();
                    string Edad = row["Edad"].ToString();
                    string Telefono = row["Telefono"].ToString();

                    // Agrega la fila con datos en las columnas
                    dataGridView1.Rows.Add(Nombre, Animal, Raza, Edad, Telefono);
                }

                // Ajustar el tamaño del DataGridView para evitar barras de desplazamiento
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.None; // Quitar barras de desplazamiento
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que ocurra un problema con la conexión o consulta
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
