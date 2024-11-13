using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form2_Historias_Detalles : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;
        private string variable = string.Empty;
        private int pacienteId;
        private TextBox textBox1;

        public Form2_Historias_Detalles(int pacienteId, Form1 form_)
        {
            InitializeComponent();
            this.pacienteId = pacienteId;
            this.Form_ = form_;
            InitializeChildFormPanel();
            ObtenerDatos();
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
            ObtenerDatos();
        }

        private void ObtenerDatos()
        {
            string connectionString = "Server=DESKTOP-3CPGI44\\SQLEXPRESS;Database=Veterinaria;Trusted_Connection=True;";

            string query = "SELECT Pacientes.Nombre, Pacientes.Animal, Pacientes.Raza, Turnos.Fecha, Turnos.Horario, Turnos.ID AS TurnoID, " +
                           "Consultas.Observacion, Consultas.Diagnostico, Consultas.Tratamiento, Consultas.Peso " +
                           "FROM Pacientes " +
                           "INNER JOIN Turnos ON Pacientes.ID = Turnos.Paciente_id " +
                           "LEFT JOIN Consultas ON Consultas.Turno_ID = Turnos.ID " +
                           "WHERE Turnos.Area_id = 2";

            if (!string.IsNullOrEmpty(variable))
            {
                if (int.TryParse(variable, out int pacienteId))
                {
                    query += " AND Turnos.Paciente_id = @pacienteId";
                }
                else
                {
                    query += " AND Pacientes.Nombre LIKE @nombre";
                }
            }
            else if (pacienteId > 0)
            {
                query += " AND Turnos.Paciente_id = @pacienteId";
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

            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Animal", "Animal");
            dataGridView1.Columns.Add("Fecha", "Fecha");
            dataGridView1.Columns.Add("Horario", "Horario");
            dataGridView1.Columns.Add("Observacion", "Observación");
            dataGridView1.Columns.Add("Diagnostico", "Diagnóstico");
            dataGridView1.Columns.Add("Tratamiento", "Tratamiento");
            dataGridView1.Columns.Add("Peso", "Peso");

            dataGridView1.Columns.Add("TurnoID", "TurnoID");
            dataGridView1.Columns["TurnoID"].Visible = false;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Acción";
            buttonColumn.Text = "Agregar Descripción";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

            foreach (DataRow row in dataTable.Rows)
            {
                string nombre = row["Nombre"].ToString();
                string animal = row["Animal"].ToString();
                string fecha = Convert.ToDateTime(row["Fecha"]).ToShortDateString();
                string horario = row["Horario"].ToString();
                string observacion = row["Observacion"].ToString();
                string diagnostico = row["Diagnostico"].ToString();
                string tratamiento = row["Tratamiento"].ToString();
                string peso = row["Peso"].ToString();
                int turnoID = Convert.ToInt32(row["TurnoID"]);

                dataGridView1.Rows.Add(nombre, animal, fecha, horario, observacion, diagnostico, tratamiento, peso, turnoID);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int turnoID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TurnoID"].Value);

                Form_.openChildForm(new Form8_consulta(turnoID));

                this.Close();
            }
        }

        private void Form2_Historias_Detalles_Load(object sender, EventArgs e)
        {

        }
    }
}
