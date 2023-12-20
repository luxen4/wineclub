namespace proyectovinos.Empleados.usuariocontrasena
{
    partial class Form_ModificarEmpleadoUsuarioContrasena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ModificarEmpleadoUsuarioContrasena));
            this.textBox_usuarioactual = new System.Windows.Forms.TextBox();
            this.textBox_nuevousuario = new System.Windows.Forms.TextBox();
            this.textBox_nuevacontrasena = new System.Windows.Forms.TextBox();
            this.textBox_contrasenaactual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_seguro = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_usuarioactual
            // 
            this.textBox_usuarioactual.Location = new System.Drawing.Point(68, 52);
            this.textBox_usuarioactual.Name = "textBox_usuarioactual";
            this.textBox_usuarioactual.Size = new System.Drawing.Size(100, 20);
            this.textBox_usuarioactual.TabIndex = 0;
            // 
            // textBox_nuevousuario
            // 
            this.textBox_nuevousuario.Location = new System.Drawing.Point(206, 52);
            this.textBox_nuevousuario.Name = "textBox_nuevousuario";
            this.textBox_nuevousuario.Size = new System.Drawing.Size(100, 20);
            this.textBox_nuevousuario.TabIndex = 1;
            // 
            // textBox_nuevacontrasena
            // 
            this.textBox_nuevacontrasena.Location = new System.Drawing.Point(206, 105);
            this.textBox_nuevacontrasena.Name = "textBox_nuevacontrasena";
            this.textBox_nuevacontrasena.Size = new System.Drawing.Size(100, 20);
            this.textBox_nuevacontrasena.TabIndex = 3;
            // 
            // textBox_contrasenaactual
            // 
            this.textBox_contrasenaactual.Location = new System.Drawing.Point(68, 105);
            this.textBox_contrasenaactual.Name = "textBox_contrasenaactual";
            this.textBox_contrasenaactual.Size = new System.Drawing.Size(100, 20);
            this.textBox_contrasenaactual.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuario actual:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contraseña actual:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nuevo usuario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nueva Contraseña:";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(138, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_seguro
            // 
            this.checkBox_seguro.AutoSize = true;
            this.checkBox_seguro.Location = new System.Drawing.Point(147, 133);
            this.checkBox_seguro.Name = "checkBox_seguro";
            this.checkBox_seguro.Size = new System.Drawing.Size(87, 17);
            this.checkBox_seguro.TabIndex = 11;
            this.checkBox_seguro.Text = "Estoy seguro";
            this.checkBox_seguro.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.textBox_usuarioactual);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox_seguro);
            this.groupBox1.Controls.Add(this.textBox_nuevousuario);
            this.groupBox1.Controls.Add(this.textBox_contrasenaactual);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_nuevacontrasena);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 185);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Usuario y Contraseña";
            // 
            // Form_ModificarEmpleadoUsuarioContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(388, 203);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ModificarEmpleadoUsuarioContrasena";
            this.Text = "WINE CLUB";
            this.Load += new System.EventHandler(this.Form_ModificarEmpleadoUsuarioContrasena_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_usuarioactual;
        private System.Windows.Forms.TextBox textBox_nuevousuario;
        private System.Windows.Forms.TextBox textBox_nuevacontrasena;
        private System.Windows.Forms.TextBox textBox_contrasenaactual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_seguro;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}