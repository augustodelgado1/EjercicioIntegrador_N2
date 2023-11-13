namespace View
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            button1 = new Button();
            cmbFilter = new ComboBox();
            txtBuscar = new TextBox();
            btnGuardarArchivo = new Button();
            btnCargar = new Button();
            btnInfo = new Button();
            dgtvList = new DataGridView();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgtvList).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(687, 138);
            button1.Name = "button1";
            button1.Size = new Size(148, 29);
            button1.TabIndex = 34;
            button1.Text = "Cargar Archivo";
            button1.UseVisualStyleBackColor = true;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(687, 68);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(148, 25);
            cmbFilter.TabIndex = 33;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBuscar.Location = new Point(12, 33);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar";
            txtBuscar.Size = new Size(669, 29);
            txtBuscar.TabIndex = 32;
            // 
            // btnGuardarArchivo
            // 
            btnGuardarArchivo.Location = new Point(687, 208);
            btnGuardarArchivo.Name = "btnGuardarArchivo";
            btnGuardarArchivo.Size = new Size(148, 28);
            btnGuardarArchivo.TabIndex = 31;
            btnGuardarArchivo.Text = "Guardar en un Archivo";
            btnGuardarArchivo.UseVisualStyleBackColor = true;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(687, 173);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(148, 29);
            btnCargar.TabIndex = 30;
            btnCargar.Text = "Cargar Archivo";
            btnCargar.UseVisualStyleBackColor = true;
            // 
            // btnInfo
            // 
            btnInfo.Location = new Point(687, 352);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(148, 31);
            btnInfo.TabIndex = 29;
            btnInfo.Text = "Mostrar Informacion";
            btnInfo.UseVisualStyleBackColor = true;
            // 
            // dgtvList
            // 
            dgtvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgtvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgtvList.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            dgtvList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgtvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgtvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgtvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtvList.ImeMode = ImeMode.NoControl;
            dgtvList.Location = new Point(12, 68);
            dgtvList.MultiSelect = false;
            dgtvList.Name = "dgtvList";
            dgtvList.ReadOnly = true;
            dgtvList.RowHeadersVisible = false;
            dgtvList.RowTemplate.Height = 25;
            dgtvList.ScrollBars = ScrollBars.None;
            dgtvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgtvList.Size = new Size(669, 315);
            dgtvList.TabIndex = 28;
            dgtvList.CellContentClick += dgtvList_CellContentClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(687, 315);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(148, 31);
            btnEliminar.TabIndex = 27;
            btnEliminar.Text = "Eliminar Cliente";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.AutoEllipsis = true;
            btnModificar.BackColor = SystemColors.ActiveCaption;
            btnModificar.FlatStyle = FlatStyle.System;
            btnModificar.Location = new Point(687, 278);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(148, 31);
            btnModificar.TabIndex = 26;
            btnModificar.Text = "Modificar Cliente";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(687, 241);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(148, 31);
            btnAgregar.TabIndex = 25;
            btnAgregar.Text = "Agregar Cliente";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 388);
            Controls.Add(button1);
            Controls.Add(cmbFilter);
            Controls.Add(txtBuscar);
            Controls.Add(btnGuardarArchivo);
            Controls.Add(btnCargar);
            Controls.Add(btnInfo);
            Controls.Add(dgtvList);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgtvList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox cmbFilter;
        private TextBox txtBuscar;
        private Button btnGuardarArchivo;
        private Button btnCargar;
        private Button btnInfo;
        private DataGridView dgtvList;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
    }
}