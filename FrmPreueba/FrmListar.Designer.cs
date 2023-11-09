namespace TallerMecanico
{
    abstract partial class FrmListar<T>
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
            ((System.ComponentModel.ISupportInitialize)dgtvList).BeginInit();
            SuspendLayout();
            // 
            // dgtvList
            // 
            dgtvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dgtvList.Location = new Point(161, 33);
            dgtvList.MultiSelect = false;
            dgtvList.Name = "dgtvList";
            dgtvList.ReadOnly = true;
            dgtvList.RowHeadersVisible = false;
            dgtvList.RowTemplate.Height = 25;
            dgtvList.ScrollBars = ScrollBars.None;
            dgtvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgtvList.Size = new Size(671, 341);
            dgtvList.TabIndex = 18;
            dgtvList.CellContentClick += dgtvList_CellContentClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(7, 306);
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
            btnModificar.Location = new Point(7, 269);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(148, 31);
            btnModificar.TabIndex = 16;
            btnModificar.Text = "Modificar Cliente";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += BtnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(7, 232);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(148, 31);
            btnAgregar.TabIndex = 15;
            btnAgregar.Text = "Agregar Cliente";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnInfo
            // 
            btnInfo.Location = new Point(7, 343);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(148, 31);
            btnInfo.TabIndex = 19;
            btnInfo.Text = "Mostrar Informacion";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(7, 164);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(148, 29);
            btnCargar.TabIndex = 20;
            btnCargar.Text = "Cargar Clientes";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnGuardarArchivo
            // 
            btnGuardarArchivo.Location = new Point(7, 199);
            btnGuardarArchivo.Name = "btnGuardarArchivo";
            btnGuardarArchivo.Size = new Size(148, 28);
            btnGuardarArchivo.TabIndex = 21;
            btnGuardarArchivo.Text = "Guardar en un Archivo";
            btnGuardarArchivo.UseVisualStyleBackColor = true;
            btnGuardarArchivo.Click += btnGuardarArchivo_Click;
            // 
            // FrmListar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 388);
            this.Load += FrmListar_Load;
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
        }

      




        #endregion

        protected DataGridView dgtvList;
        protected Button btnEliminar;
        protected Button btnModificar;
        protected Button btnAgregar;
        protected Button btnInfo;
        protected Button btnCargar;
        protected Button btnGuardarArchivo;

    }
}