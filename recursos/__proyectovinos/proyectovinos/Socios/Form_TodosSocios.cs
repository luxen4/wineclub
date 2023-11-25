using System;
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
using proyectovinos.Socios;

namespace proyectovinos
{
    public partial class Form_TodosSocios : Form
    {

        public Form_TodosSocios()
        {
            InitializeComponent();
        }

        private int primeravez = 0;
        private int id_socio = 0;
        private string tabla = "socio";
        private string referencia = "";

        Class_SocioAperturaForms socioAperturaForms = new Class_SocioAperturaForms();
        Class_Socio socio = new Class_Socio();
        Consultas consultas = new Consultas();


        private void Form_TodosSocios_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            socio.cumplimentarListaSocios(listView1,'1');
            primeravez = 1;
        }

      

        // Método Controlador que dirige el proceso de eliminar un Socio
        private void button_eliminar_Click(object sender, EventArgs e)
        {   
            if (check_seguro.Checked)
            {
                if (text_nombreapellidos.Text != "")
                {
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '0');
                    listView1.Items.Clear();
                    socio.cumplimentarListaSocios(listView1,'1');
                    limpiarCampos();
                }
                else {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }  
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }

        private void limpiarCampos()
        {
            text_nombreapellidos.Text = "";
            check_seguro.Checked = false;
            pictureBox1.Image = null;
        }



        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (primeravez == 1)
            {
                referencia = e.Item.Text;
                id_socio = consultas.obtenerCualquierId("id_socio","socio","ref",referencia);
                int index = e.Item.Index;
                string nombre = listView1.Items[index].SubItems[1].Text;
                string apellido1 = listView1.Items[index].SubItems[2].Text;
                string apellido2 = listView1.Items[index].SubItems[3].Text;

                text_nombreapellidos.Text = nombre + " " + apellido1 + " " + apellido2;
                socio.agregarImagenPictureBoxSocio(id_socio, pictureBox1);
            }
        }




        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socioAperturaForms.nuevoSocio(); this.Close();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socioAperturaForms.modificarSocio(); this.Close();
        }

        private void sociosInhabilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socioAperturaForms.socioInhabilitados(); this.Close();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socioAperturaForms.eliminarSocio(); this.Close();
        }
    }
}
