using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PlayerUI
{
    public partial class Form2 : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;

        // Definir la variable para almacenar el valor del TextBox
        private string variable = string.Empty;

        public Form2(Form1 form_)
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
            Form_.openChildForm(new Form4_Turnos_Añadir());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0) // 5 es la columna del botón "Ver"
            {
                // Recuperar los valores de TurnoID y PacienteID de las columnas ocultas
                string turnoID = dataGridView1.Rows[e.RowIndex].Cells["TurnoID"].Value.ToString();
                string pacienteID = dataGridView1.Rows[e.RowIndex].Cells["PacienteID"].Value.ToString();

                // Mostrar los valores o abrir otro formulario con la información del turno y paciente
                MessageBox.Show($"Botón presionado para Turno ID: {turnoID} y Paciente ID: {pacienteID}");

                // Aquí puedes abrir otro formulario, pasando los IDs para mostrar más detalles
                // Ejemplo:
                // Form5_HistorialTurno historialForm = new Form5_HistorialTurno(turnoID, pacienteID);
                // historialForm.Show();
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
            string connectionString = "Server=PC-F-06\\SQLEXPRESS;" +
                "Database=Cayetano;" +
                "Trusted_Connection=True;";

            // Consulta SQL para obtener los turnos
            string query = "SELECT Pacientes.Nombre, Turnos.Horario, Pacientes.Animal, Pacientes.Raza, Turnos.Fecha, Turnos.ID AS TurnoID, Pacientes.ID AS PacienteID " +
                           "FROM Pacientes " +
                           "INNER JOIN Turnos ON Pacientes.ID = Turnos.Paciente_id";

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
                    string TurnoID = row["TurnoID"].ToString();
                    string PacienteID = row["PacienteID"].ToString();

                    // Agregar la fila con los datos    s y ocultos (IDs)
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
