using System;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form2 : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;

        public Form2()
        {
            InitializeComponent();
            InitializeChildFormPanel();
            hideSubMenu();
            ObtenerTurnos();
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

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2_Ejemplo());
        }

        // Métodos restantes
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ObtenerTurnos()
        {
            // Cadena de conexión (ajusta según tu servidor, base de datos y autenticación)
            string connectionString = "Data Source=DESKTOP-3CPGI44\\SQLEXPRESS;Initial Catalog=Veterinaria;Integrated Security=True";

            // Consulta SQL para obtener los turnos
            string query = "SELECT * FROM turnos";

            // Crear un DataTable para almacenar los resultados de la consulta
            DataTable turnosTable = new DataTable();

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
                        // Crear un SqlDataAdapter para llenar el DataTable
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            // Llenar el DataTable con los resultados de la consulta
                            da.Fill(turnosTable);
                        }
                    }
                }

                // Mostrar los datos obtenidos (puedes adaptar esto para tu DataGridView)
                foreach (DataRow row in turnosTable.Rows)
                {
                    string idTurno = row["ID"].ToString();
                    string nombreCliente = row["Paciente_id"].ToString();
                    string fechaTurno = row["Horario"].ToString();
                    string mascota = row["Fecha"].ToString();

                    // Aquí solo estamos mostrando en un MessageBox, pero puedes llenar el DataGridView con estos datos
                    MessageBox.Show($"Turno ID: {idTurno}, Cliente: {nombreCliente}, Fecha: {fechaTurno}, Mascota: {mascota}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que ocurra un problema con la conexión o consulta
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'veterinariaDataSet.Turnos' Puede moverla o quitarla según sea necesario.
            this.turnosTableAdapter.Fill(this.veterinariaDataSet.Turnos);

        }
    }
}
