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
using proyectovinos.ArticuloVino;
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
            this.Top = this.Top + 10;
            habilitarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = false;
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
            referencia = e.Item.Text;
            id_socio = consultas.obtenerCualquierId("id_socio","socio","ref",referencia);
            int index = e.Item.Index;
            string nombre = listView1.Items[index].SubItems[1].Text;
            string apellido1 = listView1.Items[index].SubItems[2].Text;
            string apellido2 = listView1.Items[index].SubItems[3].Text;

            text_nombreapellidos.Text = nombre + " " + apellido1 + " " + apellido2;
            socio.agregarImagenPictureBoxSocio(id_socio, pictureBox1);
            
        }




        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socioAperturaForms.nuevoSocio(); this.Close();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socioAperturaForms.modificarSocio(); this.Close();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socio.cumplimentarListaSocios(listView1, '1');
            primeravez = 1;
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (referencia != "")
            {
                // Pregunte si está seguro de eliminar y si es sí que lo elimine
                DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea habilitar este socio?", "Aviso", MessageBoxButtons.YesNo);

                if (opcionSeleccionada == DialogResult.Yes)
                {
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '1');
                    listView1.Items.Clear();
                    socio.cumplimentarListaSocios(listView1, '0');
                    limpiarCampos();
                }
                else {
                    MessageBox.Show("Tenga cuidado");
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
            referencia = "";
        }

        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (referencia != "")
            {
                // Pregunte si está seguro de eliminar y si es sí que lo elimine
                DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea deshabilitar este socio?", "Aviso", MessageBoxButtons.YesNo);

                if (opcionSeleccionada == DialogResult.Yes)
                {
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '0');
                    listView1.Items.Clear();
                    socio.cumplimentarListaSocios(listView1, '1');
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("Tenga cuidado");
                }

            }else{
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
            referencia = "";
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (referencia != "")
            {
                // Pregunte si está seguro de eliminar y si es sí que lo elimine
                DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea eliminar este socio?", "Aviso", MessageBoxButtons.YesNo);

                if (opcionSeleccionada == DialogResult.Yes)
                { 
                    int id = consultas.obtenerCualquierId("id_socio", tabla, "ref", referencia);

                    Class_Articulo articulo = new Class_Articulo();
                    int existencias = articulo.existeArticuloConCaracteristica("id_ventasocio", "ventasocio", "id_socio", id);

                    if (existencias > 0)
                    {
                        MessageBox.Show(existencias + ClaseCompartida.msgArticulosTipo);
                    }
                    else
                    {
                        bool eliminado = consultas.eliminarCaracteristica(tabla, "ref", referencia);
                        if (eliminado == true)
                        {
                            Utilidades ut = new Utilidades();
                            ut.eliminarCarpeta("socios", id_socio);

                            listView1.Items.Clear();
                            socio.cumplimentarListaSocios(listView1, '0');
                            limpiarCampos(); 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tenga cuidado");
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            socio.cumplimentarListaSocios(listView1, '1');
            habilitarToolStripMenuItem.Enabled = false;
            deshabilitarToolStripMenuItem.Enabled = true;
            eliminarToolStripMenuItem.Enabled = false;
            actualizarToolStripMenuItem.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            socio.cumplimentarListaSocios(listView1, '0');
            habilitarToolStripMenuItem.Enabled=true;
            deshabilitarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled=true;
            actualizarToolStripMenuItem.Enabled=false;
        }
    }
}
