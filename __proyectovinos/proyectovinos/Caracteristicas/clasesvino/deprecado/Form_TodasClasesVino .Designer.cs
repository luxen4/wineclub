using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proyectovinos
{
    partial class Form_TodasClasesVino
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TodasClasesVino));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cATALOGACIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarClaseVinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.check_seguronuevo = new System.Windows.Forms.CheckBox();
            this.text_nombrenuevo = new System.Windows.Forms.TextBox();
            this.text_referencianuevo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.text_referenciadeshabilitar = new System.Windows.Forms.TextBox();
            this.text_nombredeshabilitar = new System.Windows.Forms.TextBox();
            this.check_segurodeshabilitar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aRTÍCULOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cATALOGACIONESToolStripMenuItem,
            this.aRTÍCULOSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 83;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cATALOGACIONESToolStripMenuItem
            // 
            this.cATALOGACIONESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem1,
            this.habilitarClaseVinoToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.cATALOGACIONESToolStripMenuItem.Name = "cATALOGACIONESToolStripMenuItem";
            this.cATALOGACIONESToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.cATALOGACIONESToolStripMenuItem.Text = "CLASES DE VINO";
            // 
            // modificarToolStripMenuItem1
            // 
            this.modificarToolStripMenuItem1.Name = "modificarToolStripMenuItem1";
            this.modificarToolStripMenuItem1.Size = new System.Drawing.Size(213, 22);
            this.modificarToolStripMenuItem1.Text = "Modificar";
            this.modificarToolStripMenuItem1.Click += new System.EventHandler(this.modificarToolStripMenuItem1_Click);
            // 
            // habilitarClaseVinoToolStripMenuItem
            // 
            this.habilitarClaseVinoToolStripMenuItem.Name = "habilitarClaseVinoToolStripMenuItem";
            this.habilitarClaseVinoToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.habilitarClaseVinoToolStripMenuItem.Text = "Clases Vino Deshabilitadas";
            this.habilitarClaseVinoToolStripMenuItem.Click += new System.EventHandler(this.habilitarClaseVinoToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
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
            this.groupBox3.Location = new System.Drawing.Point(270, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 174);
            this.groupBox3.TabIndex = 109;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nueva Clase de Vino";
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.text_referenciadeshabilitar);
            this.groupBox2.Controls.Add(this.text_nombredeshabilitar);
            this.groupBox2.Controls.Add(this.check_segurodeshabilitar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(474, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 174);
            this.groupBox2.TabIndex = 108;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deshabilitar";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "Nombre";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(27, 139);
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
            this.label7.Location = new System.Drawing.Point(3, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 93;
            this.label7.Text = "Ref.";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Location = new System.Drawing.Point(12, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 193);
            this.groupBox4.TabIndex = 106;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Todas Clases de Vino Deshabilitadas";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
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
            // columnHeader3
            // 
            this.columnHeader3.Text = "Referencia";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nombre";
            this.columnHeader4.Width = 160;
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
            // Form_TodasClasesVino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(632, 226);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_TodasClasesVino";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_TodasClasesVino_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cATALOGACIONESToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem1;
        private GroupBox groupBox3;
        private CheckBox check_seguronuevo;
        private System.Windows.Forms.TextBox text_nombrenuevo;
        private System.Windows.Forms.TextBox text_referencianuevo;
        private Label label2;
        private System.Windows.Forms.Button button5;
        private Label label3;
        private GroupBox groupBox2;
        private System.Windows.Forms.TextBox text_referenciadeshabilitar;
        private System.Windows.Forms.TextBox text_nombredeshabilitar;
        private CheckBox check_segurodeshabilitar;
        private Label label1;
        private System.Windows.Forms.Button button2;
        private Label label7;
        private GroupBox groupBox4;
        private System.Windows.Forms.ListView listView1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ToolStripMenuItem habilitarClaseVinoToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem aRTÍCULOSToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem;
    }
}