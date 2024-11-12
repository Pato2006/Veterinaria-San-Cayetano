using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form7_Añadir_producto : Form
    {
        private Form activeForm = null;
        private Panel panelChildForm;

        public Form7_Añadir_producto()
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
            string nombre = textBoxNombre.Text;
            string precio = textBox2.Text;
            int stock = int.Parse(textBoxStock.Text);
            string proveedor = textBox1.Text;  // Ahora está declarado y asignado correctamente

            // Verificar que el nombre no esté vacío
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese el nombre del proveedor.");
                return;
            }

            // Cadena de conexión
            string connectionString = "Server=DESKTOP-747DT10\\SQLEXPRESS;Database=Veterinaria;Trusted_Connection=True;";

            // Primero obtenemos el ID del proveedor usando su nombre
            int proveedorId;

            string queryProveedor = "SELECT Id FROM Proveedores WHERE Nombre = @proveedor";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Obtener el ID del proveedor
                    using (SqlCommand cmdProveedor = new SqlCommand(queryProveedor, con))
                    {
                        cmdProveedor.Parameters.AddWithValue("@proveedor", proveedor);
                        object result = cmdProveedor.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("Proveedor no encontrado.");
                            return;
                        }

                        proveedorId = Convert.ToInt32(result);
                    }

                    // Ahora insertamos el producto en la tabla Productos usando el ID del proveedor encontrado
                    string queryProducto = "INSERT INTO Productos (Nombre, Precio_unitario, Stock, Proveedor_id) " +
                                           "VALUES (@nombre, @precio, @stock, @proveedorId)";

                    using (SqlCommand cmdProducto = new SqlCommand(queryProducto, con))
                    {
                        // Agregar los parámetros para la inserción
                        cmdProducto.Parameters.AddWithValue("@nombre", nombre);
                        cmdProducto.Parameters.AddWithValue("@precio", precio);
                        cmdProducto.Parameters.AddWithValue("@stock", stock);
                        cmdProducto.Parameters.AddWithValue("@proveedorId", proveedorId);

                        // Ejecutar la consulta
                        int result = cmdProducto.ExecuteNonQuery();

                        // Verificar si el registro fue insertado con éxito
                        if (result > 0)
                        {
                            MessageBox.Show("Producto añadido exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al añadir el producto.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void textBoxStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

