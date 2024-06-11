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
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblPacientes).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(32, 42, 64);
            panel3.Controls.Add(tblPacientes);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(855, 560);
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
            tblPacientes.Dock = DockStyle.Fill;
            tblPacientes.GridColor = Color.FromArgb(158, 161, 176);
            tblPacientes.Location = new Point(0, 0);
            tblPacientes.Name = "tblPacientes";
            tblPacientes.RowHeadersWidth = 51;
            tblPacientes.Size = new Size(855, 560);
            tblPacientes.TabIndex = 0;
            tblPacientes.CellClick += tblPacientes_CellClick;
            // 
            // MenuAdministracion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(882, 593);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(882, 593);
            Name = "MenuAdministracion";
            Text = "Pantalla2";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tblPacientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private DataGridView tblPacientes;
    }
}