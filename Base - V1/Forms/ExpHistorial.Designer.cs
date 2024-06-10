namespace Base___V1
{
    partial class ExpHistorial
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
            panel1 = new Panel();
            tblHistorialConsultas = new DataGridView();
            lblNombrePaciente = new Label();
            lblDatosPaciente = new Label();
            btnVerPaciente = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblHistorialConsultas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.DarkCyan;
            panel1.Controls.Add(tblHistorialConsultas);
            panel1.Location = new Point(24, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(1092, 543);
            panel1.TabIndex = 0;
            // 
            // tblHistorialConsultas
            // 
            tblHistorialConsultas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblHistorialConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tblHistorialConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblHistorialConsultas.Location = new Point(0, 0);
            tblHistorialConsultas.Name = "tblHistorialConsultas";
            tblHistorialConsultas.RowHeadersWidth = 51;
            tblHistorialConsultas.Size = new Size(1092, 543);
            tblHistorialConsultas.TabIndex = 0;
            tblHistorialConsultas.CellClick += tblHistorialConsultas_CellClick;
            // 
            // lblNombrePaciente
            // 
            lblNombrePaciente.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombrePaciente.ForeColor = Color.FromArgb(158, 161, 176);
            lblNombrePaciente.Location = new Point(351, 20);
            lblNombrePaciente.Name = "lblNombrePaciente";
            lblNombrePaciente.Size = new Size(389, 42);
            lblNombrePaciente.TabIndex = 67;
            lblNombrePaciente.Text = "Nombre del chucho";
            // 
            // lblDatosPaciente
            // 
            lblDatosPaciente.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosPaciente.ForeColor = Color.FromArgb(158, 161, 176);
            lblDatosPaciente.Location = new Point(24, 20);
            lblDatosPaciente.Name = "lblDatosPaciente";
            lblDatosPaciente.Size = new Size(402, 42);
            lblDatosPaciente.TabIndex = 66;
            lblDatosPaciente.Text = "Historial de consultas:";
            // 
            // btnVerPaciente
            // 
            btnVerPaciente.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVerPaciente.BackColor = Color.FromArgb(0, 126, 249);
            btnVerPaciente.FlatAppearance.BorderSize = 0;
            btnVerPaciente.FlatStyle = FlatStyle.Flat;
            btnVerPaciente.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerPaciente.ForeColor = Color.White;
            btnVerPaciente.Location = new Point(1016, 614);
            btnVerPaciente.Name = "btnVerPaciente";
            btnVerPaciente.Size = new Size(100, 30);
            btnVerPaciente.TabIndex = 68;
            btnVerPaciente.Text = "Ver\r\n";
            btnVerPaciente.UseVisualStyleBackColor = false;
            // 
            // ExpHistorial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 42, 64);
            ClientSize = new Size(1155, 678);
            Controls.Add(btnVerPaciente);
            Controls.Add(lblNombrePaciente);
            Controls.Add(lblDatosPaciente);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1155, 678);
            Name = "ExpHistorial";
            Text = "ExpHistorial";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tblHistorialConsultas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblNombrePaciente;
        private Label lblDatosPaciente;
        private DataGridView tblHistorialConsultas;
        private Button btnVerPaciente;
    }
}