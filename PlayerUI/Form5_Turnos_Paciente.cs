﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form5_Turnos_Paciente : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;

        public Form5_Turnos_Paciente()
        {
            InitializeComponent();  
            InitializeChildFormPanel();
            hideSubMenu();
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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Variables para capturar los valores de los TextBox
            string animal = textBoxAnimal.Text;
            string nombre = textBoxNombre.Text;
            string raza = textBoxRaza.Text;
            string edad = textBoxFecha.Text;
            string telefono = textBoxHorario.Text;

            // Cadena de conexión (ajusta según tu servidor, base de datos y autenticación)
            string connectionString = "Server=DESKTOP-3CPGI44\\SQLEXPRESS;Database=Veterinaria;Trusted_Connection=True;";

            // Consulta SQL para insertar un nuevo turno
            string query = "INSERT INTO Pacientes (Animal, Raza, Nombre, Edad, Telefono) VALUES (@Animal, @Raza, @Nombre, @Edad, @Telefono)";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Agregar parámetros para prevenir inyecciones SQL
                        cmd.Parameters.AddWithValue("@Animal", animal);
                        cmd.Parameters.AddWithValue("@Raza", raza);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Edad", edad);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);

                        // Ejecutar la consulta
                        int result = cmd.ExecuteNonQuery();

                        // Verificar si el registro fue insertado con éxito
                        if (result > 0)
                        {
                            MessageBox.Show("Turno añadido exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al añadir el turno.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
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
    }
}
