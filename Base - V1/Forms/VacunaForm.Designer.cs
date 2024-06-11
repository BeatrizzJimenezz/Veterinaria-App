namespace Base___V1.Forms
{
    partial class VacunaForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNombreVacuna = new TextBox();
            dateAplicacion = new DateTimePicker();
            dateProxima = new DateTimePicker();
            txtDr = new TextBox();
            btnAgregar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(116, 27);
            label1.Name = "label1";
            label1.Size = new Size(209, 29);
            label1.TabIndex = 0;
            label1.Text = "Ingreso de vacuna";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(180, 22);
            label2.TabIndex = 1;
            label2.Text = "Nombre de la vacuna";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 151);
            label3.Name = "label3";
            label3.Size = new Size(170, 22);
            label3.TabIndex = 2;
            label3.Text = "Fecha de aplicación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 208);
            label4.Name = "label4";
            label4.Size = new Size(122, 22);
            label4.TabIndex = 3;
            label4.Text = "Proxima docis";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 269);
            label5.Name = "label5";
            label5.Size = new Size(29, 22);
            label5.TabIndex = 4;
            label5.Text = "Dr";
            // 
            // txtNombreVacuna
            // 
            txtNombreVacuna.Location = new Point(208, 96);
            txtNombreVacuna.Name = "txtNombreVacuna";
            txtNombreVacuna.Size = new Size(213, 27);
            txtNombreVacuna.TabIndex = 5;
            txtNombreVacuna.TextAlign = HorizontalAlignment.Right;
            // 
            // dateAplicacion
            // 
            dateAplicacion.Location = new Point(208, 151);
            dateAplicacion.Name = "dateAplicacion";
            dateAplicacion.Size = new Size(213, 27);
            dateAplicacion.TabIndex = 6;
            // 
            // dateProxima
            // 
            dateProxima.Location = new Point(208, 208);
            dateProxima.Name = "dateProxima";
            dateProxima.Size = new Size(213, 27);
            dateProxima.TabIndex = 7;
            // 
            // txtDr
            // 
            txtDr.Location = new Point(68, 264);
            txtDr.Name = "txtDr";
            txtDr.Size = new Size(340, 27);
            txtDr.TabIndex = 8;
            txtDr.TextAlign = HorizontalAlignment.Right;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAgregar.BackColor = Color.FromArgb(0, 126, 249);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(238, 345);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(170, 30);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.BackColor = Color.Gray;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(22, 345);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(170, 30);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // VacunaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 42, 64);
            ClientSize = new Size(460, 398);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregar);
            Controls.Add(txtDr);
            Controls.Add(dateProxima);
            Controls.Add(dateAplicacion);
            Controls.Add(txtNombreVacuna);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "VacunaForm";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "VacunaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNombreVacuna;
        private DateTimePicker dateAplicacion;
        private DateTimePicker dateProxima;
        private TextBox txtDr;
        private Button btnAgregar;
        private Button btnCancelar;
    }
}