namespace Base___V1
{
    partial class ExpInfo
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
            ExpInfoPanel = new Panel();
            cbEdicion = new CheckBox();
            txtSeñas = new TextBox();
            txtEdad = new TextBox();
            lblNombrePaciente = new Label();
            label13 = new Label();
            txtTelefono = new TextBox();
            label14 = new Label();
            txtCorreo = new TextBox();
            label11 = new Label();
            txtDireccion = new TextBox();
            label10 = new Label();
            txtNombrePro = new TextBox();
            label8 = new Label();
            cbSexo = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            txtColor = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtRaza = new TextBox();
            txtEspecie = new TextBox();
            lblDatosPaciente = new Label();
            lblDatosPropietario = new Label();
            ExpInfoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ExpInfoPanel
            // 
            ExpInfoPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ExpInfoPanel.BackColor = Color.FromArgb(32, 42, 64);
            ExpInfoPanel.Controls.Add(cbEdicion);
            ExpInfoPanel.Controls.Add(txtSeñas);
            ExpInfoPanel.Controls.Add(txtEdad);
            ExpInfoPanel.Controls.Add(lblNombrePaciente);
            ExpInfoPanel.Controls.Add(label13);
            ExpInfoPanel.Controls.Add(txtTelefono);
            ExpInfoPanel.Controls.Add(label14);
            ExpInfoPanel.Controls.Add(txtCorreo);
            ExpInfoPanel.Controls.Add(label11);
            ExpInfoPanel.Controls.Add(txtDireccion);
            ExpInfoPanel.Controls.Add(label10);
            ExpInfoPanel.Controls.Add(txtNombrePro);
            ExpInfoPanel.Controls.Add(label8);
            ExpInfoPanel.Controls.Add(cbSexo);
            ExpInfoPanel.Controls.Add(label5);
            ExpInfoPanel.Controls.Add(label6);
            ExpInfoPanel.Controls.Add(txtColor);
            ExpInfoPanel.Controls.Add(label7);
            ExpInfoPanel.Controls.Add(label4);
            ExpInfoPanel.Controls.Add(label3);
            ExpInfoPanel.Controls.Add(txtRaza);
            ExpInfoPanel.Controls.Add(txtEspecie);
            ExpInfoPanel.Controls.Add(lblDatosPaciente);
            ExpInfoPanel.Controls.Add(lblDatosPropietario);
            ExpInfoPanel.Location = new Point(0, 0);
            ExpInfoPanel.Name = "ExpInfoPanel";
            ExpInfoPanel.Size = new Size(882, 593);
            ExpInfoPanel.TabIndex = 1;
            ExpInfoPanel.Paint += ExpInfoPanel_Paint;
            // 
            // cbEdicion
            // 
            cbEdicion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbEdicion.AutoSize = true;
            cbEdicion.ForeColor = SystemColors.ButtonFace;
            cbEdicion.Location = new Point(690, 483);
            cbEdicion.Name = "cbEdicion";
            cbEdicion.Size = new Size(142, 24);
            cbEdicion.TabIndex = 65;
            cbEdicion.Text = "Habilitar edicion";
            cbEdicion.UseVisualStyleBackColor = true;
            cbEdicion.CheckedChanged += cbEdicion_CheckedChanged;
            // 
            // txtSeñas
            // 
            txtSeñas.Location = new Point(652, 154);
            txtSeñas.Name = "txtSeñas";
            txtSeñas.Size = new Size(157, 27);
            txtSeñas.TabIndex = 64;
            // 
            // txtEdad
            // 
            txtEdad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtEdad.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEdad.Location = new Point(652, 86);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(159, 30);
            txtEdad.TabIndex = 63;
            // 
            // lblNombrePaciente
            // 
            lblNombrePaciente.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombrePaciente.ForeColor = Color.FromArgb(158, 161, 176);
            lblNombrePaciente.Location = new Point(257, 27);
            lblNombrePaciente.Name = "lblNombrePaciente";
            lblNombrePaciente.Size = new Size(389, 42);
            lblNombrePaciente.TabIndex = 61;
            lblNombrePaciente.Text = "Nombre del chuco";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(577, 429);
            label13.Name = "label13";
            label13.Size = new Size(90, 23);
            label13.TabIndex = 60;
            label13.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTelefono.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(673, 426);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(150, 30);
            txtTelefono.TabIndex = 59;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(18, 429);
            label14.Name = "label14";
            label14.Size = new Size(77, 23);
            label14.TabIndex = 58;
            label14.Text = "Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCorreo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(136, 426);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(424, 30);
            txtCorreo.TabIndex = 57;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(18, 354);
            label11.Name = "label11";
            label11.Size = new Size(97, 23);
            label11.TabIndex = 56;
            label11.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDireccion.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion.Location = new Point(136, 351);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(687, 50);
            txtDireccion.TabIndex = 55;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(18, 300);
            label10.Name = "label10";
            label10.Size = new Size(112, 23);
            label10.TabIndex = 54;
            label10.Text = "Propietario:";
            // 
            // txtNombrePro
            // 
            txtNombrePro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombrePro.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombrePro.Location = new Point(136, 297);
            txtNombrePro.Name = "txtNombrePro";
            txtNombrePro.Size = new Size(687, 30);
            txtNombrePro.TabIndex = 53;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(577, 154);
            label8.Name = "label8";
            label8.Size = new Size(72, 23);
            label8.TabIndex = 50;
            label8.Text = "Señas:";
            // 
            // cbSexo
            // 
            cbSexo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cbSexo.FormattingEnabled = true;
            cbSexo.Items.AddRange(new object[] { "Femenino", "Masculino" });
            cbSexo.Location = new Point(118, 157);
            cbSexo.Name = "cbSexo";
            cbSexo.Size = new Size(152, 28);
            cbSexo.TabIndex = 48;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(305, 160);
            label5.Name = "label5";
            label5.Size = new Size(63, 23);
            label5.TabIndex = 47;
            label5.Text = "Color:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(22, 160);
            label6.Name = "label6";
            label6.Size = new Size(60, 23);
            label6.TabIndex = 46;
            label6.Text = "Sexo:";
            // 
            // txtColor
            // 
            txtColor.Location = new Point(374, 156);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(157, 27);
            txtColor.TabIndex = 62;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(584, 86);
            label7.Name = "label7";
            label7.Size = new Size(62, 23);
            label7.TabIndex = 44;
            label7.Text = "Edad:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(305, 89);
            label4.Name = "label4";
            label4.Size = new Size(61, 23);
            label4.TabIndex = 42;
            label4.Text = "Raza:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 89);
            label3.Name = "label3";
            label3.Size = new Size(86, 23);
            label3.TabIndex = 41;
            label3.Text = "Especie:";
            // 
            // txtRaza
            // 
            txtRaza.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtRaza.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRaza.Location = new Point(372, 86);
            txtRaza.Name = "txtRaza";
            txtRaza.Size = new Size(159, 30);
            txtRaza.TabIndex = 40;
            // 
            // txtEspecie
            // 
            txtEspecie.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtEspecie.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEspecie.Location = new Point(118, 86);
            txtEspecie.Name = "txtEspecie";
            txtEspecie.Size = new Size(152, 30);
            txtEspecie.TabIndex = 39;
            // 
            // lblDatosPaciente
            // 
            lblDatosPaciente.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosPaciente.ForeColor = Color.FromArgb(158, 161, 176);
            lblDatosPaciente.Location = new Point(22, 27);
            lblDatosPaciente.Name = "lblDatosPaciente";
            lblDatosPaciente.Size = new Size(238, 42);
            lblDatosPaciente.TabIndex = 38;
            lblDatosPaciente.Text = "Datos paciente:";
            // 
            // lblDatosPropietario
            // 
            lblDatosPropietario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDatosPropietario.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosPropietario.ForeColor = Color.FromArgb(158, 161, 176);
            lblDatosPropietario.Location = new Point(18, 212);
            lblDatosPropietario.Name = "lblDatosPropietario";
            lblDatosPropietario.Size = new Size(327, 42);
            lblDatosPropietario.TabIndex = 37;
            lblDatosPropietario.Text = "Datos del propietario";
            // 
            // ExpInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(882, 593);
            Controls.Add(ExpInfoPanel);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(882, 593);
            Name = "ExpInfo";
            Text = "ExpInfo";
            ExpInfoPanel.ResumeLayout(false);
            ExpInfoPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel ExpInfoPanel;
        private Label label13;
        private TextBox txtTelefono;
        private Label label14;
        private TextBox txtCorreo;
        private Label label11;
        private TextBox txtDireccion;
        private Label label10;
        private TextBox txtNombrePro;
        private Label label8;
        private ComboBox cbSexo;
        private Label label5;
        private Label label6;
        private TextBox txtColor;
        private Label label7;
        private Label label4;
        private Label label3;
        private TextBox txtRaza;
        private TextBox txtEspecie;
        private Label lblDatosPaciente;
        private Label lblDatosPropietario;
        private Label lblNombrePaciente;
        private TextBox txtSeñas;
        private TextBox txtEdad;
        private CheckBox cbEdicion;
    }
}