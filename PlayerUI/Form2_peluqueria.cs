using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PlayerUI
{
    public partial class Form2_peluqueria : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;

        // Definir la variable para almacenar el valor del TextBox
        private string variable = string.Empty;

        public Form2_peluqueria(Form1 form_)
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
            Form_.openChildForm(new Form4_Turnos_Añadir_Peluqueria(Form_));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si el clic fue en la columna de botón y si es una fila válida
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Obtener el valor de TurnoID desde la columna oculta (TurnoID está en la columna oculta)
                int turnoID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TurnoID"].Value);

                // Abrir el formulario con el TurnoID obtenido y pasar también Form1 como parámetro
                Form_.openChildForm(new Form2_Historias_Detalles(turnoID, Form_));
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
            string connectionString = "Server=DESKTOP-4QE2QT2;" +
                "Database=Veterinaria;" +
                "Trusted_Connection=True;";

            // Consulta SQL para obtener los turnos
            string query = "SELECT Turnos.ID AS TurnoID, Pacientes.Nombre, Turnos.Horario, Pacientes.Animal, Pacientes.Raza, Turnos.Fecha, Turnos.ID AS TurnoID, Pacientes.ID AS PacienteID " +
                           "FROM Pacientes " +
                           "INNER JOIN Turnos ON Pacientes.ID = Turnos.Paciente_id" +
                           " WHERE Turnos.Area_id = 1";

            // Verificar si la variable contiene algo
            if (!string.IsNullOrEmpty(variable))
            {
                query += " WHERE Pacientes.Nombre LIKE @nombre"; // Filtrar por el nombre del paciente
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

                // Añadir columnas visibles
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Animal", "Animal");
                dataGridView1.Columns.Add("Raza", "Raza");
                dataGridView1.Columns.Add("Fecha", "Fecha");
                dataGridView1.Columns.Add("Horario", "Hora");

                // Columna para el botón "Ver"
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Historia";
                buttonColumn.Text = "Ver";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);

                // Añadir columnas ocultas para almacenar los IDs
                dataGridView1.Columns.Add("TurnoID", "TurnoID");
                dataGridView1.Columns.Add("PacienteID", "PacienteID");
                dataGridView1.Columns["TurnoID"].Visible = false;
                dataGridView1.Columns["PacienteID"].Visible = false;

                // Mostrar los datos obtenidos
                foreach (DataRow row in turnosTable.Rows)
                {
                    string Nombre = row["Nombre"].ToString();
                    string Animal = row["Animal"].ToString();
                    string Raza = row["Raza"].ToString();
                    string Fecha = row["Fecha"].ToString();
                    string Horario = row["Horario"].ToString();
                    string TurnoID = row["TurnoID"].ToString(); // Obtener el valor de TurnoID
                    string PacienteID = row["PacienteID"].ToString();

                    // Agregar la fila con los datos y ocultos (IDs)
                    dataGridView1.Rows.Add(Nombre, Animal, Raza, Fecha, Horario, TurnoID, PacienteID);
                }

                // Ajustar el tamaño del DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.None;
            }
            catch (Exception ex)
            {
                // Manejo de errores
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
