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
            cmbDignosticar = new ComboBox();
            lbl_Diagnostico = new Label();
            lblError = new Label();
            txtCotizacion = new TextBox();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // cmbDignosticar
            // 
            cmbDignosticar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDignosticar.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDignosticar.FormattingEnabled = true;
            cmbDignosticar.Location = new Point(71, 30);
            cmbDignosticar.Name = "cmbDignosticar";
            cmbDignosticar.Size = new Size(238, 28);
            cmbDignosticar.TabIndex = 0;
            // 
            // lbl_Diagnostico
            // 
            lbl_Diagnostico.AutoSize = true;
            lbl_Diagnostico.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Diagnostico.Location = new Point(71, 9);
            lbl_Diagnostico.Name = "lbl_Diagnostico";
            lbl_Diagnostico.Size = new Size(92, 18);
            lbl_Diagnostico.TabIndex = 1;
            lbl_Diagnostico.Text = "Diagnostico";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblError.Location = new Point(12, 141);
            lblError.Name = "lblError";
            lblError.Size = new Size(50, 18);
            lblError.TabIndex = 3;
            lblError.Text = "label3";
            // 
            // txtCotizacion
            // 
            txtCotizacion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCotizacion.Location = new Point(71, 77);
            txtCotizacion.Name = "txtCotizacion";
            txtCotizacion.PlaceholderText = "Cotizacion";
            txtCotizacion.Size = new Size(238, 29);
            txtCotizacion.TabIndex = 4;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(123, 191);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(139, 36);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmDiagnosticar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 239);
            Controls.Add(btnAceptar);
            Controls.Add(txtCotizacion);
            Controls.Add(lblError);
            Controls.Add(lbl_Diagnostico);
            Controls.Add(cmbDignosticar);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDiagnosticar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDiagnosticar";
            Load += FrmDiagnosticar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDignosticar;
        private Label lbl_Diagnostico;
        private Label lblError;
        private TextBox txtCotizacion;
        private Button btnAceptar;
    }
}