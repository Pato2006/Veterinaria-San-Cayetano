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
        private Form1 Form_;

        public Form7_Añadir_producto(Form1 form)
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
        private void Form7_Añadir_producto_Load(object sender, EventArgs e)
        {
            LoadProveedores();
        }

        private void LoadProveedores()
        {
            string connectionString = "Server=DESKTOP-4QE2QT2;" +
                                      "Database=Veterinaria;" +
                                      "Trusted_Connection=True;";

            string query = "SELECT Nombre FROM Proveedores";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox1.Items.Clear();
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["Nombre"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string precio = textBox2.Text;
            int stock = int.Parse(textBoxStock.Text);
            string proveedor = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(proveedor))
            {
                MessageBox.Show("Por favor, seleccione un proveedor.");
                return;
            }

            // Cadena de conexión
            string connectionString = "Server=DESKTOP-4QE2QT2;" +
                                      "Database=Veterinaria;" +
                                      "Trusted_Connection=True;";

            int proveedorId;

            string queryProveedor = "SELECT Id FROM Proveedores WHERE Nombre = @proveedor";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

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

                    string queryProducto = "INSERT INTO Productos (Nombre, Precio_unitario, Stock, Proveedor_id) " +
                                           "VALUES (@nombre, @precio, @stock, @proveedorId)";

                    using (SqlCommand cmdProducto = new SqlCommand(queryProducto, con))
                    {
                        cmdProducto.Parameters.AddWithValue("@nombre", nombre);
                        cmdProducto.Parameters.AddWithValue("@precio", precio);
                        cmdProducto.Parameters.AddWithValue("@stock", stock);
                        cmdProducto.Parameters.AddWithValue("@proveedorId", proveedorId);

                        int result = cmdProducto.ExecuteNonQuery();

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
            Form_.openChildForm(new Form2_Productos_Lista(Form_));
        }

        private void textBoxStock_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
