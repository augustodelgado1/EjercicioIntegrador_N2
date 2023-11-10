namespace View
{
    partial class FrmAltaServicio
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
            txtPatente = new TextBox();
            rtbTextDescripcion = new RichTextBox();
            txtModelo = new TextBox();
            cmbTipoDeVehiculo = new ComboBox();
            cmbMarcaDeVehiculo = new ComboBox();
            lblTipoDeVehiculo = new Label();
            lblMarcaDelVehiculo = new Label();
            lblDescripcion = new Label();
            btnIngresar = new Button();
            btnImagen = new Button();
            lblFallas = new Label();
            SuspendLayout();
            // 
            // txtPatente
            // 
            txtPatente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPatente.Location = new Point(13, 9);
            txtPatente.Name = "txtPatente";
            txtPatente.PlaceholderText = "Patente";
            txtPatente.Size = new Size(243, 29);
            txtPatente.TabIndex = 0;
            txtPatente.TextChanged += txtPatente_TextChanged;
            // 
            // rtbTextDescripcion
            // 
            rtbTextDescripcion.Location = new Point(13, 215);
            rtbTextDescripcion.Name = "rtbTextDescripcion";
            rtbTextDescripcion.Size = new Size(243, 86);
            rtbTextDescripcion.TabIndex = 1;
            rtbTextDescripcion.Text = "";
            rtbTextDescripcion.TextChanged += richTextBox1_TextChanged;
            // 
            // txtModelo
            // 
            txtModelo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtModelo.Location = new Point(13, 44);
            txtModelo.Name = "txtModelo";
            txtModelo.PlaceholderText = "Modelo";
            txtModelo.Size = new Size(243, 29);
            txtModelo.TabIndex = 2;
            txtModelo.TextChanged += txtModelo_TextChanged;
            // 
            // cmbTipoDeVehiculo
            // 
            cmbTipoDeVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDeVehiculo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTipoDeVehiculo.FormattingEnabled = true;
            cmbTipoDeVehiculo.Location = new Point(12, 99);
            cmbTipoDeVehiculo.Name = "cmbTipoDeVehiculo";
            cmbTipoDeVehiculo.Size = new Size(243, 28);
            cmbTipoDeVehiculo.TabIndex = 3;
            // 
            // cmbMarcaDeVehiculo
            // 
            cmbMarcaDeVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarcaDeVehiculo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbMarcaDeVehiculo.FormattingEnabled = true;
            cmbMarcaDeVehiculo.Location = new Point(13, 154);
            cmbMarcaDeVehiculo.Name = "cmbMarcaDeVehiculo";
            cmbMarcaDeVehiculo.Size = new Size(243, 28);
            cmbMarcaDeVehiculo.TabIndex = 4;
            cmbMarcaDeVehiculo.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // lblTipoDeVehiculo
            // 
            lblTipoDeVehiculo.AutoSize = true;
            lblTipoDeVehiculo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipoDeVehiculo.Location = new Point(12, 76);
            lblTipoDeVehiculo.Name = "lblTipoDeVehiculo";
            lblTipoDeVehiculo.Size = new Size(122, 20);
            lblTipoDeVehiculo.TabIndex = 5;
            lblTipoDeVehiculo.Text = "Tipo De Vehiculo";
            // 
            // lblMarcaDelVehiculo
            // 
            lblMarcaDelVehiculo.AutoSize = true;
            lblMarcaDelVehiculo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblMarcaDelVehiculo.Location = new Point(13, 131);
            lblMarcaDelVehiculo.Name = "lblMarcaDelVehiculo";
            lblMarcaDelVehiculo.Size = new Size(137, 20);
            lblMarcaDelVehiculo.TabIndex = 6;
            lblMarcaDelVehiculo.Text = "Marca Del Vehiculo";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcion.Location = new Point(12, 192);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(182, 20);
            lblDescripcion.TabIndex = 7;
            lblDescripcion.Text = "Descripcion Del Problema";
            // 
            // btnIngresar
            // 
            btnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnIngresar.Location = new Point(85, 392);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(109, 36);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnImagen
            // 
            btnImagen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnImagen.Location = new Point(12, 307);
            btnImagen.Name = "btnImagen";
            btnImagen.Size = new Size(246, 39);
            btnImagen.TabIndex = 9;
            btnImagen.Text = "Insertar Imagen Del Vehiculo";
            btnImagen.UseVisualStyleBackColor = true;
            btnImagen.Click += btnImagen_Click;
            // 
            // lblFallas
            // 
            lblFallas.AutoSize = true;
            lblFallas.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblFallas.Location = new Point(12, 358);
            lblFallas.Name = "lblFallas";
            lblFallas.Size = new Size(62, 20);
            lblFallas.TabIndex = 10;
            lblFallas.Text = "lblFallas";
            // 
            // FrmAltaServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 440);
            Controls.Add(lblFallas);
            Controls.Add(btnImagen);
            Controls.Add(btnIngresar);
            Controls.Add(lblDescripcion);
            Controls.Add(lblMarcaDelVehiculo);
            Controls.Add(lblTipoDeVehiculo);
            Controls.Add(cmbMarcaDeVehiculo);
            Controls.Add(cmbTipoDeVehiculo);
            Controls.Add(txtModelo);
            Controls.Add(rtbTextDescripcion);
            Controls.Add(txtPatente);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAltaServicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAltaServicio";
            Load += FrmAltaServicio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPatente;
        private RichTextBox rtbTextDescripcion;
        private TextBox txtModelo;
        private ComboBox cmbTipoDeVehiculo;
        private ComboBox cmbMarcaDeVehiculo;
        private Label lblTipoDeVehiculo;
        private Label lblMarcaDelVehiculo;
        private Label lblDescripcion;
        private Button btnIngresar;
        private Button btnImagen;
        private Label lblFallas;
    }
}