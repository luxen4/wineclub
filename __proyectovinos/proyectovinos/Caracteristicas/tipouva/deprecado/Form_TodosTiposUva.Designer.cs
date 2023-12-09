namespace proyectovinos.Caracteristicas.tipouva
{
    partial class Form_TodosTiposUva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TodosTiposUva));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tIPOSDEUVAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeUvaDeshabilitadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button17 = new System.Windows.Forms.Button();
            this.combo_variedaduvanuevo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.check_seguronuevo = new System.Windows.Forms.CheckBox();
            this.text_nombrenuevo = new System.Windows.Forms.TextBox();
            this.text_referencianueva = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.text_referenciadeshabilitar = new System.Windows.Forms.TextBox();
            this.text_nombredeshabilitar = new System.Windows.Forms.TextBox();
            this.check_segurodeshabilitar = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.aRTÍCULOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aRTÍCULOSToolStripMenuItem,
            this.tIPOSDEUVAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(593, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tIPOSDEUVAToolStripMenuItem
            // 
            this.tIPOSDEUVAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.tiposDeUvaDeshabilitadosToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.tIPOSDEUVAToolStripMenuItem.Name = "tIPOSDEUVAToolStripMenuItem";
            this.tIPOSDEUVAToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.tIPOSDEUVAToolStripMenuItem.Text = "TIPOS DE UVA";
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // tiposDeUvaDeshabilitadosToolStripMenuItem
            // 
            this.tiposDeUvaDeshabilitadosToolStripMenuItem.Name = "tiposDeUvaDeshabilitadosToolStripMenuItem";
            this.tiposDeUvaDeshabilitadosToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.tiposDeUvaDeshabilitadosToolStripMenuItem.Text = "Tipos de Uva Deshabilitados";
            this.tiposDeUvaDeshabilitadosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeUvaDeshabilitadosToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 396);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipos de Uva Habilitados";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(355, 371);
            this.listView1.TabIndex = 67;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Referencia";
            this.columnHeader1.Width = 69;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre";
            this.columnHeader2.Width = 179;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Variedad Uva";
            this.columnHeader3.Width = 99;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.button17);
            this.groupBox3.Controls.Add(this.combo_variedaduvanuevo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.check_seguronuevo);
            this.groupBox3.Controls.Add(this.text_nombrenuevo);
            this.groupBox3.Controls.Add(this.text_referencianueva);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(384, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 197);
            this.groupBox3.TabIndex = 109;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nuevo Tipo de Uva";
            // 
            // button17
            // 
            this.button17.AutoSize = true;
            this.button17.BackColor = System.Drawing.Color.Transparent;
            this.button17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button17.BackgroundImage")));
            this.button17.Location = new System.Drawing.Point(169, 112);
            this.button17.Margin = new System.Windows.Forms.Padding(0);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(25, 25);
            this.button17.TabIndex = 107;
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // combo_variedaduvanuevo
            // 
            this.combo_variedaduvanuevo.FormattingEnabled = true;
            this.combo_variedaduvanuevo.Location = new System.Drawing.Point(5, 116);
            this.combo_variedaduvanuevo.Name = "combo_variedaduvanuevo";
            this.combo_variedaduvanuevo.Size = new System.Drawing.Size(162, 21);
            this.combo_variedaduvanuevo.TabIndex = 102;
            this.combo_variedaduvanuevo.Click += new System.EventHandler(this.combo_variedaduvanuevo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(7, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Variedad de Uva";
            // 
            // check_seguronuevo
            // 
            this.check_seguronuevo.AutoSize = true;
            this.check_seguronuevo.BackColor = System.Drawing.Color.Transparent;
            this.check_seguronuevo.Location = new System.Drawing.Point(49, 143);
            this.check_seguronuevo.Name = "check_seguronuevo";
            this.check_seguronuevo.Size = new System.Drawing.Size(87, 17);
            this.check_seguronuevo.TabIndex = 100;
            this.check_seguronuevo.Text = "Estoy seguro";
            this.check_seguronuevo.UseVisualStyleBackColor = false;
            // 
            // text_nombrenuevo
            // 
            this.text_nombrenuevo.Location = new System.Drawing.Point(6, 37);
            this.text_nombrenuevo.Name = "text_nombrenuevo";
            this.text_nombrenuevo.Size = new System.Drawing.Size(177, 20);
            this.text_nombrenuevo.TabIndex = 61;
            // 
            // text_referencianueva
            // 
            this.text_referencianueva.Enabled = false;
            this.text_referencianueva.Location = new System.Drawing.Point(6, 76);
            this.text_referencianueva.Name = "text_referencianueva";
            this.text_referencianueva.Size = new System.Drawing.Size(177, 20);
            this.text_referencianueva.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(5, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Referencia";
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(49, 166);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 59;
            this.button5.Text = "Añadir";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(5, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Nombre";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Referencia";
            this.columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nombre";
            this.columnHeader5.Width = 160;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.text_referenciadeshabilitar);
            this.groupBox4.Controls.Add(this.text_nombredeshabilitar);
            this.groupBox4.Controls.Add(this.check_segurodeshabilitar);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(384, 260);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(198, 174);
            this.groupBox4.TabIndex = 110;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Deshabilitar";
            // 
            // text_referenciadeshabilitar
            // 
            this.text_referenciadeshabilitar.Enabled = false;
            this.text_referenciadeshabilitar.Location = new System.Drawing.Point(6, 40);
            this.text_referenciadeshabilitar.Name = "text_referenciadeshabilitar";
            this.text_referenciadeshabilitar.Size = new System.Drawing.Size(177, 20);
            this.text_referenciadeshabilitar.TabIndex = 95;
            // 
            // text_nombredeshabilitar
            // 
            this.text_nombredeshabilitar.Enabled = false;
            this.text_nombredeshabilitar.Location = new System.Drawing.Point(6, 79);
            this.text_nombredeshabilitar.Name = "text_nombredeshabilitar";
            this.text_nombredeshabilitar.Size = new System.Drawing.Size(177, 20);
            this.text_nombredeshabilitar.TabIndex = 98;
            // 
            // check_segurodeshabilitar
            // 
            this.check_segurodeshabilitar.AutoSize = true;
            this.check_segurodeshabilitar.BackColor = System.Drawing.Color.Transparent;
            this.check_segurodeshabilitar.Location = new System.Drawing.Point(27, 116);
            this.check_segurodeshabilitar.Name = "check_segurodeshabilitar";
            this.check_segurodeshabilitar.Size = new System.Drawing.Size(87, 17);
            this.check_segurodeshabilitar.TabIndex = 94;
            this.check_segurodeshabilitar.Text = "Estoy seguro";
            this.check_segurodeshabilitar.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "Nombre";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(27, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 92;
            this.button1.Text = "Deshabilitar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 93;
            this.label6.Text = "Ref.";
            // 
            // aRTÍCULOSToolStripMenuItem
            // 
            this.aRTÍCULOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem});
            this.aRTÍCULOSToolStripMenuItem.Name = "aRTÍCULOSToolStripMenuItem";
            this.aRTÍCULOSToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.aRTÍCULOSToolStripMenuItem.Text = "ARTÍCULOS";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // Form_TodosTiposUva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(593, 443);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form_TodosTiposUva";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_TodosTiposUva_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tIPOSDEUVAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox check_seguronuevo;
        private System.Windows.Forms.TextBox text_nombrenuevo;
        private System.Windows.Forms.TextBox text_referencianueva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_variedaduvanuevo;
        private System.Windows.Forms.ToolStripMenuItem tiposDeUvaDeshabilitadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox text_referenciadeshabilitar;
        private System.Windows.Forms.TextBox text_nombredeshabilitar;
        private System.Windows.Forms.CheckBox check_segurodeshabilitar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.ToolStripMenuItem aRTÍCULOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
    }
}