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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string nombreProv = textBoxNombre.Text;

            if (int.TryParse(textBoxTelefono.Text, out int telefono))
            {
                if (string.IsNullOrEmpty(nombreProv))
                {
                    MessageBox.Show("Por favor, ingrese el nombre del proveedor.");
                    return;
                }

                string connectionString = "Server=DESKTOP-3CPGI44\\SQLEXPRESS;" +
               "Database=Veterinaria;" +
               "Trusted_Connection=True;";

                string query = "INSERT INTO Proveedores (Nombre, Telefono) VALUES (@Nombre, @Telefono)";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Nombre", nombreProv);
                            cmd.Parameters.AddWithValue("@Telefono", telefono);

                            int result = cmd.ExecuteNonQuery();

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
