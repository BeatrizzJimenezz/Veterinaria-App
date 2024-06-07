namespace Base___V1
{
    partial class ExpVacunas
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblNombrePaciente = new Label();
            lblDatosPaciente = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = Color.DarkCyan;
            flowLayoutPanel1.Location = new Point(24, 78);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1111, 560);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // lblNombrePaciente
            // 
            lblNombrePaciente.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombrePaciente.ForeColor = Color.FromArgb(158, 161, 176);
            lblNombrePaciente.Location = new Point(337, 21);
            lblNombrePaciente.Name = "lblNombrePaciente";
            lblNombrePaciente.Size = new Size(389, 42);
            lblNombrePaciente.TabIndex = 63;
            lblNombrePaciente.Text = "Nombre del chucho";
            // 
            // lblDatosPaciente
            // 
            lblDatosPaciente.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosPaciente.ForeColor = Color.FromArgb(158, 161, 176);
            lblDatosPaciente.Location = new Point(24, 21);
            lblDatosPaciente.Name = "lblDatosPaciente";
            lblDatosPaciente.Size = new Size(334, 42);
            lblDatosPaciente.TabIndex = 62;
            lblDatosPaciente.Text = "Control de Vacunas:";
            // 
            // ExpVacunas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 42, 64);
            ClientSize = new Size(1155, 678);
            Controls.Add(lblNombrePaciente);
            Controls.Add(lblDatosPaciente);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1155, 678);
            Name = "ExpVacunas";
            Text = "ExpVacunas";
            Load += ExpVacunas_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblNombrePaciente;
        private Label lblDatosPaciente;
    }
}