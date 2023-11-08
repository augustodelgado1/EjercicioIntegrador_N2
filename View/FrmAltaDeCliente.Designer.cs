namespace View
{
    partial class FrmAltaDePersona
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
            txtDni = new TextBox();
            DateFechaDeNacimiento = new DateTimePicker();
            lbltxtFechaDeNacimiento = new Label();
            btnIngresar = new Button();
            lb_Fallas = new Label();
            txtClave = new TextBox();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(53, 80);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(163, 27);
            txtNombre.TabIndex = 2;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtDni.Location = new Point(53, 113);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "Dni";
            txtDni.Size = new Size(163, 27);
            txtDni.TabIndex = 4;
            txtDni.TextChanged += txtDni_TextChanged;
            // 
            // DateFechaDeNacimiento
            // 
            DateFechaDeNacimiento.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            DateFechaDeNacimiento.Location = new Point(53, 161);
            DateFechaDeNacimiento.Name = "DateFechaDeNacimiento";
            DateFechaDeNacimiento.Size = new Size(163, 25);
            DateFechaDeNacimiento.TabIndex = 5;
            DateFechaDeNacimiento.ValueChanged += DateFechaDeNacimiento_ValueChanged;
            // 
            // lbltxtFechaDeNacimiento
            // 
            lbltxtFechaDeNacimiento.AutoSize = true;
            lbltxtFechaDeNacimiento.Location = new Point(52, 143);
            lbltxtFechaDeNacimiento.Name = "lbltxtFechaDeNacimiento";
            lbltxtFechaDeNacimiento.Size = new Size(123, 15);
            lbltxtFechaDeNacimiento.TabIndex = 6;
            lbltxtFechaDeNacimiento.Text = "Fecha De Nacimiento:";
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(52, 264);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(162, 35);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lb_Fallas
            // 
            lb_Fallas.AutoSize = true;
            lb_Fallas.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Fallas.ForeColor = Color.Red;
            lb_Fallas.Location = new Point(54, 244);
            lb_Fallas.Name = "lb_Fallas";
            lb_Fallas.Size = new Size(46, 17);
            lb_Fallas.TabIndex = 8;
            lb_Fallas.Text = "label1";
            // 
            // txtClave
            // 
            txtClave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtClave.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(54, 45);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '•';
            txtClave.PlaceholderText = "Clave";
            txtClave.Size = new Size(163, 27);
            txtClave.TabIndex = 21;
            txtClave.TextChanged += txtClave_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(54, 12);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(163, 27);
            txtEmail.TabIndex = 20;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // FrmAltaDeCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 311);
            Controls.Add(txtClave);
            Controls.Add(txtEmail);
            Controls.Add(lb_Fallas);
            Controls.Add(btnIngresar);
            Controls.Add(lbltxtFechaDeNacimiento);
            Controls.Add(DateFechaDeNacimiento);
            Controls.Add(txtDni);
            Controls.Add(txtNombre);
            Name = "FrmAltaDeCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAltaDeCliente";
            Load += FrmAltaDeCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNombre;
        private TextBox txtDni;
        private DateTimePicker DateFechaDeNacimiento;
        private Label lbltxtFechaDeNacimiento;
        private Button btnIngresar;
        private Label lb_Fallas;
        private TextBox txtClave;
        private TextBox txtEmail;
    }
}