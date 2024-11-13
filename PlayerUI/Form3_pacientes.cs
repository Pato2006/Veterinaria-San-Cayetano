using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PlayerUI
{
    public partial class Form3_pacientes : Form
    {

        private Panel panelChildForm;
        private Form1 Form_;

        private string variable = string.Empty;

        public Form3_pacientes(Form1 form_)
        {
            InitializeComponent();
            InitializeChildFormPanel();
            hideSubMenu();
            ObtenerTurnos();
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            variable = textBox1.Text;

            ObtenerTurnos();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form_.openChildForm(new Form5_Añadir_Paciente(Form_));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            variable = textBox1.Text;
        }

        private void ObtenerTurnos()
        {
            string connectionString = "Server=DESKTOP-4QE2QT2;" +
                  "Database=Veterinaria;" +
                  "Trusted_Connection=True;";

            string query = "SELECT ID, Animal, Raza, Nombre, Edad, Telefono FROM Pacientes";

            if (!string.IsNullOrEmpty(variable))
            {
                query += " WHERE Nombre LIKE @nombre";
            }

            DataTable turnosTable = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!string.IsNullOrEmpty(variable))
                        {
                            cmd.Parameters.AddWithValue("@nombre", "%" + variable + "%");
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            turnosTable.Clear();
                            da.Fill(turnosTable);
                        }
                    }
                }

                //Limpiar las columnas y filas existentes
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToOrderColumns = false;


                //Columnas visibles
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Animal", "Animal");
                dataGridView1.Columns.Add("Raza", "Raza");
                dataGridView1.Columns.Add("Edad", "Edad");
                dataGridView1.Columns.Add("Telefono", "Telefono");

                //Columna oculta
                var idColumn = new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    Visible = false
                };
                dataGridView1.Columns.Add(idColumn);

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Historia",
                    Text = "Ver",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(buttonColumn);

                foreach (DataRow row in turnosTable.Rows)
                {
                    string Nombre = row["Nombre"].ToString();
                    string Animal = row["Animal"].ToString();
                    string Raza = row["Raza"].ToString();
                    string Edad = row["Edad"].ToString();
                    string Telefono = row["Telefono"].ToString();
                    string ID = row["ID"].ToString();

                    if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Animal) &&
                        !string.IsNullOrEmpty(Raza) && !string.IsNullOrEmpty(Edad) &&
                        !string.IsNullOrEmpty(Telefono) && !string.IsNullOrEmpty(ID))
                    {
                        dataGridView1.Rows.Add(Nombre, Animal, Raza, Edad, Telefono, ID);
                    }
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int idValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                Form_.openChildForm(new Form2_Historias_Detalles(idValue, Form_));
            }
        }
    }
}
