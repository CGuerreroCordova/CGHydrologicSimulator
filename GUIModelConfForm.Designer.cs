namespace SimuladorInundaciones
{
    partial class GUIModelConfForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonOpenFolderLluvia = new System.Windows.Forms.Button();
            this.textBoxLluvia = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxTg = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxNt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxNts = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.openFDAguaSuperficial = new System.Windows.Forms.OpenFileDialog();
            this.openFDAguaCapa1 = new System.Windows.Forms.OpenFileDialog();
            this.openFDDEM = new System.Windows.Forms.OpenFileDialog();
            this.openFDProfCapaPermeable = new System.Windows.Forms.OpenFileDialog();
            this.openFDCondHSuelo = new System.Windows.Forms.OpenFileDialog();
            this.openFDCapAlmSuelo = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.folderBrowserLluvia = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(216, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
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
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(216, 62);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 6;
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
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(898, 590);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(890, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos de Entrada";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonOpenFolderLluvia);
            this.groupBox4.Controls.Add(this.textBoxLluvia);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(21, 176);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(849, 85);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos de Lluvia";
            // 
            // buttonOpenFolderLluvia
            // 
            this.buttonOpenFolderLluvia.BackColor = System.Drawing.Color.Khaki;
            this.buttonOpenFolderLluvia.Location = new System.Drawing.Point(763, 26);
            this.buttonOpenFolderLluvia.Name = "buttonOpenFolderLluvia";
            this.buttonOpenFolderLluvia.Size = new System.Drawing.Size(64, 37);
            this.buttonOpenFolderLluvia.TabIndex = 2;
            this.buttonOpenFolderLluvia.Text = "Buscar";
            this.buttonOpenFolderLluvia.UseVisualStyleBackColor = false;
            this.buttonOpenFolderLluvia.Click += new System.EventHandler(this.buttonOpenFolderLluvia_Click);
            // 
            // textBoxLluvia
            // 
            this.textBoxLluvia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLluvia.Location = new System.Drawing.Point(218, 35);
            this.textBoxLluvia.Name = "textBoxLluvia";
            this.textBoxLluvia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLluvia.Size = new System.Drawing.Size(528, 20);
            this.textBoxLluvia.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Carpeta archivos de lluvia";
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
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(21, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 265);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Contorno";
            // 
            // buttonBrowseCapacAlmSuelo
            // 
            this.buttonBrowseCapacAlmSuelo.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseCapacAlmSuelo.Location = new System.Drawing.Point(763, 213);
            this.buttonBrowseCapacAlmSuelo.Name = "buttonBrowseCapacAlmSuelo";
            this.buttonBrowseCapacAlmSuelo.Size = new System.Drawing.Size(64, 32);
            this.buttonBrowseCapacAlmSuelo.TabIndex = 15;
            this.buttonBrowseCapacAlmSuelo.Text = "Buscar";
            this.buttonBrowseCapacAlmSuelo.UseVisualStyleBackColor = false;
            this.buttonBrowseCapacAlmSuelo.Click += new System.EventHandler(this.buttonBrowseCapacAlmSuelo_Click);
            // 
            // textBoxCapacAlmSuelo
            // 
            this.textBoxCapacAlmSuelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCapacAlmSuelo.Location = new System.Drawing.Point(218, 217);
            this.textBoxCapacAlmSuelo.Name = "textBoxCapacAlmSuelo";
            this.textBoxCapacAlmSuelo.Size = new System.Drawing.Size(528, 20);
            this.textBoxCapacAlmSuelo.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 32);
            this.label10.TabIndex = 13;
            this.label10.Text = "Capacidad Almacenamiento \r\nCapa Permeable";
            // 
            // buttonBrowseConducHSuelo
            // 
            this.buttonBrowseConducHSuelo.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseConducHSuelo.Location = new System.Drawing.Point(763, 156);
            this.buttonBrowseConducHSuelo.Name = "buttonBrowseConducHSuelo";
            this.buttonBrowseConducHSuelo.Size = new System.Drawing.Size(64, 32);
            this.buttonBrowseConducHSuelo.TabIndex = 12;
            this.buttonBrowseConducHSuelo.Text = "Buscar";
            this.buttonBrowseConducHSuelo.UseVisualStyleBackColor = false;
            this.buttonBrowseConducHSuelo.Click += new System.EventHandler(this.buttonBrowseConducHSuelo_Click);
            // 
            // textBoxConducHidrSuelo
            // 
            this.textBoxConducHidrSuelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConducHidrSuelo.Location = new System.Drawing.Point(218, 160);
            this.textBoxConducHidrSuelo.Name = "textBoxConducHidrSuelo";
            this.textBoxConducHidrSuelo.Size = new System.Drawing.Size(528, 20);
            this.textBoxConducHidrSuelo.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Conductividad Hidráulica Suelo";
            // 
            // buttonBrowseProfCapPerm
            // 
            this.buttonBrowseProfCapPerm.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseProfCapPerm.Location = new System.Drawing.Point(763, 98);
            this.buttonBrowseProfCapPerm.Name = "buttonBrowseProfCapPerm";
            this.buttonBrowseProfCapPerm.Size = new System.Drawing.Size(64, 32);
            this.buttonBrowseProfCapPerm.TabIndex = 9;
            this.buttonBrowseProfCapPerm.Text = "Buscar";
            this.buttonBrowseProfCapPerm.UseVisualStyleBackColor = false;
            this.buttonBrowseProfCapPerm.Click += new System.EventHandler(this.buttonBrowseProfCapPerm_Click);
            // 
            // textBoxProfCapaPermeable
            // 
            this.textBoxProfCapaPermeable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfCapaPermeable.Location = new System.Drawing.Point(218, 102);
            this.textBoxProfCapaPermeable.Name = "textBoxProfCapaPermeable";
            this.textBoxProfCapaPermeable.Size = new System.Drawing.Size(528, 20);
            this.textBoxProfCapaPermeable.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Profundidad Capa Permeable";
            // 
            // buttonBrowseDem
            // 
            this.buttonBrowseDem.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseDem.Location = new System.Drawing.Point(763, 38);
            this.buttonBrowseDem.Name = "buttonBrowseDem";
            this.buttonBrowseDem.Size = new System.Drawing.Size(64, 32);
            this.buttonBrowseDem.TabIndex = 6;
            this.buttonBrowseDem.Text = "Buscar";
            this.buttonBrowseDem.UseVisualStyleBackColor = false;
            this.buttonBrowseDem.Click += new System.EventHandler(this.buttonBrowseDem_Click);
            // 
            // textBoxDEM
            // 
            this.textBoxDEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDEM.Location = new System.Drawing.Point(218, 42);
            this.textBoxDEM.Name = "textBoxDEM";
            this.textBoxDEM.Size = new System.Drawing.Size(528, 20);
            this.textBoxDEM.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "DEM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonBrowseAguaCapa1);
            this.groupBox1.Controls.Add(this.textBoxOpenAguaPermeable);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonBrowseAguaSup);
            this.groupBox1.Controls.Add(this.textBoxOpenAguaSuperficial);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 155);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Inicialización";
            // 
            // buttonBrowseAguaCapa1
            // 
            this.buttonBrowseAguaCapa1.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseAguaCapa1.Location = new System.Drawing.Point(763, 90);
            this.buttonBrowseAguaCapa1.Name = "buttonBrowseAguaCapa1";
            this.buttonBrowseAguaCapa1.Size = new System.Drawing.Size(64, 32);
            this.buttonBrowseAguaCapa1.TabIndex = 6;
            this.buttonBrowseAguaCapa1.Text = "Buscar";
            this.buttonBrowseAguaCapa1.UseVisualStyleBackColor = false;
            this.buttonBrowseAguaCapa1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // textBoxOpenAguaPermeable
            // 
            this.textBoxOpenAguaPermeable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOpenAguaPermeable.Location = new System.Drawing.Point(218, 94);
            this.textBoxOpenAguaPermeable.Name = "textBoxOpenAguaPermeable";
            this.textBoxOpenAguaPermeable.Size = new System.Drawing.Size(528, 20);
            this.textBoxOpenAguaPermeable.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Agua Capa Permeable Inicial";
            // 
            // buttonBrowseAguaSup
            // 
            this.buttonBrowseAguaSup.BackColor = System.Drawing.Color.Khaki;
            this.buttonBrowseAguaSup.Location = new System.Drawing.Point(763, 34);
            this.buttonBrowseAguaSup.Name = "buttonBrowseAguaSup";
            this.buttonBrowseAguaSup.Size = new System.Drawing.Size(64, 32);
            this.buttonBrowseAguaSup.TabIndex = 3;
            this.buttonBrowseAguaSup.Text = "Buscar";
            this.buttonBrowseAguaSup.UseVisualStyleBackColor = false;
            this.buttonBrowseAguaSup.Click += new System.EventHandler(this.buttonBrowseAguaSup_Click);
            // 
            // textBoxOpenAguaSuperficial
            // 
            this.textBoxOpenAguaSuperficial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOpenAguaSuperficial.Location = new System.Drawing.Point(218, 38);
            this.textBoxOpenAguaSuperficial.Name = "textBoxOpenAguaSuperficial";
            this.textBoxOpenAguaSuperficial.Size = new System.Drawing.Size(528, 20);
            this.textBoxOpenAguaSuperficial.TabIndex = 2;
            this.textBoxOpenAguaSuperficial.TextChanged += new System.EventHandler(this.textBoxOpenAguaSuperficial_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Agua Superficial Inicial";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(890, 561);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parámetros de Tiempo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxTg);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBoxNt);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.textBoxNts);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(214, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 224);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parámetros Iniciales de Ejecución";
            // 
            // textBoxTg
            // 
            this.textBoxTg.Location = new System.Drawing.Point(268, 171);
            this.textBoxTg.Name = "textBoxTg";
            this.textBoxTg.Size = new System.Drawing.Size(92, 22);
            this.textBoxTg.TabIndex = 7;
            this.textBoxTg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 32);
            this.label13.TabIndex = 6;
            this.label13.Text = "Período de grabación \r\nde resultados";
            // 
            // textBoxNt
            // 
            this.textBoxNt.Location = new System.Drawing.Point(268, 110);
            this.textBoxNt.Name = "textBoxNt";
            this.textBoxNt.Size = new System.Drawing.Size(92, 22);
            this.textBoxNt.TabIndex = 5;
            this.textBoxNt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 32);
            this.label11.TabIndex = 4;
            this.label11.Text = "Cantidad de Horas de \r\nduración de la Simulación (Nt)";
            // 
            // textBoxNts
            // 
            this.textBoxNts.Location = new System.Drawing.Point(268, 56);
            this.textBoxNts.Name = "textBoxNts";
            this.textBoxNts.Size = new System.Drawing.Size(92, 22);
            this.textBoxNts.TabIndex = 2;
            this.textBoxNts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(238, 32);
            this.label12.TabIndex = 1;
            this.label12.Text = "Cantidad de pasos de tiempo máximo \r\nde escurrimiento superficial. (Nts) \r\n";
            // 
            // openFDAguaSuperficial
            // 
            this.openFDAguaSuperficial.Filter = "Archivos de Alturas de Agua (*.agu)|*.agu";
            this.openFDAguaSuperficial.Title = "Archivo de Agua Superficial";
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(926, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 89);
            this.button1.TabIndex = 10;
            this.button1.Text = "Iniciar\r\nSimulación";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(926, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "No Realizar Planchado";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(926, 127);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(131, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Escribir Matriz Clusters";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // GUIModelConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1066, 623);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
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
            this.Name = "GUIModelConfForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador Hidrologico (Configuración)";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox textBoxNt;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox textBoxTg;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textBoxNts;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonOpenFolderLluvia;
        private System.Windows.Forms.TextBox textBoxLluvia;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserLluvia;
    }
}

