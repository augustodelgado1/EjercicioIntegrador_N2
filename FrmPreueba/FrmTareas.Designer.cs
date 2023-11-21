using Entidades;

namespace FrmPreueba
{
    partial class FrmTareas
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
            progressBar1 = new ProgressBar();
            btnIniciarServicio = new Button();
            btnCancelarServicio = new Button();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(66, 415);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(667, 23);
            progressBar1.TabIndex = 36;
            // 
            // progressBar2
            // 

            // 
            // FrmTareas
            // 
            // 
            // btnIniciarServicio
            // 
            btnIniciarServicio.Location = btnModificar.Location;
            btnIniciarServicio.Name = "btnIniciarServicio";
            btnIniciarServicio.Size = new Size(148, 31);
            btnIniciarServicio.TabIndex = 25;
            btnIniciarServicio.Text = "Atender Servicio";
            btnIniciarServicio.UseVisualStyleBackColor = true;
            btnIniciarServicio.Click += BtnIniciarServicio_Click;
            //
            //
            //
            btnCancelarServicio.Location = btnEliminar.Location;
            btnCancelarServicio.Name = "btnCancelarServicio";
            btnCancelarServicio.Size = new Size(148, 31);
            btnCancelarServicio.TabIndex = 25;
            btnCancelarServicio.Text = "Cancelar Servicio";
            btnCancelarServicio.UseVisualStyleBackColor = true;
            btnCancelarServicio.Click += BtnCancelarServicio_Click; ;
            ///
            //
            //
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 391);
            Controls.Add(btnIniciarServicio);
            Controls.Add(btnCancelarServicio);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmTareas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTareas";
            Load += FrmTareas_Load;
            ResumeLayout(false);
        }

      


        #endregion
        private Button btnIniciarServicio;
        private Button btnCancelarServicio;
        private ProgressBar progressBar1;
    }
}