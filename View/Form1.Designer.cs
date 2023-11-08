namespace View
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtClave = new TextBox();
            txtEmail = new TextBox();
            lb_Fallas = new Label();
            btnIngresar = new Button();
            lbltxtFechaDeNacimiento = new Label();
            DateFechaDeNacimiento = new DateTimePicker();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            SuspendLayout();
            // 
            // txtClave
            // 
            txtClave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtClave.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(336, 92);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '•';
            txtClave.PlaceholderText = "Clave";
            txtClave.Size = new Size(163, 27);
            txtClave.TabIndex = 29;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(336, 59);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(163, 27);
            txtEmail.TabIndex = 28;
            // 
            // lb_Fallas
            // 
            lb_Fallas.AutoSize = true;
            lb_Fallas.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Fallas.ForeColor = Color.Red;
            lb_Fallas.Location = new Point(336, 291);
            lb_Fallas.Name = "lb_Fallas";
            lb_Fallas.Size = new Size(46, 17);
            lb_Fallas.TabIndex = 27;
            lb_Fallas.Text = "label1";
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(334, 311);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(162, 35);
            btnIngresar.TabIndex = 26;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            // 
            // lbltxtFechaDeNacimiento
            // 
            lbltxtFechaDeNacimiento.AutoSize = true;
            lbltxtFechaDeNacimiento.Location = new Point(334, 190);
            lbltxtFechaDeNacimiento.Name = "lbltxtFechaDeNacimiento";
            lbltxtFechaDeNacimiento.Size = new Size(123, 15);
            lbltxtFechaDeNacimiento.TabIndex = 25;
            lbltxtFechaDeNacimiento.Text = "Fecha De Nacimiento:";
            // 
            // DateFechaDeNacimiento
            // 
            DateFechaDeNacimiento.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            DateFechaDeNacimiento.Location = new Point(335, 208);
            DateFechaDeNacimiento.Name = "DateFechaDeNacimiento";
            DateFechaDeNacimiento.Size = new Size(163, 25);
            DateFechaDeNacimiento.TabIndex = 24;
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtDni.Location = new Point(335, 160);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "Dni";
            txtDni.Size = new Size(163, 27);
            txtDni.TabIndex = 23;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(335, 127);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(163, 27);
            txtNombre.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 404);
            Controls.Add(txtClave);
            Controls.Add(txtEmail);
            Controls.Add(lb_Fallas);
            Controls.Add(btnIngresar);
            Controls.Add(lbltxtFechaDeNacimiento);
            Controls.Add(DateFechaDeNacimiento);
            Controls.Add(txtDni);
            Controls.Add(txtNombre);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtClave;
        private TextBox txtEmail;
        private Label lb_Fallas;
        private Button btnIngresar;
        private Label lbltxtFechaDeNacimiento;
        private DateTimePicker DateFechaDeNacimiento;
        private TextBox txtDni;
        private TextBox txtNombre;
    }
}