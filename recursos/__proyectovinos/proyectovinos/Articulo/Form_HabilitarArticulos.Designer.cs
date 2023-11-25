namespace proyectovinos.Articulo
{
    partial class Form_HabilitarArticulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_HabilitarArticulos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.check_seguro = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_unidadestienda = new System.Windows.Forms.TextBox();
            this.text_empaquetado = new System.Windows.Forms.TextBox();
            this.text_unidadesalmacen = new System.Windows.Forms.TextBox();
            this.text_refarticulo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1412, 432);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Todos Articulos Deshabilitados";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btn_eliminar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.check_seguro);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.text_unidadestienda);
            this.groupBox2.Controls.Add(this.text_empaquetado);
            this.groupBox2.Controls.Add(this.text_unidadesalmacen);
            this.groupBox2.Controls.Add(this.text_refarticulo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(6, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 142);
            this.groupBox2.TabIndex = 104;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Habilitar";
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.BackgroundImage")));
            this.btn_eliminar.Location = new System.Drawing.Point(45, 113);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(125, 23);
            this.btn_eliminar.TabIndex = 77;
            this.btn_eliminar.Text = "Habilitar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(4, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Almacén";
            // 
            // check_seguro
            // 
            this.check_seguro.AutoSize = true;
            this.check_seguro.BackColor = System.Drawing.Color.Transparent;
            this.check_seguro.Location = new System.Drawing.Point(95, 95);
            this.check_seguro.Name = "check_seguro";
            this.check_seguro.Size = new System.Drawing.Size(87, 17);
            this.check_seguro.TabIndex = 78;
            this.check_seguro.Text = "Estoy seguro";
            this.check_seguro.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(58, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Tienda";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(111, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 102;
            this.label6.Text = "Empaquetado";
            // 
            // text_unidadestienda
            // 
            this.text_unidadestienda.Enabled = false;
            this.text_unidadestienda.Location = new System.Drawing.Point(64, 69);
            this.text_unidadestienda.Name = "text_unidadestienda";
            this.text_unidadestienda.Size = new System.Drawing.Size(44, 20);
            this.text_unidadestienda.TabIndex = 71;
            // 
            // text_empaquetado
            // 
            this.text_empaquetado.Enabled = false;
            this.text_empaquetado.Location = new System.Drawing.Point(114, 69);
            this.text_empaquetado.Name = "text_empaquetado";
            this.text_empaquetado.Size = new System.Drawing.Size(97, 20);
            this.text_empaquetado.TabIndex = 103;
            // 
            // text_unidadesalmacen
            // 
            this.text_unidadesalmacen.Enabled = false;
            this.text_unidadesalmacen.Location = new System.Drawing.Point(7, 69);
            this.text_unidadesalmacen.Name = "text_unidadesalmacen";
            this.text_unidadesalmacen.Size = new System.Drawing.Size(45, 20);
            this.text_unidadesalmacen.TabIndex = 69;
            // 
            // text_refarticulo
            // 
            this.text_refarticulo.Enabled = false;
            this.text_refarticulo.Location = new System.Drawing.Point(131, 19);
            this.text_refarticulo.Name = "text_refarticulo";
            this.text_refarticulo.Size = new System.Drawing.Size(80, 20);
            this.text_refarticulo.TabIndex = 101;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(74, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 100;
            this.label13.Text = "Referencia";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 260);
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // listView1
            // 
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
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(228, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1177, 407);
            this.listView1.TabIndex = 64;
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
            this.columnHeader2.Text = "Clase de Vino";
            this.columnHeader2.Width = 92;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Proveedor";
            this.columnHeader3.Width = 141;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Catalogación";
            this.columnHeader4.Width = 125;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Denominación";
            this.columnHeader6.Width = 129;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Empaquetado";
            this.columnHeader5.Width = 95;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Formato";
            this.columnHeader7.Width = 103;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Min Almacén";
            this.columnHeader8.Width = 75;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Max. Almacén";
            this.columnHeader9.Width = 84;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Min. Tienda";
            this.columnHeader10.Width = 69;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Max. Tienda";
            this.columnHeader11.Width = 71;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "E. Almacén";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "E. Tienda";
            // 
            // Form_HabilitarArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1423, 458);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_HabilitarArticulos";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_HabilitarArticulos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox check_seguro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_unidadestienda;
        private System.Windows.Forms.TextBox text_empaquetado;
        private System.Windows.Forms.TextBox text_unidadesalmacen;
        private System.Windows.Forms.TextBox text_refarticulo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
    }
}