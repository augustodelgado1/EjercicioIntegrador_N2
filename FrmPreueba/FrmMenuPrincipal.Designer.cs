namespace TallerMecanico
{
    partial class FrmMenuPrincipal
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
            lblTitulo = new Label();
            btnInicio = new Button();
            btnClientes = new Button();
            btnServicio = new Button();
            btnVehiculos = new Button();
            panelContenedor = new Panel();
            panel1 = new Panel();
            btnSalir = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(320, 11);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(147, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Taller Mecanico";
            // 
            // btnInicio
            // 
            btnInicio.FlatStyle = FlatStyle.System;
            btnInicio.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnInicio.Location = new Point(27, 44);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(119, 30);
            btnInicio.TabIndex = 4;
            btnInicio.Text = "Inicio";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnClientes
            // 
            btnClientes.FlatStyle = FlatStyle.System;
            btnClientes.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClientes.Location = new Point(180, 44);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(125, 30);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnServicio
            // 
            btnServicio.FlatStyle = FlatStyle.System;
            btnServicio.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnServicio.Location = new Point(340, 44);
            btnServicio.Name = "btnServicio";
            btnServicio.Size = new Size(118, 30);
            btnServicio.TabIndex = 1;
            btnServicio.Text = "Servicio";
            btnServicio.UseVisualStyleBackColor = true;
            btnServicio.Click += btnServicio_Click;
            // 
            // btnVehiculos
            // 
            btnVehiculos.FlatStyle = FlatStyle.System;
            btnVehiculos.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnVehiculos.Location = new Point(491, 44);
            btnVehiculos.Name = "btnVehiculos";
            btnVehiculos.Size = new Size(117, 30);
            btnVehiculos.TabIndex = 2;
            btnVehiculos.Text = "Vehiculos";
            btnVehiculos.UseVisualStyleBackColor = true;
            btnVehiculos.Click += btnVehiculos_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 77);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(800, 373);
            panelContenedor.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnClientes);
            panel1.Controls.Add(btnVehiculos);
            panel1.Controls.Add(btnServicio);
            panel1.Controls.Add(btnInicio);
            panel1.Controls.Add(lblTitulo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 77);
            panel1.TabIndex = 2;
            // 
            // btnSalir
            // 
            btnSalir.FlatStyle = FlatStyle.System;
            btnSalir.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalir.Location = new Point(643, 44);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(118, 30);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenedor);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMenuPrincipal";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblTitulo;
        private Button btnVehiculos;
        private Button btnServicio;
        private Button btnClientes;
        private Button btnInicio;
        private Panel panelContenedor;
        private Panel panel1;
        private Button btnSalir;
    }
}