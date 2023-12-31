﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace proyectovinos.Empleados
{
    public partial class Form_HabilitarEmpleados : Form
    {
        public Form_HabilitarEmpleados()
        {
            InitializeComponent();
        }

        Consultas consultas = new Consultas();
        CumplimentarListas cumplimentarlistas = new CumplimentarListas();
      //  CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();
     //   Class_Empleado emp = new Class_Empleado();
        Utilidades ut = new Utilidades();

        private string tabla = "empleado";
       // private string id = "id_empleado";
       // private string refPredeterminada = "EMP";

        private string referencia = "";
        private int /*id_empleado = 0, max_id = 0,*/ primeravez=0;


       // private string refe = "";
        private string nombreApellidos = "";
        private string carpeta = "";



        private void button4_Click(object sender, EventArgs e)
        {
            if (check_seguro.Checked)
            {
                consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '1');
                listView1.Items.Clear();
                //cumplimentarlistas.cumplimentarListaEmpleados(listView1, '0');
                empleado.cumplimentarlistasListaEmpleados(listView1, '0');
                limpiarCampos();
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgSelectRegistro);
            }
        }

  

        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            int index = e.Item.Index;
            string nombre = listView1.Items[index].SubItems[1].Text;
            string apellido1 = listView1.Items[index].SubItems[2].Text;
            string apellido2 = listView1.Items[index].SubItems[3].Text;

            nombreApellidos = nombre + apellido1 + apellido2;
            carpeta = ut.limpiezaDeString(nombreApellidos);

            try
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + carpeta + " / perfil/foto1.jpg";

                using (StreamReader stream = new StreamReader(folderPath))

                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
            catch (Exception ex)
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "empleados/empleadopredeterminada.jpg";
                using (StreamReader stream = new StreamReader(folderPath))
                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (primeravez == 1)
            {
                referencia = e.Item.Text;
                int index = e.Item.Index;
                string nombre = listView1.Items[index].SubItems[1].Text;
                string apellido1 = listView1.Items[index].SubItems[2].Text;
                string apellido2 = listView1.Items[index].SubItems[3].Text;

                text_nombreapellidos.Text = nombre + " " + apellido1 + " " + apellido2;
            }
        }

        Class_Empleado empleado = new Class_Empleado();

        private void Form_HabbilitarEmpleados_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //cumplimentarlistas.cumplimentarListaEmpleados(listView1, '0');
            empleado.cumplimentarlistasListaEmpleados(listView1, '0');
            primeravez = 1;

         /*   // último id
            max_id = consultas.idMax(id, tabla);
            id_empleado = max_id + 1;
            referencia = refPredeterminada + (max_id + 1);*/
        }

        private void limpiarCampos()
        {
            check_seguro.Checked = false;
            pictureBox1.Image = null;
        }
    }
}
