namespace TallerMecanico
{
    partial class FrmListar
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgtvList = new DataGridView();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            btnInfo = new Button();
            btnCargar = new Button();
            btnGuardarArchivo = new Button();
            txtBuscar = new TextBox();
            cmbFilter = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgtvList).BeginInit();
            SuspendLayout();
            // 
            // dgtvList
            // 
            dgtvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgtvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgtvList.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            dgtvList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgtvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgtvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgtvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtvList.ImeMode = ImeMode.NoControl;
            dgtvList.Location = new Point(161, 83);
            dgtvList.MultiSelect = false;
            dgtvList.Name = "dgtvList";
            dgtvList.ReadOnly = true;
            dgtvList.RowHeadersVisible = false;
            dgtvList.RowTemplate.Height = 25;
            dgtvList.ScrollBars = ScrollBars.None;
            dgtvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgtvList.Size = new Size(669, 315);
            dgtvList.TabIndex = 18;
            dgtvList.CellContentClick += dgtvList_CellContentClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(7, 330);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(148, 31);
            btnEliminar.TabIndex = 17;
            btnEliminar.Text = "Eliminar Cliente";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.AutoEllipsis = true;
            btnModificar.BackColor = SystemColors.ActiveCaption;
            btnModificar.FlatStyle = FlatStyle.System;
            btnModificar.Location = new Point(7, 293);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(148, 31);
            btnModificar.TabIndex = 16;
            btnModificar.Text = "Modificar Cliente";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += BtnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(7, 256);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(148, 31);
            btnAgregar.TabIndex = 15;
            btnAgregar.Text = "Agregar Cliente";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnInfo
            // 
            btnInfo.Location = new Point(7, 367);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(148, 31);
            btnInfo.TabIndex = 19;
            btnInfo.Text = "Mostrar Informacion";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(7, 188);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(148, 29);
            btnCargar.TabIndex = 20;
            btnCargar.Text = "Cargar Archivo";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnGuardarArchivo
            // 
            btnGuardarArchivo.Location = new Point(7, 223);
            btnGuardarArchivo.Name = "btnGuardarArchivo";
            btnGuardarArchivo.Size = new Size(148, 28);
            btnGuardarArchivo.TabIndex = 21;
            btnGuardarArchivo.Text = "Guardar en un Archivo";
            btnGuardarArchivo.UseVisualStyleBackColor = true;
            btnGuardarArchivo.Click += btnGuardarArchivo_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBuscar.Location = new Point(161, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar";
            txtBuscar.Size = new Size(669, 29);
            txtBuscar.TabIndex = 22;
            txtBuscar.TextChanged += textBox1_TextChanged;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(692, 52);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(138, 25);
            cmbFilter.TabIndex = 23;
            // 
            // FrmListar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 410);
            Controls.Add(cmbFilter);
            Controls.Add(txtBuscar);
            Controls.Add(btnGuardarArchivo);
            Controls.Add(btnCargar);
            Controls.Add(btnInfo);
            Controls.Add(dgtvList);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Name = "FrmListar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmListar";
            ((System.ComponentModel.ISupportInitialize)dgtvList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private DataGridView dgtvList;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private Button btnInfo;
        private Button btnCargar;
        private Button btnGuardarArchivo;
        private TextBox txtBuscar;
        private ComboBox cmbFilter;
        protected DataGridView DgtvList { get => dgtvList; }
    }
}