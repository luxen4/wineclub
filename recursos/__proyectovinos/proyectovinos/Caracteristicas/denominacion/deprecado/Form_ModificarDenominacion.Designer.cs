namespace proyectovinos
{
    partial class Form_ModificarDenominacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ModificarDenominacion));
            this.label2 = new System.Windows.Forms.Label();
            this.text_nuevonombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.text_referencia = new System.Windows.Forms.TextBox();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_nuevareferencia = new System.Windows.Forms.Label();
            this.text_nuevareferencia = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(240, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Nuevo Nombre";
            // 
            // text_nuevonombre
            // 
            this.text_nuevonombre.Location = new System.Drawing.Point(243, 133);
            this.text_nuevonombre.Name = "text_nuevonombre";
            this.text_nuevonombre.Size = new System.Drawing.Size(194, 20);
            this.text_nuevonombre.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(279, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Ref.";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(243, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 23);
            this.button2.TabIndex = 65;
            this.button2.Text = "Modificar Denominación";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(243, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 64;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.text_referencia);
            this.groupBox1.Controls.Add(this.button_cerrar);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label_nuevareferencia);
            this.groupBox1.Controls.Add(this.text_nuevareferencia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.text_nuevonombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 219);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Denominación";
            // 
            // text_referencia
            // 
            this.text_referencia.Enabled = false;
            this.text_referencia.Location = new System.Drawing.Point(303, 30);
            this.text_referencia.Name = "text_referencia";
            this.text_referencia.Size = new System.Drawing.Size(134, 20);
            this.text_referencia.TabIndex = 84;
            // 
            // button_cerrar
            // 
            this.button_cerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_cerrar.BackgroundImage")));
            this.button_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cerrar.Location = new System.Drawing.Point(362, 190);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(75, 23);
            this.button_cerrar.TabIndex = 80;
            this.button_cerrar.Text = "Cerrar";
            this.button_cerrar.UseVisualStyleBackColor = true;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(231, 183);
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
            // label_nuevareferencia
            // 
            this.label_nuevareferencia.AutoSize = true;
            this.label_nuevareferencia.BackColor = System.Drawing.Color.Transparent;
            this.label_nuevareferencia.Location = new System.Drawing.Point(240, 77);
            this.label_nuevareferencia.Name = "label_nuevareferencia";
            this.label_nuevareferencia.Size = new System.Drawing.Size(94, 13);
            this.label_nuevareferencia.TabIndex = 81;
            this.label_nuevareferencia.Text = "Nueva Referencia";
            // 
            // text_nuevareferencia
            // 
            this.text_nuevareferencia.Location = new System.Drawing.Point(243, 93);
            this.text_nuevareferencia.Name = "text_nuevareferencia";
            this.text_nuevareferencia.Size = new System.Drawing.Size(194, 20);
            this.text_nuevareferencia.TabIndex = 80;
            // 
            // Form_ModificarDenominacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(468, 240);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_ModificarDenominacion";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_ModificarDenominacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_nuevonombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_cerrar;
        private System.Windows.Forms.Label label_nuevareferencia;
        private System.Windows.Forms.TextBox text_nuevareferencia;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox text_referencia;
    }
}