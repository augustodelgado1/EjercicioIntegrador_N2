namespace Interfaz
{
    partial class FrmCrearUsuario
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
            lbl_Titulo = new Label();
            txtClave = new TextBox();
            txtEmail = new TextBox();
            btnAceptar = new Button();
            txtUser = new TextBox();
            txtConfirmarClave = new TextBox();
            lbl_error = new Label();
            SuspendLayout();
            // 
            // lbl_Titulo
            // 
            lbl_Titulo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Titulo.AutoSize = true;
            lbl_Titulo.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Titulo.Location = new Point(144, 24);
            lbl_Titulo.Name = "lbl_Titulo";
            lbl_Titulo.Size = new Size(107, 28);
            lbl_Titulo.TabIndex = 17;
            lbl_Titulo.Text = "Registrarse";
            // 
            // txtClave
            // 
            txtClave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtClave.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(17, 101);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '•';
            txtClave.PlaceholderText = "Clave";
            txtClave.Size = new Size(376, 32);
            txtClave.TabIndex = 16;
            txtClave.TextChanged += txtClave_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(17, 178);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(376, 32);
            txtEmail.TabIndex = 15;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptar.Location = new Point(144, 250);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(98, 32);
            btnAceptar.TabIndex = 12;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtUser
            // 
            txtUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtUser.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtUser.Location = new Point(17, 63);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Usuario";
            txtUser.Size = new Size(376, 32);
            txtUser.TabIndex = 18;
            txtUser.TextChanged += txtUser_TextChanged;
            // 
            // txtConfirmarClave
            // 
            txtConfirmarClave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtConfirmarClave.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtConfirmarClave.Location = new Point(17, 140);
            txtConfirmarClave.Name = "txtConfirmarClave";
            txtConfirmarClave.PasswordChar = '•';
            txtConfirmarClave.PlaceholderText = "Confirmar Clave";
            txtConfirmarClave.Size = new Size(376, 32);
            txtConfirmarClave.TabIndex = 19;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_error.Location = new Point(16, 229);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(50, 20);
            lbl_error.TabIndex = 20;
            lbl_error.Text = "label1";
            // 
            // FrmCrearUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 317);
            Controls.Add(lbl_error);
            Controls.Add(txtConfirmarClave);
            Controls.Add(txtUser);
            Controls.Add(lbl_Titulo);
            Controls.Add(txtClave);
            Controls.Add(txtEmail);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmCrearUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCrearUsuario";
            Load += FrmCrearUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Titulo;
        private TextBox txtClave;
        private TextBox txtEmail;
        private Button btnAceptar;
        private TextBox txtUser;
        private TextBox txtConfirmarClave;
        private Label lbl_error;
    }
}