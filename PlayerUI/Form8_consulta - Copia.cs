using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form8_consulta : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;
        private int turnoId; // Variable para almacenar el ID del turno

        // Constructor modificado para recibir el ID del turno
        public Form8_consulta(int turnoId)
        {
            InitializeComponent();
            InitializeChildFormPanel();
            hideSubMenu();

            // Guardar el ID del turno recibido
            this.turnoId = turnoId;
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

        // Aquí se recibe el ID del turno y se utiliza
        private void button2_Click(object sender, EventArgs e)
        {
            // Capturamos los valores de los TextBox
            string diagnostico = textBoxDiagnostico.Text;
            string observacion = textBoxObservacion.Text;
            string tratamiento = textBoxTratamiento.Text;

            // Verificar y convertir el peso
            if (!decimal.TryParse(textBoxPeso.Text, out decimal peso))
            {
                MessageBox.Show("Por favor, introduce un valor numérico válido para el peso.");
                return;
            }

            string connectionString = "Server=DESKTOP-6HQEU93\\SQLEXPRESS01;Database=Veterinaria;Trusted_Connection=True;";
            string query = "INSERT INTO Consultas (Turno_id, Observacion, Diagnostico, Tratamiento, Peso) " +
                           "VALUES (@Turno_id, @Observacion, @Diagnostico, @Tratamiento, @Peso)";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Turno_id", turnoId);
                        cmd.Parameters.AddWithValue("@Observacion", observacion);
                        cmd.Parameters.AddWithValue("@Diagnostico", diagnostico);
                        cmd.Parameters.AddWithValue("@Tratamiento", tratamiento);
                        cmd.Parameters.AddWithValue("@Peso", peso);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Consulta añadida exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al añadir la consulta.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void textBoxObservacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPeso_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTratamiento_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDiagnostico_TextChanged(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form4_Turnos_Añadir_Load(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
