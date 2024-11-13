using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PlayerUI
{
    public partial class Form3_pacientes : Form
    {
        
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
            Form_.openChildForm(new Form5_Añadir_Paciente(Form_));
        }

        // Evento TextChanged del TextBox1 para asignar el valor a la variable
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            variable = textBox1.Text;  // Asigna el valor del TextBox a la variable
        }

        private void ObtenerTurnos()
        {
            // Cadena de conexión (ajusta según tu servidor, base de datos y autenticación)
            string connectionString = "Server=DESKTOP-6HQEU93\\SQLEXPRESS01;" +
                  "Database=Veterinaria;" +
                  "Trusted_Connection=True;";

            // Consulta SQL para obtener los turnos
            string query = "SELECT ID, Animal, Raza, Nombre, Edad, Telefono FROM Pacientes";

            if (!string.IsNullOrEmpty(variable))
            {
                query += " WHERE Nombre LIKE @nombre"; // Filtrar por el nombre del paciente
            }

            DataTable turnosTable = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Solo se agrega el parámetro si la variable no está vacía
                        if (!string.IsNullOrEmpty(variable))
                        {
                            cmd.Parameters.AddWithValue("@nombre", "%" + variable + "%");
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            // Limpiar DataTable antes de llenarlo
                            turnosTable.Clear();
                            da.Fill(turnosTable);
                        }
                    }
                }

                // Limpiar las columnas y filas del DataGridView antes de agregar nuevos datos
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToOrderColumns = false;


                // Agregar columnas visibles
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Animal", "Animal");
                dataGridView1.Columns.Add("Raza", "Raza");
                dataGridView1.Columns.Add("Edad", "Edad");
                dataGridView1.Columns.Add("Telefono", "Telefono");

                // Agregar columna oculta para ID
                var idColumn = new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    Visible = false // Ocultar la columna de ID
                };
                dataGridView1.Columns.Add(idColumn);

                // Agregar columna de botón
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Historia",
                    Text = "Ver",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(buttonColumn);

                // Agregar datos a las filas
                foreach (DataRow row in turnosTable.Rows)
                {
                    string Nombre = row["Nombre"].ToString();
                    string Animal = row["Animal"].ToString();
                    string Raza = row["Raza"].ToString();
                    string Edad = row["Edad"].ToString();
                    string Telefono = row["Telefono"].ToString();
                    string ID = row["ID"].ToString();

                    // Agregar fila solo si todos los campos son válidos
                    if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Animal) &&
                        !string.IsNullOrEmpty(Raza) && !string.IsNullOrEmpty(Edad) &&
                        !string.IsNullOrEmpty(Telefono) && !string.IsNullOrEmpty(ID))
                    {
                        dataGridView1.Rows.Add(Nombre, Animal, Raza, Edad, Telefono, ID);
                    }
                }

                // Asegurarse de que las columnas se ajusten automáticamente
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.None;
            }
            catch (Exception ex)
            {
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Obtener el valor de ID desde la columna oculta
                int idValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                // Abrir el formulario con el ID obtenido y pasar también Form1 como parámetro
                Form_.openChildForm(new Form2_Historias_Detalles(idValue, Form_));
            }
        }
    }
}
