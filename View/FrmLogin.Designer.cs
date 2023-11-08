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
            lbl_fallas = new Label();
            btnAceptar = new Button();
            btnRegistrarse = new Button();
            txtEmail = new TextBox();
            txtClave = new TextBox();
            lbl_Titulo = new Label();
            SuspendLayout();
            // 
            // lbl_fallas
            // 
            lbl_fallas.AutoSize = true;
            lbl_fallas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_fallas.ForeColor = Color.Red;
            lbl_fallas.Location = new Point(29, 166);
            lbl_fallas.Name = "lbl_fallas";
            lbl_fallas.Size = new Size(0, 21);
            lbl_fallas.TabIndex = 12;
            lbl_fallas.Visible = false;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(24, 211);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(98, 32);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(302, 211);
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
            txtClave.TextChanged += txtClave_TextChanged;
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
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 255);
            Controls.Add(lbl_fallas);
            Controls.Add(lbl_Titulo);
            Controls.Add(txtClave);
            Controls.Add(txtEmail);
            Controls.Add(btnRegistrarse);
            Controls.Add(btnAceptar);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_fallas;
        private Button btnAceptar;
        private Button btnRegistrarse;
        private TextBox txtEmail;
        private TextBox txtClave;
        private Label lbl_Titulo;
    }
}