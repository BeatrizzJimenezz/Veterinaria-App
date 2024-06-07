namespace Base___V1
{
    partial class MenuAdministracion
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
            panel3 = new Panel();
            tblPacientes = new DataGridView();
            Num = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            FechaIngreso = new DataGridViewTextBoxColumn();
            btnVerPaciente = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblPacientes).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(32, 42, 64);
            panel3.Controls.Add(tblPacientes);
            panel3.Location = new Point(12, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(855, 530);
            panel3.TabIndex = 6;
            // 
            // tblPacientes
            // 
            tblPacientes.AllowUserToOrderColumns = true;
            tblPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tblPacientes.BackgroundColor = Color.FromArgb(158, 161, 176);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tblPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tblPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblPacientes.Columns.AddRange(new DataGridViewColumn[] { Num, Nombre, FechaIngreso });
            tblPacientes.Dock = DockStyle.Fill;
            tblPacientes.GridColor = Color.FromArgb(158, 161, 176);
            tblPacientes.Location = new Point(0, 0);
            tblPacientes.Name = "tblPacientes";
            tblPacientes.RowHeadersWidth = 51;
            tblPacientes.Size = new Size(855, 530);
            tblPacientes.TabIndex = 0;
            // 
            // Num
            // 
            Num.HeaderText = "Responsable";
            Num.MinimumWidth = 6;
            Num.Name = "Num";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Paciente";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            // 
            // FechaIngreso
            // 
            FechaIngreso.HeaderText = "Fecha de Ingreso";
            FechaIngreso.MinimumWidth = 6;
            FechaIngreso.Name = "FechaIngreso";
            // 
            // btnVerPaciente
            // 
            btnVerPaciente.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVerPaciente.BackColor = Color.FromArgb(0, 126, 249);
            btnVerPaciente.FlatAppearance.BorderSize = 0;
            btnVerPaciente.FlatStyle = FlatStyle.Flat;
            btnVerPaciente.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerPaciente.ForeColor = Color.White;
            btnVerPaciente.Location = new Point(767, 551);
            btnVerPaciente.Name = "btnVerPaciente";
            btnVerPaciente.Size = new Size(100, 30);
            btnVerPaciente.TabIndex = 7;
            btnVerPaciente.Text = "Ver\r\n";
            btnVerPaciente.UseVisualStyleBackColor = false;
            btnVerPaciente.Click += btnVerPaciente_Click;
            // 
            // AdminLayer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(882, 593);
            Controls.Add(btnVerPaciente);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(882, 593);
            Name = "AdminLayer";
            Text = "Pantalla2";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tblPacientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Button btnVerPaciente;
        private DataGridView tblPacientes;
        private DataGridViewTextBoxColumn Num;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn FechaIngreso;
    }
}