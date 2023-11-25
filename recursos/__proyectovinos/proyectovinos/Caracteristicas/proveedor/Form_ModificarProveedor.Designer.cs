namespace proyectovinos
{
    partial class Form_ModificarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ModificarProveedor));
            this.label2 = new System.Windows.Forms.Label();
            this.text_nombre = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_cambioimagen = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_anadirimagen = new System.Windows.Forms.Button();
            this.text_referencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.text_email = new System.Windows.Forms.TextBox();
            this.text_localidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.text_provincia = new System.Windows.Forms.TextBox();
            this.text_telefono = new System.Windows.Forms.TextBox();
            this.text_direccion = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(248, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Nombre";
            // 
            // text_nombre
            // 
            this.text_nombre.Location = new System.Drawing.Point(251, 74);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(153, 20);
            this.text_nombre.TabIndex = 67;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(531, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 65;
            this.button2.Text = "Modificar Proveedor";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(437, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 64;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.Controls.Add(this.checkBox_cambioimagen);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.button_anadirimagen);
            this.groupBox1.Controls.Add(this.text_referencia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.text_email);
            this.groupBox1.Controls.Add(this.text_localidad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.text_provincia);
            this.groupBox1.Controls.Add(this.text_telefono);
            this.groupBox1.Controls.Add(this.text_direccion);
            this.groupBox1.Controls.Add(this.text_nombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 298);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Proveedor";
            // 
            // checkBox_cambioimagen
            // 
            this.checkBox_cambioimagen.AutoSize = true;
            this.checkBox_cambioimagen.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_cambioimagen.Location = new System.Drawing.Point(418, 98);
            this.checkBox_cambioimagen.Name = "checkBox_cambioimagen";
            this.checkBox_cambioimagen.Size = new System.Drawing.Size(114, 17);
            this.checkBox_cambioimagen.TabIndex = 96;
            this.checkBox_cambioimagen.Text = "Cambio de Imagen";
            this.checkBox_cambioimagen.UseVisualStyleBackColor = false;
            this.checkBox_cambioimagen.CheckedChanged += new System.EventHandler(this.checkBox_cambioimagen_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(519, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(107, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 95;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(248, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Referencia";
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
            this.listView1.Size = new System.Drawing.Size(236, 269);
            this.listView1.TabIndex = 83;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Referencia";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre";
            this.columnHeader2.Width = 150;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(418, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 138);
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // button_anadirimagen
            // 
            this.button_anadirimagen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_anadirimagen.BackgroundImage")));
            this.button_anadirimagen.Location = new System.Drawing.Point(418, 265);
            this.button_anadirimagen.Name = "button_anadirimagen";
            this.button_anadirimagen.Size = new System.Drawing.Size(214, 23);
            this.button_anadirimagen.TabIndex = 65;
            this.button_anadirimagen.Text = "Añadir imagen";
            this.button_anadirimagen.UseVisualStyleBackColor = true;
            this.button_anadirimagen.Click += new System.EventHandler(this.button6_Click);
            // 
            // text_referencia
            // 
            this.text_referencia.Location = new System.Drawing.Point(251, 34);
            this.text_referencia.Name = "text_referencia";
            this.text_referencia.Size = new System.Drawing.Size(153, 20);
            this.text_referencia.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(248, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "Provincia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(248, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 91;
            this.label6.Text = "Teléfono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(248, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 93;
            this.label8.Text = "email";
            // 
            // text_email
            // 
            this.text_email.Location = new System.Drawing.Point(251, 269);
            this.text_email.Name = "text_email";
            this.text_email.Size = new System.Drawing.Size(153, 20);
            this.text_email.TabIndex = 94;
            // 
            // text_localidad
            // 
            this.text_localidad.Location = new System.Drawing.Point(251, 152);
            this.text_localidad.Name = "text_localidad";
            this.text_localidad.Size = new System.Drawing.Size(153, 20);
            this.text_localidad.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(248, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Dirección";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(248, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 87;
            this.label10.Text = "Localidad";
            // 
            // text_provincia
            // 
            this.text_provincia.Location = new System.Drawing.Point(251, 191);
            this.text_provincia.Name = "text_provincia";
            this.text_provincia.Size = new System.Drawing.Size(153, 20);
            this.text_provincia.TabIndex = 90;
            // 
            // text_telefono
            // 
            this.text_telefono.Location = new System.Drawing.Point(251, 230);
            this.text_telefono.Name = "text_telefono";
            this.text_telefono.Size = new System.Drawing.Size(153, 20);
            this.text_telefono.TabIndex = 92;
            // 
            // text_direccion
            // 
            this.text_direccion.Location = new System.Drawing.Point(251, 113);
            this.text_direccion.Name = "text_direccion";
            this.text_direccion.Size = new System.Drawing.Size(153, 20);
            this.text_direccion.TabIndex = 86;
            // 
            // Form_ModificarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(658, 337);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_ModificarProveedor";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_ModificarProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_nombre;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_referencia;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_anadirimagen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox text_email;
        private System.Windows.Forms.TextBox text_localidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_provincia;
        private System.Windows.Forms.TextBox text_telefono;
        private System.Windows.Forms.TextBox text_direccion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBox_cambioimagen;
    }
}