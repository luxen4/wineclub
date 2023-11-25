namespace proyectovinos.Caracteristicas.contenido
{
    partial class Form_HabilitarContenido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_HabilitarContenido));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.text_referenciahabilitar = new System.Windows.Forms.TextBox();
            this.text_nombrehabilitar = new System.Windows.Forms.TextBox();
            this.check_segurohabilitar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_habilitar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.text_referenciahabilitar);
            this.groupBox2.Controls.Add(this.text_nombrehabilitar);
            this.groupBox2.Controls.Add(this.check_segurohabilitar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button_habilitar);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(270, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 174);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Habilitar";
            // 
            // text_referenciahabilitar
            // 
            this.text_referenciahabilitar.Enabled = false;
            this.text_referenciahabilitar.Location = new System.Drawing.Point(6, 40);
            this.text_referenciahabilitar.Name = "text_referenciahabilitar";
            this.text_referenciahabilitar.Size = new System.Drawing.Size(129, 20);
            this.text_referenciahabilitar.TabIndex = 95;
            // 
            // text_nombrehabilitar
            // 
            this.text_nombrehabilitar.Enabled = false;
            this.text_nombrehabilitar.Location = new System.Drawing.Point(6, 79);
            this.text_nombrehabilitar.Name = "text_nombrehabilitar";
            this.text_nombrehabilitar.Size = new System.Drawing.Size(129, 20);
            this.text_nombrehabilitar.TabIndex = 98;
            // 
            // check_segurohabilitar
            // 
            this.check_segurohabilitar.AutoSize = true;
            this.check_segurohabilitar.BackColor = System.Drawing.Color.Transparent;
            this.check_segurohabilitar.Location = new System.Drawing.Point(27, 116);
            this.check_segurohabilitar.Name = "check_segurohabilitar";
            this.check_segurohabilitar.Size = new System.Drawing.Size(87, 17);
            this.check_segurohabilitar.TabIndex = 94;
            this.check_segurohabilitar.Text = "Estoy seguro";
            this.check_segurohabilitar.UseVisualStyleBackColor = false;
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
            // button_habilitar
            // 
            this.button_habilitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_habilitar.BackgroundImage")));
            this.button_habilitar.Location = new System.Drawing.Point(27, 139);
            this.button_habilitar.Name = "button_habilitar";
            this.button_habilitar.Size = new System.Drawing.Size(100, 23);
            this.button_habilitar.TabIndex = 92;
            this.button_habilitar.Text = "Habilitar";
            this.button_habilitar.UseVisualStyleBackColor = true;
            this.button_habilitar.Click += new System.EventHandler(this.button2_Click);
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
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 193);
            this.groupBox4.TabIndex = 110;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Todos Contenidos Deshabilitados";
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
            // Form_HabilitarContenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(431, 219);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_HabilitarContenido";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_HabilitarContenido_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox text_referenciahabilitar;
        private System.Windows.Forms.TextBox text_nombrehabilitar;
        private System.Windows.Forms.CheckBox check_segurohabilitar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_habilitar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}