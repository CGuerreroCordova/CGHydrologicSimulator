namespace SimuladorInundaciones
{
    partial class Form1
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
            this.buttonCargarDEM = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonBrowseCapacAlmSuelo = new System.Windows.Forms.Button();
            this.textBoxCapacAlmSuelo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonBrowseConducHSuelo = new System.Windows.Forms.Button();
            this.textBoxConducHidrSuelo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonBrowseProfCapPerm = new System.Windows.Forms.Button();
            this.textBoxProfCapaPermeable = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonBrowseDem = new System.Windows.Forms.Button();
            this.textBoxDEM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonBrowseAguaCapa1 = new System.Windows.Forms.Button();
            this.textBoxOpenAguaPermeable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonBrowseAguaSup = new System.Windows.Forms.Button();
            this.textBoxOpenAguaSuperficial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openFDAguaSuperficial = new System.Windows.Forms.OpenFileDialog();
            this.openFDAguaCapa1 = new System.Windows.Forms.OpenFileDialog();
            this.openFDDEM = new System.Windows.Forms.OpenFileDialog();
            this.openFDProfCapaPermeable = new System.Windows.Forms.OpenFileDialog();
            this.openFDCondHSuelo = new System.Windows.Forms.OpenFileDialog();
            this.openFDCapAlmSuelo = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCargarDEM
            // 
            this.buttonCargarDEM.Location = new System.Drawing.Point(346, 213);
            this.buttonCargarDEM.Name = "buttonCargarDEM";
            this.buttonCargarDEM.Size = new System.Drawing.Size(75, 23);
            this.buttonCargarDEM.TabIndex = 0;
            this.buttonCargarDEM.Text = "Cargar DEM";
            this.buttonCargarDEM.UseVisualStyleBackColor = true;
            this.buttonCargarDEM.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(216, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ancho X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Alto Y";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(35, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(216, 62);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Offset X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Offset Y";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(887, 603);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(879, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos de Entrada";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonBrowseCapacAlmSuelo);
            this.groupBox2.Controls.Add(this.textBoxCapacAlmSuelo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.buttonBrowseConducHSuelo);
            this.groupBox2.Controls.Add(this.textBoxConducHidrSuelo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.buttonBrowseProfCapPerm);
            this.groupBox2.Controls.Add(this.textBoxProfCapaPermeable);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.buttonBrowseDem);
            this.groupBox2.Controls.Add(this.textBoxDEM);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(21, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(836, 265);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Contorno";
            // 
            // buttonBrowseCapacAlmSuelo
            // 
            this.buttonBrowseCapacAlmSuelo.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseCapacAlmSuelo.Location = new System.Drawing.Point(702, 217);
            this.buttonBrowseCapacAlmSuelo.Name = "buttonBrowseCapacAlmSuelo";
            this.buttonBrowseCapacAlmSuelo.Size = new System.Drawing.Size(55, 20);
            this.buttonBrowseCapacAlmSuelo.TabIndex = 15;
            this.buttonBrowseCapacAlmSuelo.Text = "Buscar";
            this.buttonBrowseCapacAlmSuelo.UseVisualStyleBackColor = false;
            this.buttonBrowseCapacAlmSuelo.Click += new System.EventHandler(this.buttonBrowseCapacAlmSuelo_Click);
            // 
            // textBoxCapacAlmSuelo
            // 
            this.textBoxCapacAlmSuelo.Location = new System.Drawing.Point(182, 217);
            this.textBoxCapacAlmSuelo.Name = "textBoxCapacAlmSuelo";
            this.textBoxCapacAlmSuelo.Size = new System.Drawing.Size(497, 20);
            this.textBoxCapacAlmSuelo.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 26);
            this.label10.TabIndex = 13;
            this.label10.Text = "Capacidad Almacenamiento \r\nCapa Permeable";
            // 
            // buttonBrowseConducHSuelo
            // 
            this.buttonBrowseConducHSuelo.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseConducHSuelo.Location = new System.Drawing.Point(702, 160);
            this.buttonBrowseConducHSuelo.Name = "buttonBrowseConducHSuelo";
            this.buttonBrowseConducHSuelo.Size = new System.Drawing.Size(55, 20);
            this.buttonBrowseConducHSuelo.TabIndex = 12;
            this.buttonBrowseConducHSuelo.Text = "Buscar";
            this.buttonBrowseConducHSuelo.UseVisualStyleBackColor = false;
            this.buttonBrowseConducHSuelo.Click += new System.EventHandler(this.buttonBrowseConducHSuelo_Click);
            // 
            // textBoxConducHidrSuelo
            // 
            this.textBoxConducHidrSuelo.Location = new System.Drawing.Point(182, 160);
            this.textBoxConducHidrSuelo.Name = "textBoxConducHidrSuelo";
            this.textBoxConducHidrSuelo.Size = new System.Drawing.Size(497, 20);
            this.textBoxConducHidrSuelo.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Conductividad Hidráulica Suelo";
            // 
            // buttonBrowseProfCapPerm
            // 
            this.buttonBrowseProfCapPerm.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseProfCapPerm.Location = new System.Drawing.Point(702, 102);
            this.buttonBrowseProfCapPerm.Name = "buttonBrowseProfCapPerm";
            this.buttonBrowseProfCapPerm.Size = new System.Drawing.Size(55, 20);
            this.buttonBrowseProfCapPerm.TabIndex = 9;
            this.buttonBrowseProfCapPerm.Text = "Buscar";
            this.buttonBrowseProfCapPerm.UseVisualStyleBackColor = false;
            this.buttonBrowseProfCapPerm.Click += new System.EventHandler(this.buttonBrowseProfCapPerm_Click);
            // 
            // textBoxProfCapaPermeable
            // 
            this.textBoxProfCapaPermeable.Location = new System.Drawing.Point(182, 102);
            this.textBoxProfCapaPermeable.Name = "textBoxProfCapaPermeable";
            this.textBoxProfCapaPermeable.Size = new System.Drawing.Size(497, 20);
            this.textBoxProfCapaPermeable.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Profundidad Capa Permeable";
            // 
            // buttonBrowseDem
            // 
            this.buttonBrowseDem.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseDem.Location = new System.Drawing.Point(702, 42);
            this.buttonBrowseDem.Name = "buttonBrowseDem";
            this.buttonBrowseDem.Size = new System.Drawing.Size(55, 20);
            this.buttonBrowseDem.TabIndex = 6;
            this.buttonBrowseDem.Text = "Buscar";
            this.buttonBrowseDem.UseVisualStyleBackColor = false;
            this.buttonBrowseDem.Click += new System.EventHandler(this.buttonBrowseDem_Click);
            // 
            // textBoxDEM
            // 
            this.textBoxDEM.Location = new System.Drawing.Point(182, 42);
            this.textBoxDEM.Name = "textBoxDEM";
            this.textBoxDEM.Size = new System.Drawing.Size(497, 20);
            this.textBoxDEM.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "DEM";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonBrowseAguaCapa1);
            this.groupBox1.Controls.Add(this.textBoxOpenAguaPermeable);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonBrowseAguaSup);
            this.groupBox1.Controls.Add(this.textBoxOpenAguaSuperficial);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(21, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 224);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Inicialización";
            // 
            // buttonBrowseAguaCapa1
            // 
            this.buttonBrowseAguaCapa1.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseAguaCapa1.Location = new System.Drawing.Point(702, 123);
            this.buttonBrowseAguaCapa1.Name = "buttonBrowseAguaCapa1";
            this.buttonBrowseAguaCapa1.Size = new System.Drawing.Size(55, 20);
            this.buttonBrowseAguaCapa1.TabIndex = 6;
            this.buttonBrowseAguaCapa1.Text = "Buscar";
            this.buttonBrowseAguaCapa1.UseVisualStyleBackColor = false;
            this.buttonBrowseAguaCapa1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // textBoxOpenAguaPermeable
            // 
            this.textBoxOpenAguaPermeable.Location = new System.Drawing.Point(182, 123);
            this.textBoxOpenAguaPermeable.Name = "textBoxOpenAguaPermeable";
            this.textBoxOpenAguaPermeable.Size = new System.Drawing.Size(497, 20);
            this.textBoxOpenAguaPermeable.TabIndex = 5;
            this.textBoxOpenAguaPermeable.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Agua Capa Permeable Inicial";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // buttonBrowseAguaSup
            // 
            this.buttonBrowseAguaSup.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseAguaSup.Location = new System.Drawing.Point(702, 53);
            this.buttonBrowseAguaSup.Name = "buttonBrowseAguaSup";
            this.buttonBrowseAguaSup.Size = new System.Drawing.Size(55, 20);
            this.buttonBrowseAguaSup.TabIndex = 3;
            this.buttonBrowseAguaSup.Text = "Buscar";
            this.buttonBrowseAguaSup.UseVisualStyleBackColor = false;
            this.buttonBrowseAguaSup.Click += new System.EventHandler(this.buttonBrowseAguaSup_Click);
            // 
            // textBoxOpenAguaSuperficial
            // 
            this.textBoxOpenAguaSuperficial.Location = new System.Drawing.Point(182, 53);
            this.textBoxOpenAguaSuperficial.Name = "textBoxOpenAguaSuperficial";
            this.textBoxOpenAguaSuperficial.Size = new System.Drawing.Size(497, 20);
            this.textBoxOpenAguaSuperficial.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Agua Superficial Inicial";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(968, 577);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parámetros de Tiempo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // openFDAguaSuperficial
            // 
            this.openFDAguaSuperficial.Filter = "Archivos de Alturas de Agua (*.agu)|*.agu";
            this.openFDAguaSuperficial.Title = "Archivo de Agua Superficial";
            this.openFDAguaSuperficial.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFDAguaCapa1
            // 
            this.openFDAguaCapa1.Filter = "Archivo de Alturas de Agua (*.agu)|*.agu";
            this.openFDAguaCapa1.Title = "Archivo de Agua Capa Permeable";
            // 
            // openFDDEM
            // 
            this.openFDDEM.Filter = "Archivos DEM (*.dem)|*.dem";
            this.openFDDEM.Title = "Archivo de DEM";
            // 
            // openFDProfCapaPermeable
            // 
            this.openFDProfCapaPermeable.Filter = "Archivos de Profundidad Suelos (*.prof)|*.prof";
            this.openFDProfCapaPermeable.Title = "Archivo de Profundidad de Capa Permeable";
            // 
            // openFDCondHSuelo
            // 
            this.openFDCondHSuelo.Filter = "Archivos de Conductividad Hidráulica (*.khs)|*.khs";
            this.openFDCondHSuelo.Title = "Archivo de Conductividad Hidraulica del Suelo";
            // 
            // openFDCapAlmSuelo
            // 
            this.openFDCapAlmSuelo.Filter = "Archivo de Capacidad Almacenamiento (*.cap)|*.cap";
            this.openFDCapAlmSuelo.Title = "Archivo de Capacidad de Almacenamiento de Capa Permeable";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 624);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCargarDEM);
            this.Name = "Form1";
            this.Text = "Modelado de Simulación Hidrológica";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCargarDEM;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFDAguaSuperficial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonBrowseAguaSup;
        private System.Windows.Forms.TextBox textBoxOpenAguaSuperficial;
        public System.Windows.Forms.Button buttonBrowseAguaCapa1;
        public System.Windows.Forms.TextBox textBoxOpenAguaPermeable;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFDAguaCapa1;
        private System.Windows.Forms.Button buttonBrowseCapacAlmSuelo;
        private System.Windows.Forms.TextBox textBoxCapacAlmSuelo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonBrowseConducHSuelo;
        private System.Windows.Forms.TextBox textBoxConducHidrSuelo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonBrowseProfCapPerm;
        private System.Windows.Forms.TextBox textBoxProfCapaPermeable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonBrowseDem;
        private System.Windows.Forms.TextBox textBoxDEM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFDDEM;
        private System.Windows.Forms.OpenFileDialog openFDProfCapaPermeable;
        private System.Windows.Forms.OpenFileDialog openFDCondHSuelo;
        private System.Windows.Forms.OpenFileDialog openFDCapAlmSuelo;
    }
}

