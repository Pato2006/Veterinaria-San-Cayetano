using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form2_Historias_Detalles : Form
    {
        private int id_paciente;  // Variable para almacenar el ID del paciente
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;

        public Form2_Historias_Detalles(int id, Form1 form_)
        {
            InitializeComponent();
            InitializeChildFormPanel();
            hideSubMenu();
            id_paciente = id;
            CargarDatos(id_paciente);
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form2_Historias_Detalles_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2_Historias_Ejemplo());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        private void CargarDatos(int id)
        {
            // Cadena de conexión (ajústala según tu servidor y base de datos)
            string connectionString = "Server=DESKTOP-4QE2QT2;" +
                "Database=Veterinaria;" +
                "Trusted_Connection=True;";

            // Consulta SQL para obtener los datos del paciente con el ID especificado
            string query = "SELECT ID, Nombre, Animal, Raza, Edad, Telefono FROM Pacientes WHERE ID = @id";

            // Crear un DataTable para almacenar los resultados
            DataTable pacienteData = new DataTable();

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
                        // Agregar el parámetro para la consulta
                        cmd.Parameters.AddWithValue("@id", id);

                        // Crear un SqlDataAdapter para llenar el DataTable
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            // Llenar el DataTable con los resultados de la consulta
                            da.Fill(pacienteData);
                        }
                    }
                }

                // Verificar si se ha encontrado un paciente
                if (pacienteData.Rows.Count > 0)
                {
                    // Acceder a los datos del paciente (si se encuentra en la base de datos)
                    DataRow row = pacienteData.Rows[0];
                    string nombre = row["Nombre"].ToString();
                    string animal = row["Animal"].ToString();
                    string raza = row["Raza"].ToString();
                    string edad = row["Edad"].ToString();
                    string telefono = row["Telefono"].ToString();

                    // Mostrar los datos del paciente en un mensaje (puedes actualizar controles de UI si prefieres)
                    Nombre.Text = "Nombre: " + nombre;
                    Animal.Text = "Animal: " + animal;
                    Raza.Text = "Raza: " + raza;
                    Edad.Text = "Edad: " + edad;
                    Telefono.Text = "Telefono: " + telefono;
                }
                else
                {
                    // Si no se encuentra el paciente
                    MessageBox.Show("No se encontró un paciente con este ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que ocurra un problema con la conexión o consulta
                MessageBox.Show($"Error: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // Confirmación antes de eliminar
            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este paciente?",
                                                 "Confirmar Eliminación",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Llamamos al método para eliminar el paciente
                EliminarPaciente();
            }
        }
        private void Nombre_Click(object sender, EventArgs e)
        {

        }

        private void Animal_Click(object sender, EventArgs e)
        {

        }

        private void Telefono_Click(object sender, EventArgs e)
        {

        }

        private void Raza_Click(object sender, EventArgs e)
        {

        }

        private void Peso_Click(object sender, EventArgs e)
        {

        }

        private void Edad_Click(object sender, EventArgs e)
        {

        }


        private void EliminarPaciente()
        {
            // Cadena de conexión
            string connectionString = "Server=DESKTOP-4QE2QT2;" +
                "Database=Veterinaria;" +
                "Trusted_Connection=True;";

            // La consulta DELETE para eliminar al paciente
            string query = "DELETE FROM Pacientes WHERE ID = @id";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Añadir el parámetro para el ID
                        cmd.Parameters.AddWithValue("@id", id_paciente);

                        // Ejecutar la consulta
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("El paciente ha sido eliminado exitosamente.",
                                            "Eliminación Exitosa",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar un paciente con este ID.",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_.openChildForm(new Form2_Historias_editar(id_paciente));
        }
    }
}
