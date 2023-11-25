namespace proyectovinos.Articulo
{
    partial class Form_EliminarArticuloVino
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_EliminarArticuloVino));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.check_seguroeliminar = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_unidadestienda = new System.Windows.Forms.TextBox();
            this.text_empaquetado = new System.Windows.Forms.TextBox();
            this.text_unidadesalmacen = new System.Windows.Forms.TextBox();
            this.text_referenciaeliminar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1499, 432);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Todos Articulos Deshabilitados";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader1,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(223, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1268, 353);
            this.listView1.TabIndex = 105;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked_1);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Referencia";
            this.columnHeader14.Width = 69;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tipo de Uva";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Clase de Vino";
            this.columnHeader15.Width = 92;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Proveedor";
            this.columnHeader16.Width = 141;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Catalogación";
            this.columnHeader17.Width = 125;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Denominación";
            this.columnHeader18.Width = 107;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Empaquetado";
            this.columnHeader19.Width = 95;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Formato";
            this.columnHeader20.Width = 89;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Min Almacén";
            this.columnHeader21.Width = 75;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Max. Almacén";
            this.columnHeader22.Width = 84;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Min. Tienda";
            this.columnHeader23.Width = 69;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Max. Tienda";
            this.columnHeader24.Width = 71;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "E. Almacén";
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "E. Tienda";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btn_eliminar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.check_seguroeliminar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.text_unidadestienda);
            this.groupBox2.Controls.Add(this.text_empaquetado);
            this.groupBox2.Controls.Add(this.text_unidadesalmacen);
            this.groupBox2.Controls.Add(this.text_referenciaeliminar);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(6, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 142);
            this.groupBox2.TabIndex = 104;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Eliminar";
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.BackgroundImage")));
            this.btn_eliminar.Location = new System.Drawing.Point(45, 113);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(125, 23);
            this.btn_eliminar.TabIndex = 77;
            this.btn_eliminar.Text = "Eliminar";
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
            // check_seguroeliminar
            // 
            this.check_seguroeliminar.AutoSize = true;
            this.check_seguroeliminar.BackColor = System.Drawing.Color.Transparent;
            this.check_seguroeliminar.Location = new System.Drawing.Point(95, 95);
            this.check_seguroeliminar.Name = "check_seguroeliminar";
            this.check_seguroeliminar.Size = new System.Drawing.Size(87, 17);
            this.check_seguroeliminar.TabIndex = 78;
            this.check_seguroeliminar.Text = "Estoy seguro";
            this.check_seguroeliminar.UseVisualStyleBackColor = false;
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
            // text_referenciaeliminar
            // 
            this.text_referenciaeliminar.Enabled = false;
            this.text_referenciaeliminar.Location = new System.Drawing.Point(131, 19);
            this.text_referenciaeliminar.Name = "text_referenciaeliminar";
            this.text_referenciaeliminar.Size = new System.Drawing.Size(80, 20);
            this.text_referenciaeliminar.TabIndex = 101;
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
            // Form_EliminarArticuloVino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1523, 456);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_EliminarArticuloVino";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_EliminarArticuloVino_Load);
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
        private System.Windows.Forms.CheckBox check_seguroeliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_unidadestienda;
        private System.Windows.Forms.TextBox text_empaquetado;
        private System.Windows.Forms.TextBox text_unidadesalmacen;
        private System.Windows.Forms.TextBox text_referenciaeliminar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
    }
}