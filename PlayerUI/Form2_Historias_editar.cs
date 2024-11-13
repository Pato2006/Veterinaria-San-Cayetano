using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form2_Historias_editar : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private int id_editar;
        public Form2_Historias_editar(int id)
        {
            InitializeComponent();
            InitializeChildFormPanel();
            hideSubMenu();
            id_editar = id;
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
        private void Form4_Turnos_Añadir_Load(object sender, EventArgs e)
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
            string connectionString = "Server=DESKTOP-747DT10\\SQLEXPRESS;" +
                            "Database=Veterinaria;" +
                            "Trusted_Connection=True;";
            try
            {

                string animal_edit = textBoxNombre.Text;
                string raza_edit = textBox1.Text;
                string nombre_ed = textBoxHorario.Text;
                int edad = int.Parse(textBoxFecha.Text);
                int telefono = int.Parse(textBox2.Text);

                string queryPaciente = "UPDATE Pacientes SET " +
                                       "Nombre = @nombre, " +
                                       "Animal = @animal, " +
                                       "Raza = @raza, " +
                                       "Edad = @edad, " +
                                       "Telefono = @telefono " +
                                       "WHERE ID = @id";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryPaciente, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre_ed);
                        cmd.Parameters.AddWithValue("@animal", animal_edit);
                        cmd.Parameters.AddWithValue("@raza", raza_edit);
                        cmd.Parameters.AddWithValue("@edad", edad);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@id", id_editar);

                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Paciente actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el paciente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxHorario_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFecha_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}