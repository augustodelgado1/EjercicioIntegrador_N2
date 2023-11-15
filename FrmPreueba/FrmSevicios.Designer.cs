namespace FrmPreueba
{
    partial class FrmSevicios
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
            SuspendLayout();
            btnTerminarServicio = new Button();
            btnTerminarServicio.Location = new Point(606, 138);
            btnTerminarServicio.Name = "btnTerminarServicio";
            btnTerminarServicio.Size = new Size(148, 29);
            btnTerminarServicio.TabIndex = 34;
            btnTerminarServicio.Text = "Terminar Servicio";
            btnTerminarServicio.Click += BtnTerminarServicio_Click;
            btnTerminarServicio.UseVisualStyleBackColor = true;

            // 
            // FrmSevicios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 390);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSevicios";
            Text = "FrmSevicios";
            this.Controls.Add(btnTerminarServicio);
            ResumeLayout(false);


            
        }

        

        private Button btnTerminarServicio;
        #endregion
    }
}