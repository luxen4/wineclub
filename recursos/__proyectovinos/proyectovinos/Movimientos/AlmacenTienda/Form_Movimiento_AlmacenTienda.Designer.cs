namespace proyectovinos
{
    partial class Form_Movimiento_AlmacenTienda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Movimiento_AlmacenTienda));
            this.btn_traspasoAlmacen = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.text_formatocontenido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_empaquetado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_unidadesalmacen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_unidadestienda = new System.Windows.Forms.TextBox();
            this.numericUpDown_unidadesamover = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.text_existmaximas = new System.Windows.Forms.TextBox();
            this.combo_reflineacompraproveedor = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.combo_refarticulo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.text_catalogacion = new System.Windows.Forms.TextBox();
            this.text_denominacion = new System.Windows.Forms.TextBox();
            this.text_clasevino = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.text_proveedor = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pROVEEDORESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraAProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_unidadesamover)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_traspasoAlmacen
            // 
            this.btn_traspasoAlmacen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_traspasoAlmacen.BackgroundImage")));
            this.btn_traspasoAlmacen.Enabled = false;
            this.btn_traspasoAlmacen.Location = new System.Drawing.Point(458, 246);
            this.btn_traspasoAlmacen.Name = "btn_traspasoAlmacen";
            this.btn_traspasoAlmacen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_traspasoAlmacen.Size = new System.Drawing.Size(105, 23);
            this.btn_traspasoAlmacen.TabIndex = 99;
            this.btn_traspasoAlmacen.Text = "Traspaso a Tienda";
            this.btn_traspasoAlmacen.UseVisualStyleBackColor = true;
            this.btn_traspasoAlmacen.Click += new System.EventHandler(this.btn_traspasoaTienda);
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.Location = new System.Drawing.Point(385, 246);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 23);
            this.button5.TabIndex = 98;
            this.button5.Text = "Limpiar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.text_formatocontenido);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.text_empaquetado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.text_unidadesalmacen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.text_unidadestienda);
            this.groupBox1.Location = new System.Drawing.Point(401, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 134);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Existencias";
            // 
            // text_formatocontenido
            // 
            this.text_formatocontenido.Enabled = false;
            this.text_formatocontenido.Location = new System.Drawing.Point(102, 98);
            this.text_formatocontenido.Name = "text_formatocontenido";
            this.text_formatocontenido.Size = new System.Drawing.Size(109, 20);
            this.text_formatocontenido.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(1, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Formato/Contenido";
            // 
            // text_empaquetado
            // 
            this.text_empaquetado.Enabled = false;
            this.text_empaquetado.Location = new System.Drawing.Point(102, 72);
            this.text_empaquetado.Name = "text_empaquetado";
            this.text_empaquetado.Size = new System.Drawing.Size(109, 20);
            this.text_empaquetado.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(48, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Almacén";
            // 
            // text_unidadesalmacen
            // 
            this.text_unidadesalmacen.Enabled = false;
            this.text_unidadesalmacen.Location = new System.Drawing.Point(102, 20);
            this.text_unidadesalmacen.Name = "text_unidadesalmacen";
            this.text_unidadesalmacen.Size = new System.Drawing.Size(45, 20);
            this.text_unidadesalmacen.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(56, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Tienda";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(26, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Empaquetado";
            // 
            // text_unidadestienda
            // 
            this.text_unidadestienda.Enabled = false;
            this.text_unidadestienda.Location = new System.Drawing.Point(102, 46);
            this.text_unidadestienda.Name = "text_unidadestienda";
            this.text_unidadestienda.Size = new System.Drawing.Size(45, 20);
            this.text_unidadestienda.TabIndex = 43;
            // 
            // numericUpDown_unidadesamover
            // 
            this.numericUpDown_unidadesamover.Enabled = false;
            this.numericUpDown_unidadesamover.Location = new System.Drawing.Point(287, 249);
            this.numericUpDown_unidadesamover.Name = "numericUpDown_unidadesamover";
            this.numericUpDown_unidadesamover.Size = new System.Drawing.Size(89, 20);
            this.numericUpDown_unidadesamover.TabIndex = 41;
            this.numericUpDown_unidadesamover.ValueChanged += new System.EventHandler(this.numericUpDown_unidadesamover_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(284, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Traspaso a tienda";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.text_existmaximas);
            this.groupBox2.Controls.Add(this.combo_reflineacompraproveedor);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.combo_refarticulo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.btn_traspasoAlmacen);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.numericUpDown_unidadesamover);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 291);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "De Almacén a Tienda";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(385, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 136;
            this.label8.Text = "Ref. Linea en tienda:";
            // 
            // text_existmaximas
            // 
            this.text_existmaximas.Enabled = false;
            this.text_existmaximas.Location = new System.Drawing.Point(218, 249);
            this.text_existmaximas.Name = "text_existmaximas";
            this.text_existmaximas.Size = new System.Drawing.Size(63, 20);
            this.text_existmaximas.TabIndex = 139;
            // 
            // combo_reflineacompraproveedor
            // 
            this.combo_reflineacompraproveedor.Enabled = false;
            this.combo_reflineacompraproveedor.FormattingEnabled = true;
            this.combo_reflineacompraproveedor.Location = new System.Drawing.Point(388, 49);
            this.combo_reflineacompraproveedor.Name = "combo_reflineacompraproveedor";
            this.combo_reflineacompraproveedor.Size = new System.Drawing.Size(103, 21);
            this.combo_reflineacompraproveedor.TabIndex = 135;
            this.combo_reflineacompraproveedor.SelectedIndexChanged += new System.EventHandler(this.combo_reflinea_SelectedIndexChanged);
            this.combo_reflineacompraproveedor.MouseHover += new System.EventHandler(this.combo_reflineacompraproveedor_MouseHover);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(186, 36);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 142;
            this.pictureBox3.TabStop = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(243, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 141;
            this.label11.Text = "Ref. Articulo";
            // 
            // combo_refarticulo
            // 
            this.combo_refarticulo.FormattingEnabled = true;
            this.combo_refarticulo.Location = new System.Drawing.Point(246, 49);
            this.combo_refarticulo.Name = "combo_refarticulo";
            this.combo_refarticulo.Size = new System.Drawing.Size(130, 21);
            this.combo_refarticulo.TabIndex = 140;
            this.combo_refarticulo.Text = "Seleccione";
            this.combo_refarticulo.SelectedIndexChanged += new System.EventHandler(this.combo_refarticulo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(215, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 138;
            this.label2.Text = "Max. Tienda";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(511, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(107, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 112;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.text_catalogacion);
            this.groupBox3.Controls.Add(this.text_denominacion);
            this.groupBox3.Controls.Add(this.text_clasevino);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.text_proveedor);
            this.groupBox3.Location = new System.Drawing.Point(184, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(211, 134);
            this.groupBox3.TabIndex = 132;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(19, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 144;
            this.label12.Text = "Catalogación:";
            // 
            // text_catalogacion
            // 
            this.text_catalogacion.Enabled = false;
            this.text_catalogacion.Location = new System.Drawing.Point(94, 99);
            this.text_catalogacion.Name = "text_catalogacion";
            this.text_catalogacion.Size = new System.Drawing.Size(111, 20);
            this.text_catalogacion.TabIndex = 143;
            // 
            // text_denominacion
            // 
            this.text_denominacion.Enabled = false;
            this.text_denominacion.Location = new System.Drawing.Point(94, 72);
            this.text_denominacion.Name = "text_denominacion";
            this.text_denominacion.Size = new System.Drawing.Size(111, 20);
            this.text_denominacion.TabIndex = 130;
            // 
            // text_clasevino
            // 
            this.text_clasevino.Enabled = false;
            this.text_clasevino.Location = new System.Drawing.Point(94, 46);
            this.text_clasevino.Name = "text_clasevino";
            this.text_clasevino.Size = new System.Drawing.Size(111, 20);
            this.text_clasevino.TabIndex = 110;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(16, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 13);
            this.label19.TabIndex = 122;
            this.label19.Text = "Clase de Vino:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(29, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 114;
            this.label10.Text = "Proveedor:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(59, 75);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 13);
            this.label22.TabIndex = 120;
            this.label22.Text = "D.O.";
            // 
            // text_proveedor
            // 
            this.text_proveedor.Enabled = false;
            this.text_proveedor.Location = new System.Drawing.Point(94, 20);
            this.text_proveedor.Name = "text_proveedor";
            this.text_proveedor.Size = new System.Drawing.Size(111, 20);
            this.text_proveedor.TabIndex = 113;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pROVEEDORESToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 110;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pROVEEDORESToolStripMenuItem
            // 
            this.pROVEEDORESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compraAProveedorToolStripMenuItem});
            this.pROVEEDORESToolStripMenuItem.Name = "pROVEEDORESToolStripMenuItem";
            this.pROVEEDORESToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.pROVEEDORESToolStripMenuItem.Text = "PROVEEDORES";
            // 
            // compraAProveedorToolStripMenuItem
            // 
            this.compraAProveedorToolStripMenuItem.Name = "compraAProveedorToolStripMenuItem";
            this.compraAProveedorToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.compraAProveedorToolStripMenuItem.Text = "Compra a Proveedor";
            this.compraAProveedorToolStripMenuItem.Click += new System.EventHandler(this.compraAProveedorToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(565, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 113;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form_Movimiento_AlmacenTienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(652, 354);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form_Movimiento_AlmacenTienda";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_Movimiento_AlmacenTienda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_unidadesamover)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_traspasoAlmacen;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox text_empaquetado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_unidadesalmacen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_unidadestienda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_unidadesamover;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox text_formatocontenido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox text_denominacion;
        private System.Windows.Forms.TextBox text_clasevino;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_proveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combo_reflineacompraproveedor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pROVEEDORESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraAProveedorToolStripMenuItem;
        private System.Windows.Forms.TextBox text_existmaximas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox combo_refarticulo;
        private System.Windows.Forms.TextBox text_catalogacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
    }
}