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
            this.Top = this.Top + 20;
            habilitarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = false;
        }




        /// <summary>
        /// Método Controlador que dirige el proceso de eliminar un Socio.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_eliminar_Click(object sender, EventArgs e)
        {   
            if (check_seguro.Checked)
            {
                if (text_nombreapellidos.Text != "")
                {
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '0');
                    //listView1.Items.Clear();
                    //socio.cumplimentarListaSocios(listView1,'1');
                    limpiarCampos('1');
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

  

        private bool cargaLista = false;
        Utilidades ut = new Utilidades();

        /// <summary>
        /// Handles the ItemChecked event of the listView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemCheckedEventArgs"/> instance containing the event data.</param>
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            while (cargaLista == false)
            {
                cargaLista = true;
                ut.limpiarChecks(listView1, e);

                referencia = e.Item.Text;
                id_socio = consultas.obtenerCualquierId("id_socio", "socio", "ref", referencia);
                int index = e.Item.Index;
                string nombre = listView1.Items[index].SubItems[1].Text;
                string apellido1 = listView1.Items[index].SubItems[2].Text;
                string apellido2 = listView1.Items[index].SubItems[3].Text;

                text_nombreapellidos.Text = nombre + " " + apellido1 + " " + apellido2;
                socio.agregarImagenPictureBoxSocio(id_socio, pictureBox1);

            }
            cargaLista = false;
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            socio.cumplimentarListaSocios(listView1, '1');
            referencia = "";
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
                    //listView1.Items.Clear();
                    //socio.cumplimentarListaSocios(listView1, '0');
                    limpiarCampos('0');
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


        /// <summary>
        /// Función-controlador que desabilita un socio.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (referencia != "")
            {  
                bool afirmativo = ut.realmenteDesea("deshabilitar","socio");
                if (afirmativo == true)
                {
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '0');
                    limpiarCampos('1');
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


        /// <summary>
        /// Controlador para eliminar un socio.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

                            //listView1.Items.Clear();
                            //socio.cumplimentarListaSocios(listView1, '0');
                            limpiarCampos('0'); 
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

        /// <summary>
        /// Función-controlador que habilita y deshabilita enlaces del menuStrip y cumplimenta la lista de socios habilitados.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ut.habilitarEnlacesMenuStripSinNewNiSave(actualizarToolStripMenuItem, habilitarToolStripMenuItem, 
                deshabilitarToolStripMenuItem, eliminarToolStripMenuItem);

            limpiarCampos('1');
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ut.deshabilitarEnlacesMenuStripSinNewNiSave(actualizarToolStripMenuItem, habilitarToolStripMenuItem, 
                deshabilitarToolStripMenuItem, eliminarToolStripMenuItem);
            
            limpiarCampos('0');
        }

        // Apertura de formularios

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            socioAperturaForms.nuevoSocio(); 
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            socioAperturaForms.modificarSocio(); 
        }


        /// <summary>
        /// Función que pone los campos en modo predeterminado.
        /// </summary>
        private void limpiarCampos(char opcion)
        {
            text_nombreapellidos.Text = "";
            check_seguro.Checked = false;
            pictureBox1.Image = null;
           


            listView1.Items.Clear();
            socio.cumplimentarListaSocios(listView1, opcion); 
            referencia = "";

            if (opcion == '1') {
                groupBox1.Text = "Todos Socios Habilitados";
            } else if (opcion == '0') {
                groupBox1.Text = "Todos Socios Deshabilitados";
            }
           
        }
    }
}
