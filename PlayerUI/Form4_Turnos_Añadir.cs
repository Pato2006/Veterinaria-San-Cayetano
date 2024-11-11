using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form4_Turnos_Añadir : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;

        public Form4_Turnos_Añadir()
        {
            InitializeComponent();
            InitializeChildFormPanel();
            hideSubMenu();

            comboBoxArea.Items.Add("Veterinaria");
            comboBoxArea.Items.Add("Peluqueria");
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

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Clear();
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

      
        private void Form4_Turnos_Añadir_Load(object sender, EventArgs e)
        {
        }

        private void textBoxHorario_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxAnimal_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxRaza_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void textBoxFecha_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            // Variables para capturar los valores de los controles
            string nombre = textBoxNombre.Text;
            string fecha = textBoxFecha.Text;
            string horario = textBoxHorario.Text;
            string area = comboBoxArea.SelectedItem?.ToString();  // Obtener la opción seleccionada del ComboBox

            if (string.IsNullOrEmpty(area))
            {
                MessageBox.Show("Por favor, seleccione un área.");
                return;
            }
            else if (area == "Veterinaria")
            {
                area = "1";
            }
            else if (area == "Peluqueria")
            {
                area = "2";
            }

            // Verificar que el nombre no esté vacío
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese el nombre del paciente.");
                return;
            }

            // Convertir la fecha al formato requerido por SQL Server (yyyy-MM-dd)
            DateTime fechaConvertida;
            if (!DateTime.TryParseExact(fecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaConvertida))
            {
                MessageBox.Show("La fecha no tiene el formato correcto. Use el formato dd/MM/aa.");
                return;
            }

            // Convertir la fecha a un formato compatible con SQL Server (yyyy-MM-dd)
            string fechaSQL = fechaConvertida.ToString("yyyy-MM-dd");

            // Cadena de conexión (ajusta según tu servidor, base de datos y autenticación)
            string connectionString = "Server=PC-F-06\\SQLEXPRESS;Database=Cayetano;Trusted_Connection=True;";

            // Primero obtenemos el ID del paciente usando su nombre
            string pacienteId = null;

            string queryPaciente = "SELECT Id FROM Pacientes WHERE Nombre = @nombre";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Obtener el ID del paciente
                    using (SqlCommand cmdPaciente = new SqlCommand(queryPaciente, con))
                    {
                        cmdPaciente.Parameters.AddWithValue("@nombre", nombre);
                        pacienteId = cmdPaciente.ExecuteScalar()?.ToString();

                        if (string.IsNullOrEmpty(pacienteId))
                        {
                            MessageBox.Show("Paciente no encontrado.");
                            return;
                        }
                    }

                    // Ahora insertamos el turno en la tabla Turnos usando el ID del paciente encontrado
                    string queryTurno = "INSERT INTO Turnos (Paciente_id, Area_id, Horario, Fecha) " +
                                        "VALUES (@pacienteId, @area, @horario, @Fecha)";

                    using (SqlCommand cmdTurno = new SqlCommand(queryTurno, con))
                    {
                        // Agregar los parámetros para la inserción
                        cmdTurno.Parameters.AddWithValue("@pacienteId", pacienteId);  // Usar el ID del paciente encontrado
                        cmdTurno.Parameters.AddWithValue("@area", area);
                        cmdTurno.Parameters.AddWithValue("@horario", horario);
                        cmdTurno.Parameters.AddWithValue("@Fecha", fechaSQL);  // Usar la fecha convertida

                        // Ejecutar la consulta
                        int result = cmdTurno.ExecuteNonQuery();

                        // Verificar si el registro fue insertado con éxito
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
        }
    }
}