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
            //openChildForm(new Form2_Ejemplo());
            string textoGuardado;

            // Guarda el contenido del TextBox en la variable
            textoGuardado = textBox1.Text;
            MessageBox.Show("Texto guardado: " + textoGuardado);

            // Elimina columnas anteriores (si existen)
            dataGridView1.Columns.Clear();

            // Crea una nueva columna de botones
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Acciones"; // Título de la columna
            buttonColumn.Text = "Presiona"; // Texto del botón
            buttonColumn.UseColumnTextForButtonValue = true; // Para mostrar el texto en todas las filas

            // Agrega la columna al DataGridView
            dataGridView1.Columns.Add(buttonColumn);

            // Agrega algunas filas de ejemplo (opcional)
            for (int i = 1; i < 5; i++)
            {
                dataGridView1.Rows.Add();
            }

        }

        // Métodos restantes
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // Acción al presionar el botón
                MessageBox.Show($"Botón presionado en la fila {e.RowIndex + 1}");
            }

        }

        private void ObtenerTurnos()
        {
            // Cadena de conexión (ajusta según tu servidor, base de datos y autenticación)
            string connectionString = "Server=PC-F-06\\SQLEXPRESS;" +
                "Database=Vete;" +
                "Trusted_Connection=True;";


            // Consulta SQL para obtener los turnos
            string query = "SELECT Pacientes.Nombre, Turnos.Horario, Pacientes.Animal, Pacientes.Raza, Turnos.Fecha FROM Pacientes INNER JOIN Turnos ON Pacientes.ID = Turnos.Paciente_id";

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

                // Crea las columnas de texto (4 columnas)
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
                idColumn.HeaderText = "Nombre";
                dataGridView1.Columns.Add(idColumn);

                DataGridViewTextBoxColumn pacienteColumn = new DataGridViewTextBoxColumn();
                pacienteColumn.HeaderText = "Animal";
                dataGridView1.Columns.Add(pacienteColumn);

                DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
                fechaColumn.HeaderText = "Raza";
                dataGridView1.Columns.Add(fechaColumn);

                DataGridViewTextBoxColumn mascotaColumn = new DataGridViewTextBoxColumn();
                mascotaColumn.HeaderText = "Fecha";
                dataGridView1.Columns.Add(mascotaColumn);

                DataGridViewTextBoxColumn HoraColumn = new DataGridViewTextBoxColumn();
                HoraColumn.HeaderText = "Hora";
                dataGridView1.Columns.Add(HoraColumn);


                // Crea una nueva columna de botones
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Historia"; // Título de la columna
                buttonColumn.Text = "Ver"; // Texto del botón
                buttonColumn.UseColumnTextForButtonValue = true; // Para mostrar el texto en todas las filas
                dataGridView1.Columns.Add(buttonColumn);

                // Mostrar los datos obtenidos (puedes adaptar esto para tu DataGridView)
                foreach (DataRow row in turnosTable.Rows)
                {
                    string Nombre = row["Nombre"].ToString();
                    string Animal = row["Animal"].ToString();
                    string Raza = row["Raza"].ToString();
                    string Fecha = row["Fecha"].ToString();
                    string Horario = row["Horario"].ToString();

                    // Agrega la fila con datos en las 4 columnas de texto y el botón
                    dataGridView1.Rows.Add(Nombre, Animal, Raza, Fecha, Horario);
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
            

        }
    }
}
