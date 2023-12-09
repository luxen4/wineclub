namespace proyectovinos
{
    partial class Form_NuevoArticulo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NuevoArticulo));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_proveedor = new System.Windows.Forms.ComboBox();
            this.combo_catalogacion = new System.Windows.Forms.ComboBox();
            this.combo_denominacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numeric_maxalmacen = new System.Windows.Forms.NumericUpDown();
            this.pictureBox_articulo = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.combo_empaquetado = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numeric_maxtienda = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numeric_mintienda = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numeric_minalmacen = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.combo_tipouva = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.text_referencianuevo = new System.Windows.Forms.TextBox();
            this.combo_formatocontenido = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_clasedevino = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.imageList_fotoarticulos = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aRTICULOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.check_demo = new System.Windows.Forms.CheckBox();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_maxalmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_articulo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_maxtienda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_mintienda)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_minalmacen)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(200, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proveedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(422, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Catalogación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(203, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "D.O.";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mín.";
            // 
            // combo_proveedor
            // 
            this.combo_proveedor.FormattingEnabled = true;
            this.combo_proveedor.Location = new System.Drawing.Point(203, 110);
            this.combo_proveedor.Name = "combo_proveedor";
            this.combo_proveedor.Size = new System.Drawing.Size(170, 21);
            this.combo_proveedor.TabIndex = 13;
            this.combo_proveedor.Click += new System.EventHandler(this.combo_proveedor_Click);
            this.combo_proveedor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.combo_proveedor_MouseClick);
            // 
            // combo_catalogacion
            // 
            this.combo_catalogacion.FormattingEnabled = true;
            this.combo_catalogacion.Location = new System.Drawing.Point(423, 110);
            this.combo_catalogacion.Name = "combo_catalogacion";
            this.combo_catalogacion.Size = new System.Drawing.Size(186, 21);
            this.combo_catalogacion.TabIndex = 14;
            this.combo_catalogacion.Click += new System.EventHandler(this.combo_catalogacion_Click);
            this.combo_catalogacion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.combo_catalogacion_MouseClick);
            // 
            // combo_denominacion
            // 
            this.combo_denominacion.FormattingEnabled = true;
            this.combo_denominacion.Location = new System.Drawing.Point(203, 150);
            this.combo_denominacion.Name = "combo_denominacion";
            this.combo_denominacion.Size = new System.Drawing.Size(170, 21);
            this.combo_denominacion.TabIndex = 15;
            this.combo_denominacion.Click += new System.EventHandler(this.combo_denominacion_Click);
            this.combo_denominacion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.combo_denominacion_MouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(81, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Máx.";
            // 
            // numeric_maxalmacen
            // 
            this.numeric_maxalmacen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numeric_maxalmacen.Location = new System.Drawing.Point(84, 31);
            this.numeric_maxalmacen.Name = "numeric_maxalmacen";
            this.numeric_maxalmacen.Size = new System.Drawing.Size(45, 20);
            this.numeric_maxalmacen.TabIndex = 18;
            // 
            // pictureBox_articulo
            // 
            this.pictureBox_articulo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_articulo.BackgroundImage")));
            this.pictureBox_articulo.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_articulo.Name = "pictureBox_articulo";
            this.pictureBox_articulo.Size = new System.Drawing.Size(170, 260);
            this.pictureBox_articulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_articulo.TabIndex = 19;
            this.pictureBox_articulo.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Controls.Add(this.button16);
            this.groupBox2.Controls.Add(this.button15);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.combo_empaquetado);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.combo_tipouva);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.text_referencianuevo);
            this.groupBox2.Controls.Add(this.combo_formatocontenido);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.combo_clasedevino);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.pictureBox_articulo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.combo_proveedor);
            this.groupBox2.Controls.Add(this.combo_catalogacion);
            this.groupBox2.Controls.Add(this.combo_denominacion);
            this.groupBox2.Location = new System.Drawing.Point(10, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(658, 318);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo Articulo";
            // 
            // button17
            // 
            this.button17.AutoSize = true;
            this.button17.BackColor = System.Drawing.Color.Transparent;
            this.button17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button17.BackgroundImage")));
            this.button17.Location = new System.Drawing.Point(612, 186);
            this.button17.Margin = new System.Windows.Forms.Padding(0);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(25, 25);
            this.button17.TabIndex = 106;
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.AutoSize = true;
            this.button16.BackColor = System.Drawing.Color.Transparent;
            this.button16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button16.BackgroundImage")));
            this.button16.Location = new System.Drawing.Point(612, 107);
            this.button16.Margin = new System.Windows.Forms.Padding(0);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(25, 25);
            this.button16.TabIndex = 105;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.AutoSize = true;
            this.button15.BackColor = System.Drawing.Color.Transparent;
            this.button15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button15.BackgroundImage")));
            this.button15.Location = new System.Drawing.Point(612, 67);
            this.button15.Margin = new System.Windows.Forms.Padding(0);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(25, 25);
            this.button15.TabIndex = 104;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.AutoSize = true;
            this.button14.BackColor = System.Drawing.Color.Transparent;
            this.button14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button14.BackgroundImage")));
            this.button14.Location = new System.Drawing.Point(376, 187);
            this.button14.Margin = new System.Windows.Forms.Padding(0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(25, 25);
            this.button14.TabIndex = 103;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.AutoSize = true;
            this.button13.BackColor = System.Drawing.Color.Transparent;
            this.button13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button13.BackgroundImage")));
            this.button13.Location = new System.Drawing.Point(376, 147);
            this.button13.Margin = new System.Windows.Forms.Padding(0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(25, 25);
            this.button13.TabIndex = 102;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.AutoSize = true;
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button12.BackgroundImage")));
            this.button12.Location = new System.Drawing.Point(376, 107);
            this.button12.Margin = new System.Windows.Forms.Padding(0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(25, 25);
            this.button12.TabIndex = 101;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button10
            // 
            this.button10.AutoSize = true;
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.Location = new System.Drawing.Point(376, 67);
            this.button10.Margin = new System.Windows.Forms.Padding(0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(25, 25);
            this.button10.TabIndex = 100;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(422, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Ref.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(422, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Empaquetado:";
            // 
            // combo_empaquetado
            // 
            this.combo_empaquetado.FormattingEnabled = true;
            this.combo_empaquetado.Location = new System.Drawing.Point(423, 190);
            this.combo_empaquetado.Name = "combo_empaquetado";
            this.combo_empaquetado.Size = new System.Drawing.Size(186, 21);
            this.combo_empaquetado.TabIndex = 43;
            this.combo_empaquetado.Click += new System.EventHandler(this.combo_empaquetado_Click);
            this.combo_empaquetado.MouseClick += new System.Windows.Forms.MouseEventHandler(this.combo_empaquetado_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.numeric_maxtienda);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.numeric_mintienda);
            this.groupBox3.Location = new System.Drawing.Point(416, 228);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 65);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Existencias Tienda";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Mín.";
            // 
            // numeric_maxtienda
            // 
            this.numeric_maxtienda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numeric_maxtienda.Location = new System.Drawing.Point(84, 31);
            this.numeric_maxtienda.Name = "numeric_maxtienda";
            this.numeric_maxtienda.Size = new System.Drawing.Size(45, 20);
            this.numeric_maxtienda.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(81, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Máx.";
            // 
            // numeric_mintienda
            // 
            this.numeric_mintienda.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numeric_mintienda.Location = new System.Drawing.Point(9, 32);
            this.numeric_mintienda.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_mintienda.Name = "numeric_mintienda";
            this.numeric_mintienda.Size = new System.Drawing.Size(50, 20);
            this.numeric_mintienda.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numeric_maxalmacen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numeric_minalmacen);
            this.groupBox1.Location = new System.Drawing.Point(262, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 65);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Existencias Almacén";
            // 
            // numeric_minalmacen
            // 
            this.numeric_minalmacen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numeric_minalmacen.Location = new System.Drawing.Point(9, 32);
            this.numeric_minalmacen.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_minalmacen.Name = "numeric_minalmacen";
            this.numeric_minalmacen.Size = new System.Drawing.Size(50, 20);
            this.numeric_minalmacen.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(422, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Tipo Uva:";
            // 
            // combo_tipouva
            // 
            this.combo_tipouva.FormattingEnabled = true;
            this.combo_tipouva.Location = new System.Drawing.Point(423, 70);
            this.combo_tipouva.Name = "combo_tipouva";
            this.combo_tipouva.Size = new System.Drawing.Size(186, 21);
            this.combo_tipouva.TabIndex = 46;
            this.combo_tipouva.Click += new System.EventHandler(this.combo_tipouva_Click);
            this.combo_tipouva.MouseClick += new System.Windows.Forms.MouseEventHandler(this.combo_tipouva_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(200, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Formato:";
            // 
            // text_referencianuevo
            // 
            this.text_referencianuevo.Enabled = false;
            this.text_referencianuevo.Location = new System.Drawing.Point(423, 31);
            this.text_referencianuevo.Name = "text_referencianuevo";
            this.text_referencianuevo.Size = new System.Drawing.Size(186, 20);
            this.text_referencianuevo.TabIndex = 40;
            // 
            // combo_formatocontenido
            // 
            this.combo_formatocontenido.FormattingEnabled = true;
            this.combo_formatocontenido.Location = new System.Drawing.Point(203, 190);
            this.combo_formatocontenido.Name = "combo_formatocontenido";
            this.combo_formatocontenido.Size = new System.Drawing.Size(170, 21);
            this.combo_formatocontenido.TabIndex = 30;
            this.combo_formatocontenido.Click += new System.EventHandler(this.combo_formatocontenido_Click);
            this.combo_formatocontenido.MouseClick += new System.Windows.Forms.MouseEventHandler(this.combo_formatocontenido_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(200, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Clase de Vino:";
            // 
            // combo_clasedevino
            // 
            this.combo_clasedevino.FormattingEnabled = true;
            this.combo_clasedevino.Location = new System.Drawing.Point(203, 70);
            this.combo_clasedevino.Name = "combo_clasedevino";
            this.combo_clasedevino.Size = new System.Drawing.Size(170, 21);
            this.combo_clasedevino.TabIndex = 28;
            this.combo_clasedevino.Click += new System.EventHandler(this.combo_clasedevino_Click);
            this.combo_clasedevino.MouseClick += new System.Windows.Forms.MouseEventHandler(this.combo_clasedevino_MouseClick);
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.Location = new System.Drawing.Point(6, 285);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(170, 25);
            this.button6.TabIndex = 27;
            this.button6.Text = "Imagen del Producto";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // imageList_fotoarticulos
            // 
            this.imageList_fotoarticulos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_fotoarticulos.ImageStream")));
            this.imageList_fotoarticulos.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_fotoarticulos.Images.SetKeyName(0, "2022-12-28 11_03_44-botella vino - Buscar con Google.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aRTICULOSToolStripMenuItem,
            this.limpiarToolStripMenuItem,
            this.nuevoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aRTICULOSToolStripMenuItem
            // 
            this.aRTICULOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTodosToolStripMenuItem});
            this.aRTICULOSToolStripMenuItem.Name = "aRTICULOSToolStripMenuItem";
            this.aRTICULOSToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.aRTICULOSToolStripMenuItem.Text = "ARTICULOS";
            // 
            // verTodosToolStripMenuItem
            // 
            this.verTodosToolStripMenuItem.Name = "verTodosToolStripMenuItem";
            this.verTodosToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.verTodosToolStripMenuItem.Text = "Ver Todos";
            this.verTodosToolStripMenuItem.Click += new System.EventHandler(this.verTodosToolStripMenuItem_Click);
            // 
            // limpiarToolStripMenuItem
            // 
            this.limpiarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("limpiarToolStripMenuItem.Image")));
            this.limpiarToolStripMenuItem.Name = "limpiarToolStripMenuItem";
            this.limpiarToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.limpiarToolStripMenuItem.Text = "Limpiar";
            this.limpiarToolStripMenuItem.Click += new System.EventHandler(this.limpiarToolStripMenuItem_Click);
            // 
            // check_demo
            // 
            this.check_demo.AutoSize = true;
            this.check_demo.Location = new System.Drawing.Point(614, 4);
            this.check_demo.Name = "check_demo";
            this.check_demo.Size = new System.Drawing.Size(54, 17);
            this.check_demo.TabIndex = 27;
            this.check_demo.Text = "Demo";
            this.check_demo.UseVisualStyleBackColor = true;
            this.check_demo.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // Form_NuevoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(680, 350);
            this.Controls.Add(this.check_demo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_NuevoArticulo";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_maxalmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_articulo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_maxtienda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_mintienda)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_minalmacen)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_proveedor;
        private System.Windows.Forms.ComboBox combo_catalogacion;
        private System.Windows.Forms.ComboBox combo_denominacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numeric_maxalmacen;
        private System.Windows.Forms.PictureBox pictureBox_articulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList_fotoarticulos;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combo_clasedevino;
        private System.Windows.Forms.ComboBox combo_formatocontenido;
        private System.Windows.Forms.TextBox text_referencianuevo;
        private System.Windows.Forms.NumericUpDown numeric_minalmacen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combo_empaquetado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combo_tipouva;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numeric_maxtienda;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numeric_mintienda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aRTICULOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTodosToolStripMenuItem;
        private System.Windows.Forms.CheckBox check_demo;
        private System.Windows.Forms.ToolStripMenuItem limpiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
    }
}