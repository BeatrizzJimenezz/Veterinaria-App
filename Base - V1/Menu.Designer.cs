namespace Base___V1
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            panel1 = new Panel();
            PanelNav = new Panel();
            Btn6 = new Button();
            Btn2 = new Button();
            Btn1 = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            PnlFormLoader = new Panel();
            IblTittle = new Label();
            textBox1 = new TextBox();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(PanelNav);
            panel1.Controls.Add(Btn6);
            panel1.Controls.Add(Btn2);
            panel1.Controls.Add(Btn1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 753);
            panel1.TabIndex = 1;
            // 
            // PanelNav
            // 
            PanelNav.BackColor = Color.FromArgb(0, 126, 249);
            PanelNav.Location = new Point(0, 192);
            PanelNav.Name = "PanelNav";
            PanelNav.Size = new Size(3, 100);
            PanelNav.TabIndex = 7;
            // 
            // Btn6
            // 
            Btn6.Dock = DockStyle.Bottom;
            Btn6.FlatAppearance.BorderSize = 0;
            Btn6.FlatStyle = FlatStyle.Flat;
            Btn6.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn6.ForeColor = Color.FromArgb(0, 126, 249);
            Btn6.Image = (Image)resources.GetObject("Btn6.Image");
            Btn6.ImageAlign = ContentAlignment.MiddleRight;
            Btn6.Location = new Point(0, 711);
            Btn6.Name = "Btn6";
            Btn6.Size = new Size(300, 42);
            Btn6.TabIndex = 6;
            Btn6.Text = "Configuracion";
            Btn6.TextImageRelation = TextImageRelation.TextBeforeImage;
            Btn6.UseVisualStyleBackColor = true;
            Btn6.Click += Btn6_Click;
            Btn6.Leave += Btn6_Leave;
            // 
            // Btn2
            // 
            Btn2.Dock = DockStyle.Top;
            Btn2.FlatAppearance.BorderSize = 0;
            Btn2.FlatStyle = FlatStyle.Flat;
            Btn2.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn2.ForeColor = Color.FromArgb(0, 126, 249);
            Btn2.Image = (Image)resources.GetObject("Btn2.Image");
            Btn2.ImageAlign = ContentAlignment.MiddleRight;
            Btn2.Location = new Point(0, 202);
            Btn2.Name = "Btn2";
            Btn2.Size = new Size(300, 42);
            Btn2.TabIndex = 2;
            Btn2.Text = "Agregar paciente";
            Btn2.TextImageRelation = TextImageRelation.TextBeforeImage;
            Btn2.UseVisualStyleBackColor = true;
            Btn2.Click += Btn2_Click;
            Btn2.Leave += Btn2_Leave;
            // 
            // Btn1
            // 
            Btn1.Dock = DockStyle.Top;
            Btn1.FlatAppearance.BorderSize = 0;
            Btn1.FlatStyle = FlatStyle.Flat;
            Btn1.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn1.ForeColor = Color.FromArgb(0, 126, 249);
            Btn1.Image = (Image)resources.GetObject("Btn1.Image");
            Btn1.ImageAlign = ContentAlignment.MiddleRight;
            Btn1.Location = new Point(0, 160);
            Btn1.Name = "Btn1";
            Btn1.Size = new Size(300, 42);
            Btn1.TabIndex = 1;
            Btn1.Text = "Administración";
            Btn1.TextImageRelation = TextImageRelation.TextBeforeImage;
            Btn1.UseVisualStyleBackColor = true;
            Btn1.Click += Btn1_Click;
            Btn1.Leave += Btn1_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 160);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 170);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // PnlFormLoader
            // 
            PnlFormLoader.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PnlFormLoader.Location = new Point(300, 160);
            PnlFormLoader.Name = "PnlFormLoader";
            PnlFormLoader.Size = new Size(882, 593);
            PnlFormLoader.TabIndex = 0;
            // 
            // IblTittle
            // 
            IblTittle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            IblTittle.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IblTittle.ForeColor = Color.FromArgb(158, 161, 176);
            IblTittle.Location = new Point(0, 43);
            IblTittle.Name = "IblTittle";
            IblTittle.Size = new Size(882, 42);
            IblTittle.TabIndex = 7;
            IblTittle.Text = "Administración";
            IblTittle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(74, 79, 99);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(13, 118);
            textBox1.Margin = new Padding(10);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(855, 32);
            textBox1.TabIndex = 8;
            textBox1.Text = "Buscar algo...";
            // 
            // panel3
            // 
            panel3.Controls.Add(IblTittle);
            panel3.Controls.Add(textBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(300, 0);
            panel3.Margin = new Padding(5);
            panel3.Name = "panel3";
            panel3.Size = new Size(882, 160);
            panel3.TabIndex = 7;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1182, 753);
            Controls.Add(panel3);
            Controls.Add(PnlFormLoader);
            Controls.Add(panel1);
            MinimumSize = new Size(1200, 800);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Btn6;
        public Button Btn2;
        private Button Btn1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Panel PnlFormLoader;
        private Label IblTittle;
        private TextBox textBox1;
        private Panel PanelNav;
        private Panel panel3;
    }
}