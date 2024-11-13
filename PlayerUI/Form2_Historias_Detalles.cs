using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form2_Historias_Detalles : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_; // Para almacenar la referencia de Form1
        private string variable = string.Empty; // Para almacenar el filtro de búsqueda
        private int pacienteId; // Para almacenar el ID del paciente
        private TextBox textBox1; // TextBox para filtrar pacientes

        // Constructor modificado para aceptar Form1 y el ID del paciente
        public Form2_Historias_Detalles(int pacienteId, Form1 form_)
        {
            InitializeComponent();
            this.pacienteId = pacienteId;
            this.Form_ = form_;
            InitializeChildFormPanel(); // Inicializar el panel de formularios hijos
            ObtenerDatos(); // Cargar los datos del paciente al iniciar el formulario
        }

        private void InitializeChildFormPanel()
        {
            panelChildForm = new Panel
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(panelChildForm);
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            variable = textBox1.Text;
            ObtenerDatos(); // Filtrar y obtener los datos al cambiar el texto
        }

        private void ObtenerDatos()
        {
            string connectionString = "Server=DESKTOP-6HQEU93\\SQLEXPRESS01;Database=Veterinaria;Trusted_Connection=True;";
            string query = "SELECT Pacientes.Nombre, Pacientes.Animal, Pacientes.Raza, Turnos.Fecha, Turnos.Horario, Turnos.ID AS TurnoID " +
                           "FROM Pacientes INNER JOIN Turnos ON Pacientes.ID = Turnos.Paciente_id";

            if (!string.IsNullOrEmpty(variable))
            {
                if (int.TryParse(variable, out int pacienteId))
                {
                    query += " WHERE Turnos.Paciente_id = @pacienteId";
                }
                else
                {
                    query += " WHERE Pacientes.Nombre LIKE @nombre";
                }
            }
            else if (pacienteId > 0)
            {
                query += " WHERE Turnos.Paciente_id = @pacienteId";
            }

            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (pacienteId > 0)
                        {
                            cmd.Parameters.AddWithValue("@pacienteId", pacienteId);
                        }
                        else if (!string.IsNullOrEmpty(variable) && !int.TryParse(variable, out _))
                        {
                            cmd.Parameters.AddWithValue("@nombre", "%" + variable + "%");
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dataTable);
                        }
                    }
                }

                ConfigurarDataGridView(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ConfigurarDataGridView(DataTable dataTable)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

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

            // Configurar columnas visibles
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Animal", "Animal");
            dataGridView1.Columns.Add("Raza", "Raza");
            dataGridView1.Columns.Add("Fecha", "Fecha");
            dataGridView1.Columns.Add("Horario", "Horario");

            // Columna oculta para almacenar el ID del turno
            dataGridView1.Columns.Add("TurnoID", "TurnoID");
            dataGridView1.Columns["TurnoID"].Visible = false;

            // Agregar columna de botón "Agregar Descripción"
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Acción";
            buttonColumn.Text = "Agregar Descripción";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

            // Llenar el DataGridView con los datos obtenidos
            foreach (DataRow row in dataTable.Rows)
            {
                string nombre = row["Nombre"].ToString();
                string animal = row["Animal"].ToString();
                string raza = row["Raza"].ToString();
                string fecha = Convert.ToDateTime(row["Fecha"]).ToShortDateString();
                string horario = row["Horario"].ToString();
                int turnoID = Convert.ToInt32(row["TurnoID"]); // Obtener el ID del turno

                dataGridView1.Rows.Add(nombre, animal, raza, fecha, horario, turnoID);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int turnoID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TurnoID"].Value); // Obtener el ID del turno

                // Abrir Form8_Consulta directamente con el ID del turno

                Form_.openChildForm(new Form8_consulta(turnoID)); // Usa Form1 para abrir el formulario como hijo

                // Cierra Form2_Historias_Detalles
                this.Close();
            }
        }

    }
}
