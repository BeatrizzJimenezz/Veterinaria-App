namespace Base___V1
{
    partial class WidgetVacuna
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lblNombreVacuna = new Label();
            lblFecha = new Label();
            label2 = new Label();
            label4 = new Label();
            lblDoctor = new Label();
            panel1 = new Panel();
            lblRevacunacion = new Label();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 126, 249);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(173, 23);
            label1.TabIndex = 0;
            label1.Text = "Fecha de Aplicación:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombreVacuna
            // 
            lblNombreVacuna.AutoSize = true;
            lblNombreVacuna.Font = new Font("Nirmala UI", 22F, FontStyle.Bold);
            lblNombreVacuna.ForeColor = Color.White;
            lblNombreVacuna.Location = new Point(34, 80);
            lblNombreVacuna.Name = "lblNombreVacuna";
            lblNombreVacuna.Size = new Size(290, 50);
            lblNombreVacuna.TabIndex = 5;
            lblNombreVacuna.Text = "NombreVacuna";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Nirmala UI", 12F, FontStyle.Bold | FontStyle.Italic);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(103, 23);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(138, 28);
            lblFecha.TabIndex = 6;
            lblFecha.Text = "19 de Agosto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 126, 249);
            label2.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 157);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(198, 23);
            label2.TabIndex = 8;
            label2.Text = "Fecha de Revacunación:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Nirmala UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(151, 233);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(38, 28);
            label4.TabIndex = 9;
            label4.Text = "Dr.";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Nirmala UI", 12F, FontStyle.Bold | FontStyle.Italic);
            lblDoctor.ForeColor = Color.White;
            lblDoctor.Location = new Point(195, 233);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(151, 28);
            lblDoctor.TabIndex = 10;
            lblDoctor.Text = "Pedrito Alonso";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 126, 249);
            panel1.Location = new Point(10, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(342, 5);
            panel1.TabIndex = 11;
            // 
            // lblRevacunacion
            // 
            lblRevacunacion.AutoSize = true;
            lblRevacunacion.Font = new Font("Nirmala UI", 12F, FontStyle.Bold | FontStyle.Italic);
            lblRevacunacion.ForeColor = Color.White;
            lblRevacunacion.Location = new Point(103, 180);
            lblRevacunacion.Name = "lblRevacunacion";
            lblRevacunacion.Size = new Size(138, 28);
            lblRevacunacion.TabIndex = 12;
            lblRevacunacion.Text = "19 de Agosto";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 126, 249);
            panel2.Location = new Point(10, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(342, 5);
            panel2.TabIndex = 12;
            // 
            // WidgetVacuna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            Controls.Add(panel2);
            Controls.Add(lblRevacunacion);
            Controls.Add(panel1);
            Controls.Add(lblDoctor);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(lblFecha);
            Controls.Add(lblNombreVacuna);
            Controls.Add(label1);
            Name = "WidgetVacuna";
            Size = new Size(363, 261);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblNombreVacuna;
        private Label lblFecha;
        private Label label2;
        private Label label4;
        private Label lblDoctor;
        private Panel panel1;
        private Label lblRevacunacion;
        private Panel panel2;
    }
}
