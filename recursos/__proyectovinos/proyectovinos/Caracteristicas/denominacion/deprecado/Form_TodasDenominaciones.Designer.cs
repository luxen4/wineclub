namespace proyectovinos
{
    partial class Form_TodasDenominaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TodasDenominaciones));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cATALOGACIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denominacionesDeshabilitadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.check_seguronuevo = new System.Windows.Forms.CheckBox();
            this.text_nombrenuevo = new System.Windows.Forms.TextBox();
            this.text_referencianuevo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.text_referenciadeshabilitar = new System.Windows.Forms.TextBox();
            this.text_nombredeshabilitar = new System.Windows.Forms.TextBox();
            this.check_segurodeshabilitar = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.aRTÍCULOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(236, 162);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Referencia";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre";
            this.columnHeader2.Width = 160;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(5, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 193);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Todas Denominaciones Habilitadas";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cATALOGACIONESToolStripMenuItem,
            this.aRTÍCULOSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(621, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cATALOGACIONESToolStripMenuItem
            // 
            this.cATALOGACIONESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.denominacionesDeshabilitadasToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.cATALOGACIONESToolStripMenuItem.Name = "cATALOGACIONESToolStripMenuItem";
            this.cATALOGACIONESToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.cATALOGACIONESToolStripMenuItem.Text = "DENOMINACIONES";
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // denominacionesDeshabilitadasToolStripMenuItem
            // 
            this.denominacionesDeshabilitadasToolStripMenuItem.Name = "denominacionesDeshabilitadasToolStripMenuItem";
            this.denominacionesDeshabilitadasToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.denominacionesDeshabilitadasToolStripMenuItem.Text = "Denominaciones Deshabilitadas";
            this.denominacionesDeshabilitadasToolStripMenuItem.Click += new System.EventHandler(this.denominacionesDeshabilitadasToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.check_seguronuevo);
            this.groupBox3.Controls.Add(this.text_nombrenuevo);
            this.groupBox3.Controls.Add(this.text_referencianuevo);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(263, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 174);
            this.groupBox3.TabIndex = 99;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nueva Denominacion";
            // 
            // check_seguronuevo
            // 
            this.check_seguronuevo.AutoSize = true;
            this.check_seguronuevo.BackColor = System.Drawing.Color.Transparent;
            this.check_seguronuevo.Location = new System.Drawing.Point(47, 116);
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
            // text_referencianuevo
            // 
            this.text_referencianuevo.Enabled = false;
            this.text_referencianuevo.Location = new System.Drawing.Point(6, 76);
            this.text_referencianuevo.Name = "text_referencianuevo";
            this.text_referencianuevo.Size = new System.Drawing.Size(177, 20);
            this.text_referencianuevo.TabIndex = 63;
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
            this.button5.Location = new System.Drawing.Point(47, 139);
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
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.text_referenciadeshabilitar);
            this.groupBox4.Controls.Add(this.text_nombredeshabilitar);
            this.groupBox4.Controls.Add(this.check_segurodeshabilitar);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(467, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(146, 174);
            this.groupBox4.TabIndex = 109;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Deshabilitar";
            // 
            // text_referenciadeshabilitar
            // 
            this.text_referenciadeshabilitar.Enabled = false;
            this.text_referenciadeshabilitar.Location = new System.Drawing.Point(6, 40);
            this.text_referenciadeshabilitar.Name = "text_referenciadeshabilitar";
            this.text_referenciadeshabilitar.Size = new System.Drawing.Size(129, 20);
            this.text_referenciadeshabilitar.TabIndex = 95;
            // 
            // text_nombredeshabilitar
            // 
            this.text_nombredeshabilitar.Enabled = false;
            this.text_nombredeshabilitar.Location = new System.Drawing.Point(6, 79);
            this.text_nombredeshabilitar.Name = "text_nombredeshabilitar";
            this.text_nombredeshabilitar.Size = new System.Drawing.Size(129, 20);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "Nombre";
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.Location = new System.Drawing.Point(27, 139);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 92;
            this.button3.Text = "Deshabilitar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Ref.";
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
            // Form_TodasDenominaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(621, 227);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_TodasDenominaciones";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_TodasDenominaciones_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cATALOGACIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox check_seguronuevo;
        private System.Windows.Forms.TextBox text_nombrenuevo;
        private System.Windows.Forms.TextBox text_referencianuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox text_referenciadeshabilitar;
        private System.Windows.Forms.TextBox text_nombredeshabilitar;
        private System.Windows.Forms.CheckBox check_segurodeshabilitar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem denominacionesDeshabilitadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aRTÍCULOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
    }
}