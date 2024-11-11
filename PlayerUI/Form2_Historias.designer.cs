namespace PlayerUI
{
    partial class Form2_Historias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Nombre = new System.Windows.Forms.Label();
            this.Animal = new System.Windows.Forms.Label();
            this.Raza = new System.Windows.Forms.Label();
            this.Edad = new System.Windows.Forms.Label();
            this.Peso = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(299, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "HISTORIAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(619, 347);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 7;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(49, 71);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(94, 31);
            this.Nombre.TabIndex = 8;
            this.Nombre.Text = "Nombre";
            this.Nombre.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // Animal
            // 
            this.Animal.Location = new System.Drawing.Point(49, 119);
            this.Animal.Name = "Animal";
            this.Animal.Size = new System.Drawing.Size(94, 31);
            this.Animal.TabIndex = 9;
            this.Animal.Text = "Animal";
            this.Animal.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // Raza
            // 
            this.Raza.Location = new System.Drawing.Point(49, 161);
            this.Raza.Name = "Raza";
            this.Raza.Size = new System.Drawing.Size(94, 31);
            this.Raza.TabIndex = 10;
            this.Raza.Text = "Raza";
            // 
            // Edad
            // 
            this.Edad.Location = new System.Drawing.Point(49, 201);
            this.Edad.Name = "Edad";
            this.Edad.Size = new System.Drawing.Size(94, 31);
            this.Edad.TabIndex = 11;
            this.Edad.Text = "Edad";
            // 
            // Peso
            // 
            this.Peso.Location = new System.Drawing.Point(49, 243);
            this.Peso.Name = "Peso";
            this.Peso.Size = new System.Drawing.Size(94, 31);
            this.Peso.TabIndex = 12;
            this.Peso.Text = "Peso";
            // 
            // Telefono
            // 
            this.Telefono.Location = new System.Drawing.Point(49, 290);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(94, 31);
            this.Telefono.TabIndex = 13;
            this.Telefono.Text = "Telefono";
            // 
            // Form2_Historias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(684, 431);
            this.Controls.Add(this.Telefono);
            this.Controls.Add(this.Peso);
            this.Controls.Add(this.Edad);
            this.Controls.Add(this.Raza);
            this.Controls.Add(this.Animal);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Form2_Historias";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Historias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label Edad;
        private System.Windows.Forms.Label Raza;
        private System.Windows.Forms.Label Animal;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label Telefono;
        private System.Windows.Forms.Label Peso;
    }
}