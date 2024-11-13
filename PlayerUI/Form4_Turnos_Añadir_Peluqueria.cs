using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form4_Turnos_Añadir_Peluqueria : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;

        public Form4_Turnos_Añadir_Peluqueria(Form1 form_)
        {
            InitializeComponent();
            InitializeChildFormPanel();
            hideSubMenu();

            Form_ = form_;

            FillComboBoxPaciente();
        }

        private void hideSubMenu()
        {
        }
        private void InitializeChildFormPanel()
        {
            panelChildForm = new Panel
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(panelChildForm);
        }

        private void FillComboBoxPaciente()
        {
            string connectionString = "Server=DESKTOP-747DT10\\SQLEXPRESS;" +
                                      "Database=Veterinaria;" +
                                      "Trusted_Connection=True;";

            string query = "SELECT Nombre FROM Pacientes";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBoxPaciente.Items.Clear();

                            while (reader.Read())
                            {
                                comboBoxPaciente.Items.Add(reader["Nombre"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los nombres de los pacientes: {ex.Message}");
            }
        }

        private void Form4_Turnos_Añadir_Load(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            string pacienteNombre = comboBoxPaciente.SelectedItem?.ToString();
            string fecha = textBoxFecha.Text;
            string horario = textBoxHorario.Text;
            string area = "1";

            if (string.IsNullOrEmpty(pacienteNombre))
            {
                MessageBox.Show("Por favor, seleccione un paciente.");
                return;
            }

            //Convertir la fecha al formato requerido de SQL Server (yyyy-MM-dd)
            DateTime fechaConvertida;
            if (!DateTime.TryParseExact(fecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaConvertida))
            {
                MessageBox.Show("La fecha no tiene el formato correcto. Use el formato dd/MM/aa.");
                return;
            }

            string fechaSQL = fechaConvertida.ToString("yyyy-MM-dd");

            string connectionString = "Server=DESKTOP-747DT10\\SQLEXPRESS;" +
                "Database=Veterinaria;" +
                "Trusted_Connection=True;";

            string pacienteId = null;

            string queryPaciente = "SELECT Id FROM Pacientes WHERE Nombre = @nombre";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmdPaciente = new SqlCommand(queryPaciente, con))
                    {
                        cmdPaciente.Parameters.AddWithValue("@nombre", pacienteNombre);
                        pacienteId = cmdPaciente.ExecuteScalar()?.ToString();

                        if (string.IsNullOrEmpty(pacienteId))
                        {
                            MessageBox.Show("Paciente no encontrado.");
                            return;
                        }
                    }

                    string queryTurno = "INSERT INTO Turnos (Paciente_id, Area_id, Horario, Fecha) " +
                                        "VALUES (@pacienteId, @area, @horario, @Fecha)";

                    using (SqlCommand cmdTurno = new SqlCommand(queryTurno, con))
                    {
                        cmdTurno.Parameters.AddWithValue("@pacienteId", pacienteId);
                        cmdTurno.Parameters.AddWithValue("@area", area);
                        cmdTurno.Parameters.AddWithValue("@horario", horario);
                        cmdTurno.Parameters.AddWithValue("@Fecha", fechaSQL);

                        int result = cmdTurno.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Turno añadido exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al añadir el turno.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            Form_.openChildForm(new Form2_peluqueria(Form_));
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void textBoxHorario_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void comboBoxPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
