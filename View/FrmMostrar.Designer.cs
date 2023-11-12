namespace View
{
    partial class FrmMostrar
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
            pBxImagen = new PictureBox();
            btnAceptar = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)pBxImagen).BeginInit();
            SuspendLayout();
            // 
            // pBxImagen
            // 
            pBxImagen.BackColor = Color.White;
            pBxImagen.Location = new Point(32, 43);
            pBxImagen.Name = "pBxImagen";
            pBxImagen.Size = new Size(170, 148);
            pBxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pBxImagen.TabIndex = 18;
            pBxImagen.TabStop = false;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(288, 201);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(145, 32);
            btnAceptar.TabIndex = 21;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.Control;
            flowLayoutPanel1.Location = new Point(209, 42);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(502, 149);
            flowLayoutPanel1.TabIndex = 22;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(328, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(71, 30);
            lblTitulo.TabIndex = 23;
            lblTitulo.Text = "label1";
            // 
            // FrmMostrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(751, 245);
            Controls.Add(lblTitulo);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnAceptar);
            Controls.Add(pBxImagen);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMostrar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMostrarcs";
            Load += FrmMostrar_Load;
            ((System.ComponentModel.ISupportInitialize)pBxImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pBxImagen;
        private Button btnAceptar;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblTitulo;
    }
}