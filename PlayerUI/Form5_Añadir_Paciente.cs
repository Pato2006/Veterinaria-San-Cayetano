using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form5_Añadir_Paciente : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;

        public Form5_Añadir_Paciente(Form1 form)
        {
            InitializeComponent();
            InitializeChildFormPanel();
            hideSubMenu();
            Form_ = form;
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

        private void Form4_Turnos_Añadir_Load(object sender, EventArgs e)
        {
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string animal = textBoxAnimal.Text;
            string nombre = textBoxNombre.Text;
            string raza = textBoxRaza.Text;
            string edad = textBoxEdad.Text;
            string telefono = textBoxTelefono.Text;
                
            string connectionString = "Server=DESKTOP-3CPGI44\\SQLEXPRESS;" +
                "Database=Veterinaria;" +
                "Trusted_Connection=True;";

            string query = "INSERT INTO Pacientes (Animal, Raza, Nombre, Edad, Telefono) VALUES (@Animal, @Raza, @Nombre, @Edad, @Telefono)";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Animal", animal);
                        cmd.Parameters.AddWithValue("@Raza", raza);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Edad", edad);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Paciente añadido exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al añadir el Paciente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            Form_.openChildForm(new Form3_pacientes(Form_));
        }

    }
}
