namespace FrmPreueba
{
    partial class FrmDiagnosticar
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
            txtNombre = new TextBox();
            btnIngresar = new Button();
            txtCosto = new TextBox();
            rtbTextDescripcion = new RichTextBox();
            lblDescripcion = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(12, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(255, 27);
            txtNombre.TabIndex = 3;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(70, 316);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(141, 38);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtCosto
            // 
            txtCosto.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtCosto.Location = new Point(12, 60);
            txtCosto.Name = "txtCosto";
            txtCosto.PlaceholderText = "Costo";
            txtCosto.Size = new Size(255, 27);
            txtCosto.TabIndex = 5;
            // 
            // rtbTextDescripcion
            // 
            rtbTextDescripcion.Location = new Point(12, 130);
            rtbTextDescripcion.Name = "rtbTextDescripcion";
            rtbTextDescripcion.Size = new Size(255, 93);
            rtbTextDescripcion.TabIndex = 6;
            rtbTextDescripcion.Text = "";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcion.Location = new Point(12, 106);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(91, 21);
            lblDescripcion.TabIndex = 7;
            lblDescripcion.Text = "Descripcion";
            // 
            // FrmDiagnosticar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 366);
            Controls.Add(lblDescripcion);
            Controls.Add(rtbTextDescripcion);
            Controls.Add(txtCosto);
            Controls.Add(btnIngresar);
            Controls.Add(txtNombre);
            Name = "FrmDiagnosticar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDiagnosticar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Button btnIngresar;
        private TextBox txtCosto;
        private RichTextBox rtbTextDescripcion;
        private Label lblDescripcion;
    }
}