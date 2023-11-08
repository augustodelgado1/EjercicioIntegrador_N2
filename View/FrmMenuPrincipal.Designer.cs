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
            menuStrip1 = new MenuStrip();
            principalToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            serviciosToolStripMenuItem = new ToolStripMenuItem();
            vehiculosToolStripMenuItem = new ToolStripMenuItem();
            configuracionToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            lbltxtUserText = new Label();
            lbltxtEmailText = new Label();
            label3 = new Label();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { principalToolStripMenuItem, clientesToolStripMenuItem, serviciosToolStripMenuItem, vehiculosToolStripMenuItem, configuracionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // principalToolStripMenuItem
            // 
            principalToolStripMenuItem.Name = "principalToolStripMenuItem";
            principalToolStripMenuItem.Size = new Size(68, 20);
            principalToolStripMenuItem.Text = " Principal";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(61, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // serviciosToolStripMenuItem
            // 
            serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            serviciosToolStripMenuItem.Size = new Size(65, 20);
            serviciosToolStripMenuItem.Text = "Servicios";
            // 
            // vehiculosToolStripMenuItem
            // 
            vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            vehiculosToolStripMenuItem.Size = new Size(69, 20);
            vehiculosToolStripMenuItem.Text = "Vehiculos";
            // 
            // configuracionToolStripMenuItem
            // 
            configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            configuracionToolStripMenuItem.Size = new Size(95, 20);
            configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lbltxtUserText);
            panel1.Controls.Add(lbltxtEmailText);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(678, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(122, 426);
            panel1.TabIndex = 1;
            // 
            // lbltxtUserText
            // 
            lbltxtUserText.AutoSize = true;
            lbltxtUserText.Location = new Point(27, 85);
            lbltxtUserText.Name = "lbltxtUserText";
            lbltxtUserText.Size = new Size(36, 15);
            lbltxtUserText.TabIndex = 0;
            lbltxtUserText.Text = "User: ";
            // 
            // lbltxtEmailText
            // 
            lbltxtEmailText.AutoSize = true;
            lbltxtEmailText.Location = new Point(27, 101);
            lbltxtEmailText.Name = "lbltxtEmailText";
            lbltxtEmailText.Size = new Size(39, 15);
            lbltxtEmailText.TabIndex = 1;
            lbltxtEmailText.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 85);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 101);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMenuPrincipal";
            Text = "FrmMenuPrincipal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem principalToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem serviciosToolStripMenuItem;
        private ToolStripMenuItem configuracionToolStripMenuItem;
        private ToolStripMenuItem vehiculosToolStripMenuItem;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private Label lbltxtEmailText;
        private Label lbltxtUserText;
    }
}