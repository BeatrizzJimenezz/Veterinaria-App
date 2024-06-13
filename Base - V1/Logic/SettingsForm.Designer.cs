namespace Base___V1.Forms
{
    partial class SettingsForm
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
            txt2 = new TextBox();
            btnAgregar = new Button();
            btnCancelar = new Button();
            txt1 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(72, 27);
            label1.Name = "label1";
            label1.Size = new Size(310, 29);
            label1.TabIndex = 0;
            label1.Text = "Cambio de clave de acceso";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(25, 95);
            label2.Name = "label2";
            label2.Size = new Size(122, 22);
            label2.TabIndex = 1;
            label2.Text = "Clave anterior";
            // 
            // txt2
            // 
            txt2.Location = new Point(221, 95);
            txt2.Name = "txt2";
            txt2.Size = new Size(213, 27);
            txt2.TabIndex = 5;
            txt2.TextAlign = HorizontalAlignment.Right;
            txt2.UseSystemPasswordChar = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAgregar.BackColor = Color.FromArgb(0, 126, 249);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(251, 227);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(170, 30);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnActualizar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.BackColor = Color.Gray;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(35, 227);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(170, 30);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txt1
            // 
            txt1.Location = new Point(221, 159);
            txt1.Name = "txt1";
            txt1.Size = new Size(213, 27);
            txt1.TabIndex = 15;
            txt1.TextAlign = HorizontalAlignment.Right;
            txt1.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(25, 159);
            label3.Name = "label3";
            label3.Size = new Size(109, 22);
            label3.TabIndex = 14;
            label3.Text = "Nueva clave";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 42, 64);
            ClientSize = new Size(460, 269);
            Controls.Add(txt1);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregar);
            Controls.Add(txt2);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "SettingsForm";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "VacunaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txt2;
        private Button btnAgregar;
        private Button btnCancelar;
        private TextBox txt1;
        private Label label3;
    }
}