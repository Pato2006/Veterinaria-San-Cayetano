﻿namespace PlayerUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMedia = new System.Windows.Forms.Button();
            this.panelMediaSubMenu = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPlaylist = new System.Windows.Forms.Button();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMediaSubMenu.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(253, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(981, 618);
            this.panelChildForm.TabIndex = 2;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChildForm_Paint);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(253, 92);
            this.panelLogo.TabIndex = 0;
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogo_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "SAN\r\nCAYETANO\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PlayerUI.Properties.Resources.pngwing_com__3_;
            this.pictureBox1.Location = new System.Drawing.Point(0, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // btnMedia
            // 
            this.btnMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.btnMedia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedia.FlatAppearance.BorderSize = 0;
            this.btnMedia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnMedia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.btnMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedia.ForeColor = System.Drawing.Color.Black;
            this.btnMedia.Image = global::PlayerUI.Properties.Resources.pngwing_com__1_;
            this.btnMedia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedia.Location = new System.Drawing.Point(0, 92);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMedia.Size = new System.Drawing.Size(253, 45);
            this.btnMedia.TabIndex = 1;
            this.btnMedia.Text = "  Veterinaria";
            this.btnMedia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMedia.UseVisualStyleBackColor = false;
            this.btnMedia.Click += new System.EventHandler(this.btnMedia_Click);
            // 
            // panelMediaSubMenu
            // 
            this.panelMediaSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.panelMediaSubMenu.Controls.Add(this.button3);
            this.panelMediaSubMenu.Controls.Add(this.button2);
            this.panelMediaSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMediaSubMenu.Location = new System.Drawing.Point(0, 137);
            this.panelMediaSubMenu.Name = "panelMediaSubMenu";
            this.panelMediaSubMenu.Size = new System.Drawing.Size(253, 82);
            this.panelMediaSubMenu.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(0, 40);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(253, 40);
            this.button3.TabIndex = 1;
            this.button3.Text = "Pacientes";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(253, 40);
            this.button2.TabIndex = 0;
            this.button2.Text = "Turnos";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 573);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(253, 45);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "  Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.panelSideMenu.Controls.Add(this.button1);
            this.panelSideMenu.Controls.Add(this.btnExit);
            this.panelSideMenu.Controls.Add(this.btnPlaylist);
            this.panelSideMenu.Controls.Add(this.panelMediaSubMenu);
            this.panelSideMenu.Controls.Add(this.btnMedia);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(253, 618);
            this.panelSideMenu.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 268);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(253, 49);
            this.button1.TabIndex = 10;
            this.button1.Text = "Peluqueria";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.btnPlaylist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPlaylist.FlatAppearance.BorderSize = 0;
            this.btnPlaylist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPlaylist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.btnPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaylist.ForeColor = System.Drawing.Color.Black;
            this.btnPlaylist.Image = global::PlayerUI.Properties.Resources.pngwing_com__2___1_;
            this.btnPlaylist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlaylist.Location = new System.Drawing.Point(0, 219);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnPlaylist.Size = new System.Drawing.Size(253, 49);
            this.btnPlaylist.TabIndex = 3;
            this.btnPlaylist.Text = " Productos";
            this.btnPlaylist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlaylist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlaylist.UseVisualStyleBackColor = false;
            this.btnPlaylist.Click += new System.EventHandler(this.btnPlaylist_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1234, 618);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMediaSubMenu.ResumeLayout(false);
            this.panelSideMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMedia;
        private System.Windows.Forms.Panel panelMediaSubMenu;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPlaylist;
    }
}

