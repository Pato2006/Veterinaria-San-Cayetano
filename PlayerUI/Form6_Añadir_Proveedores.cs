using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form6_Añadir_Proveedores : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;
        private Form1 Form_;

        public Form6_Añadir_Proveedores(Form1 form)
        {
            InitializeComponent();  
            InitializeChildFormPanel();
            hideSubMenu();
            Form_ = form;
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBox
            string nombreProv = textBoxNombre.Text;

            // Verificar que el teléfono sea un valor válido
            if (int.TryParse(textBoxTelefono.Text, out int telefono))
            {
                // Verificar que el nombre no esté vacío
                if (string.IsNullOrEmpty(nombreProv))
                {
                    MessageBox.Show("Por favor, ingrese el nombre del proveedor.");
                    return;
                }

                // Cadena de conexión (ajusta según tu servidor, base de datos y autenticación)
                string connectionString = "Server=DESKTOP-6HQEU93\\SQLEXPRESS01;" +
               "Database=Veterinaria;" +
               "Trusted_Connection=True;";

                // Consulta SQL para insertar un nuevo proveedor
                string query = "INSERT INTO Proveedores (Nombre, Telefono) VALUES (@Nombre, @Telefono)";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Agregar parámetros para prevenir inyecciones SQL
                            cmd.Parameters.AddWithValue("@Nombre", nombreProv);
                            cmd.Parameters.AddWithValue("@Telefono", telefono);

                            // Ejecutar la consulta
                            int result = cmd.ExecuteNonQuery();

                            // Verificar si el registro fue insertado con éxito
                            if (result > 0)
                            {
                                MessageBox.Show("Proveedor añadido exitosamente.");
                            }
                            else
                            {
                                MessageBox.Show("Error al añadir el proveedor.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un teléfono válido.");
            }
            Form_.openChildForm(new Form2_Productos_Lista(Form_));
        }

        private void textBoxNombre_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
