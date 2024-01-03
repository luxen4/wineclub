namespace proyectovinos.Empleados
{
    partial class Form_TodosEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TodosEmpleados));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.text_referenciadeshabilitar = new System.Windows.Forms.TextBox();
            this.text_nombredeshabilitar = new System.Windows.Forms.TextBox();
            this.check_segurodeshabilitar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.check_demo = new System.Windows.Forms.CheckBox();
            this.text_referencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_roll = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.button_nuevoempleado = new System.Windows.Forms.Button();
            this.button_subirImagen = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.dateTime_fechanacimiento = new System.Windows.Forms.DateTimePicker();
            this.text_nombre = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.radio_mujer = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.radio_hombre = new System.Windows.Forms.RadioButton();
            this.text_apellido1 = new System.Windows.Forms.TextBox();
            this.text_apellido2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.text_email = new System.Windows.Forms.TextBox();
            this.label_referencia = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.text_telefono = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eMPLEADOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cARGOSROLESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshabilitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(172, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(752, 186);
            this.listView1.TabIndex = 65;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Referencia";
            this.columnHeader1.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre";
            this.columnHeader2.Width = 78;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Apellido1";
            this.columnHeader3.Width = 86;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Apellido2";
            this.columnHeader4.Width = 87;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Teléfono";
            this.columnHeader6.Width = 81;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "email";
            this.columnHeader5.Width = 130;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Sexo";
            this.columnHeader7.Width = 57;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "F. nacimiento";
            this.columnHeader8.Width = 87;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Cargo";
            this.columnHeader9.Width = 77;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(6, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(930, 365);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Todos los Empleados";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.text_referenciadeshabilitar);
            this.groupBox4.Controls.Add(this.text_nombredeshabilitar);
            this.groupBox4.Controls.Add(this.check_segurodeshabilitar);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(6, 215);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 142);
            this.groupBox4.TabIndex = 109;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Deshabilitar";
            this.groupBox4.Visible = false;
            // 
            // text_referenciadeshabilitar
            // 
            this.text_referenciadeshabilitar.Enabled = false;
            this.text_referenciadeshabilitar.Location = new System.Drawing.Point(6, 31);
            this.text_referenciadeshabilitar.Name = "text_referenciadeshabilitar";
            this.text_referenciadeshabilitar.Size = new System.Drawing.Size(148, 20);
            this.text_referenciadeshabilitar.TabIndex = 95;
            // 
            // text_nombredeshabilitar
            // 
            this.text_nombredeshabilitar.Enabled = false;
            this.text_nombredeshabilitar.Location = new System.Drawing.Point(6, 70);
            this.text_nombredeshabilitar.Name = "text_nombredeshabilitar";
            this.text_nombredeshabilitar.Size = new System.Drawing.Size(148, 20);
            this.text_nombredeshabilitar.TabIndex = 98;
            // 
            // check_segurodeshabilitar
            // 
            this.check_segurodeshabilitar.AutoSize = true;
            this.check_segurodeshabilitar.BackColor = System.Drawing.Color.Transparent;
            this.check_segurodeshabilitar.Location = new System.Drawing.Point(33, 97);
            this.check_segurodeshabilitar.Name = "check_segurodeshabilitar";
            this.check_segurodeshabilitar.Size = new System.Drawing.Size(87, 17);
            this.check_segurodeshabilitar.TabIndex = 94;
            this.check_segurodeshabilitar.Text = "Estoy seguro";
            this.check_segurodeshabilitar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "Nombre";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(33, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 92;
            this.button2.Text = "Deshabilitar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 93;
            this.label7.Text = "Ref.";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.check_demo);
            this.groupBox3.Controls.Add(this.text_referencia);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.combo_roll);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.button_nuevoempleado);
            this.groupBox3.Controls.Add(this.button_subirImagen);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.dateTime_fechanacimiento);
            this.groupBox3.Controls.Add(this.text_nombre);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.radio_mujer);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.radio_hombre);
            this.groupBox3.Controls.Add(this.text_apellido1);
            this.groupBox3.Controls.Add(this.text_apellido2);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.text_email);
            this.groupBox3.Controls.Add(this.label_referencia);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.text_telefono);
            this.groupBox3.Location = new System.Drawing.Point(172, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(752, 142);
            this.groupBox3.TabIndex = 93;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nuevo Empleado";
            // 
            // check_demo
            // 
            this.check_demo.AutoSize = true;
            this.check_demo.BackColor = System.Drawing.Color.Transparent;
            this.check_demo.Location = new System.Drawing.Point(698, 11);
            this.check_demo.Name = "check_demo";
            this.check_demo.Size = new System.Drawing.Size(54, 17);
            this.check_demo.TabIndex = 112;
            this.check_demo.Text = "Demo";
            this.check_demo.UseVisualStyleBackColor = false;
            this.check_demo.CheckedChanged += new System.EventHandler(this.check_demo_CheckedChanged);
            // 
            // text_referencia
            // 
            this.text_referencia.Location = new System.Drawing.Point(53, 48);
            this.text_referencia.Name = "text_referencia";
            this.text_referencia.Size = new System.Drawing.Size(94, 20);
            this.text_referencia.TabIndex = 111;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(50, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 110;
            this.label2.Text = "Ref:";
            // 
            // combo_roll
            // 
            this.combo_roll.FormattingEnabled = true;
            this.combo_roll.Location = new System.Drawing.Point(487, 85);
            this.combo_roll.Name = "combo_roll";
            this.combo_roll.Size = new System.Drawing.Size(106, 21);
            this.combo_roll.TabIndex = 47;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(292, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(59, 23);
            this.button5.TabIndex = 96;
            this.button5.Text = "Limpiar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(484, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Cargo:";
            // 
            // button_nuevoempleado
            // 
            this.button_nuevoempleado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_nuevoempleado.BackgroundImage")));
            this.button_nuevoempleado.Location = new System.Drawing.Point(377, 113);
            this.button_nuevoempleado.Name = "button_nuevoempleado";
            this.button_nuevoempleado.Size = new System.Drawing.Size(112, 23);
            this.button_nuevoempleado.TabIndex = 94;
            this.button_nuevoempleado.Text = "Crear Nuevo";
            this.button_nuevoempleado.UseVisualStyleBackColor = true;
            this.button_nuevoempleado.Click += new System.EventHandler(this.button_nuevoempleado_Click);
            // 
            // button_subirImagen
            // 
            this.button_subirImagen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_subirImagen.BackgroundImage")));
            this.button_subirImagen.Location = new System.Drawing.Point(603, 84);
            this.button_subirImagen.Name = "button_subirImagen";
            this.button_subirImagen.Size = new System.Drawing.Size(91, 23);
            this.button_subirImagen.TabIndex = 51;
            this.button_subirImagen.Text = "Subir Imagen";
            this.button_subirImagen.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(277, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 13);
            this.label18.TabIndex = 51;
            this.label18.Text = "Fecha Nacimiento:";
            // 
            // dateTime_fechanacimiento
            // 
            this.dateTime_fechanacimiento.Location = new System.Drawing.Point(280, 87);
            this.dateTime_fechanacimiento.Name = "dateTime_fechanacimiento";
            this.dateTime_fechanacimiento.Size = new System.Drawing.Size(199, 20);
            this.dateTime_fechanacimiento.TabIndex = 50;
            // 
            // text_nombre
            // 
            this.text_nombre.Location = new System.Drawing.Point(164, 48);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(94, 20);
            this.text_nombre.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(152, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 51;
            this.label17.Text = "Sexo:";
            // 
            // radio_mujer
            // 
            this.radio_mujer.AutoSize = true;
            this.radio_mujer.Location = new System.Drawing.Point(223, 87);
            this.radio_mujer.Name = "radio_mujer";
            this.radio_mujer.Size = new System.Drawing.Size(51, 17);
            this.radio_mujer.TabIndex = 50;
            this.radio_mujer.TabStop = true;
            this.radio_mujer.Text = "Mujer";
            this.radio_mujer.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(266, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Apellido 1:";
            // 
            // radio_hombre
            // 
            this.radio_hombre.AutoSize = true;
            this.radio_hombre.Location = new System.Drawing.Point(155, 87);
            this.radio_hombre.Name = "radio_hombre";
            this.radio_hombre.Size = new System.Drawing.Size(62, 17);
            this.radio_hombre.TabIndex = 49;
            this.radio_hombre.TabStop = true;
            this.radio_hombre.Text = "Hombre";
            this.radio_hombre.UseVisualStyleBackColor = true;
            // 
            // text_apellido1
            // 
            this.text_apellido1.Location = new System.Drawing.Point(269, 48);
            this.text_apellido1.Name = "text_apellido1";
            this.text_apellido1.Size = new System.Drawing.Size(94, 20);
            this.text_apellido1.TabIndex = 42;
            // 
            // text_apellido2
            // 
            this.text_apellido2.Location = new System.Drawing.Point(378, 48);
            this.text_apellido2.Name = "text_apellido2";
            this.text_apellido2.Size = new System.Drawing.Size(94, 20);
            this.text_apellido2.TabIndex = 44;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(600, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 47;
            this.label16.Text = "email:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(375, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Apellido 2:";
            // 
            // text_email
            // 
            this.text_email.Location = new System.Drawing.Point(603, 47);
            this.text_email.Name = "text_email";
            this.text_email.Size = new System.Drawing.Size(91, 20);
            this.text_email.TabIndex = 48;
            // 
            // label_referencia
            // 
            this.label_referencia.AutoSize = true;
            this.label_referencia.BackColor = System.Drawing.Color.Transparent;
            this.label_referencia.Location = new System.Drawing.Point(161, 32);
            this.label_referencia.Name = "label_referencia";
            this.label_referencia.Size = new System.Drawing.Size(47, 13);
            this.label_referencia.TabIndex = 38;
            this.label_referencia.Text = "Nombre:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(484, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Teléfono:";
            // 
            // text_telefono
            // 
            this.text_telefono.Location = new System.Drawing.Point(487, 48);
            this.text_telefono.Name = "text_telefono";
            this.text_telefono.Size = new System.Drawing.Size(106, 20);
            this.text_telefono.TabIndex = 46;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eMPLEADOSToolStripMenuItem,
            this.cARGOSROLESToolStripMenuItem,
            this.actualizarToolStripMenuItem,
            this.habilitarToolStripMenuItem,
            this.deshabilitarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(943, 24);
            this.menuStrip1.TabIndex = 70;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eMPLEADOSToolStripMenuItem
            // 
            this.eMPLEADOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem});
            this.eMPLEADOSToolStripMenuItem.Name = "eMPLEADOSToolStripMenuItem";
            this.eMPLEADOSToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.eMPLEADOSToolStripMenuItem.Text = "Empleados";
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarToolStripMenuItem.Image")));
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // cARGOSROLESToolStripMenuItem
            // 
            this.cARGOSROLESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todosToolStripMenuItem,
            this.modificarToolStripMenuItem1});
            this.cARGOSROLESToolStripMenuItem.Name = "cARGOSROLESToolStripMenuItem";
            this.cARGOSROLESToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.cARGOSROLESToolStripMenuItem.Text = "Cargos";
            this.cARGOSROLESToolStripMenuItem.Click += new System.EventHandler(this.cARGOSROLESToolStripMenuItem_Click);
            // 
            // todosToolStripMenuItem
            // 
            this.todosToolStripMenuItem.Name = "todosToolStripMenuItem";
            this.todosToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.todosToolStripMenuItem.Text = "Todos";
            // 
            // modificarToolStripMenuItem1
            // 
            this.modificarToolStripMenuItem1.Name = "modificarToolStripMenuItem1";
            this.modificarToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem1.Text = "Modificar";
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("actualizarToolStripMenuItem.Image")));
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // habilitarToolStripMenuItem
            // 
            this.habilitarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("habilitarToolStripMenuItem.Image")));
            this.habilitarToolStripMenuItem.Name = "habilitarToolStripMenuItem";
            this.habilitarToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.habilitarToolStripMenuItem.Text = "Habilitar";
            this.habilitarToolStripMenuItem.Click += new System.EventHandler(this.habilitarToolStripMenuItem_Click);
            // 
            // deshabilitarToolStripMenuItem
            // 
            this.deshabilitarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deshabilitarToolStripMenuItem.Image")));
            this.deshabilitarToolStripMenuItem.Name = "deshabilitarToolStripMenuItem";
            this.deshabilitarToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.deshabilitarToolStripMenuItem.Text = "Deshabilitar";
            this.deshabilitarToolStripMenuItem.Click += new System.EventHandler(this.deshabilitarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click_1);
            // 
            // todosRolesToolStripMenuItem
            // 
            this.todosRolesToolStripMenuItem.Name = "todosRolesToolStripMenuItem";
            this.todosRolesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(975, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 17);
            this.checkBox1.TabIndex = 112;
            this.checkBox1.Text = "Demo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(844, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(94, 17);
            this.radioButton2.TabIndex = 113;
            this.radioButton2.Text = "Deshabilitados";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(761, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 114;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Habilitados";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form_TodosEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(943, 397);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_TodosEmpleados";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_TodosEmpleados_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eMPLEADOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosRolesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox combo_roll;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_subirImagen;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateTime_fechanacimiento;
        private System.Windows.Forms.TextBox text_nombre;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton radio_mujer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radio_hombre;
        private System.Windows.Forms.TextBox text_apellido1;
        private System.Windows.Forms.TextBox text_apellido2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_email;
        private System.Windows.Forms.Label label_referencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox text_telefono;
        private System.Windows.Forms.Button button_nuevoempleado;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem cARGOSROLESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox text_referenciadeshabilitar;
        private System.Windows.Forms.TextBox text_nombredeshabilitar;
        private System.Windows.Forms.CheckBox check_segurodeshabilitar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_referencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.CheckBox check_demo;
        private System.Windows.Forms.ToolStripMenuItem deshabilitarToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ToolStripMenuItem habilitarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
    }
}