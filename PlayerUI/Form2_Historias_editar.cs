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
            string connectionString = "Server=DESKTOP-6HQEU93\\SQLEXPRESS01;" +
                            "Database=Veterinaria;" +
                            "Trusted_Connection=True;";
            try
            {
                // Obtener los valores de los campos de texto (editados por el usuario)
                string animal_edit = textBoxNombre.Text;  // Asumiendo que textBoxNombre es el campo para Animal
                string raza_edit = textBox1.Text;         // Asumiendo que textBox1 es el campo para Raza
                string nombre_ed = textBoxHorario.Text;   // Asumiendo que textBoxHorario es el campo para Nombre
                int edad = int.Parse(textBoxFecha.Text);  // Asumiendo que textBoxFecha es el campo para Edad
                int telefono = int.Parse(textBox2.Text);  // Asumiendo que textBox2 es el campo para Teléfono

                // Consulta SQL para hacer el UPDATE en la tabla Pacientes
                string queryPaciente = "UPDATE Pacientes SET " +
                                       "Nombre = @nombre, " +
                                       "Animal = @animal, " +
                                       "Raza = @raza, " +
                                       "Edad = @edad, " +
                                       "Telefono = @telefono " +
                                       "WHERE ID = @id";

                // Conexión a la base de datos y ejecución del comando
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Crear un SqlCommand con la consulta y la conexión
                    using (SqlCommand cmd = new SqlCommand(queryPaciente, con))
                    {
                        // Agregar los parámetros con los valores obtenidos de los campos de texto
                        cmd.Parameters.AddWithValue("@nombre", nombre_ed);
                        cmd.Parameters.AddWithValue("@animal", animal_edit);
                        cmd.Parameters.AddWithValue("@raza", raza_edit);
                        cmd.Parameters.AddWithValue("@edad", edad);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@id", id_editar);  // Asegúrate de pasar el ID correcto

                        // Abrir la conexión
                        con.Open();

                        // Ejecutar el UPDATE
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Verificar si el UPDATE fue exitoso
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
                // Manejo de errores
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