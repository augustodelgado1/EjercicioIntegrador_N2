namespace Interfaz
{
    partial class FrmLogin
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
            btnAceptar = new Button();
            btnRegistrarse = new Button();
            txtEmail = new TextBox();
            txtClave = new TextBox();
            lbl_Titulo = new Label();
            lblError = new Label();
            cmboxRol = new ComboBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(24, 231);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(98, 32);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(302, 231);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(98, 32);
            btnRegistrarse.TabIndex = 7;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(24, 66);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(376, 32);
            txtEmail.TabIndex = 9;
            txtEmail.TextChanged += txtUser_TextChanged_1;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(24, 122);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '•';
            txtClave.PlaceholderText = "Clave";
            txtClave.Size = new Size(376, 32);
            txtClave.TabIndex = 10;
            // 
            // lbl_Titulo
            // 
            lbl_Titulo.AutoSize = true;
            lbl_Titulo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Titulo.Location = new Point(125, 20);
            lbl_Titulo.Name = "lbl_Titulo";
            lbl_Titulo.Size = new Size(155, 32);
            lbl_Titulo.TabIndex = 11;
            lbl_Titulo.Text = "Iniciar Secion";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(24, 166);
            lblError.Name = "lblError";
            lblError.Size = new Size(57, 20);
            lblError.TabIndex = 13;
            lblError.Text = "lblError";
            // 
            // cmboxRol
            // 
            cmboxRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmboxRol.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cmboxRol.FormattingEnabled = true;
            cmboxRol.Location = new Point(24, 193);
            cmboxRol.Name = "cmboxRol";
            cmboxRol.Size = new Size(376, 23);
            cmboxRol.TabIndex = 15;
            cmboxRol.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 275);
            Controls.Add(cmboxRol);
            Controls.Add(lblError);
            Controls.Add(lbl_Titulo);
            Controls.Add(txtClave);
            Controls.Add(txtEmail);
            Controls.Add(btnRegistrarse);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAceptar;
        private Button btnRegistrarse;
        private TextBox txtEmail;
        private TextBox txtClave;
        private Label lbl_Titulo;
        private Label lblError;
        private ComboBox cmboxRol;
    }
}