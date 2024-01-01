using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.Utilities;
using proyectovinos.ArticuloVino;

namespace proyectovinos.Caracteristicas.clasesvino
{
    public partial class Form_TodasClasesVino : Form
    {
        public Form_TodasClasesVino()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Consultas consultas = new Consultas();

        private string referencia = "";
        private int id_predeterminado = 0;
        private string tabla = "clasevino";
        private string id_tabla = "id_clasevino";
        private string refPredeterminada = "CLS";
        private bool cumplimentarTextos = false;

        private bool cargarLista = true;


        // Función para actualizar las clases de vino
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarCampos('1');
        }

        private void Form_TodasClasesVinoII_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = this.Top + 10;
            id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, textBox_referencia);
            habilitarDeshabilitarEnlaces(true, false, true, false, true, true);
            groupBox1.Enabled = true;
            limpiarCampos('1');
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ut.habilitarOnOff_Caracteristica(tabla, "ref", referencia, '1');
            limpiarCampos('0');
        }

      

        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea deshabilitar el registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                ut.habilitarOnOff_Caracteristica(tabla, "ref", referencia, '0');
                limpiarCampos('1');
            }
        }

        /// <summary>
        /// Función que pone los campos en modo predeterminado.
        /// </summary>
        /// <param name="activo">The activo.</param>
        private void limpiarCampos(char activo)
        {
            cumplimentarTextos = false;
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, activo);
            cumplimentarTextos = true;

            referencia = "";
            textBox_nombre.Text = "";
            textBox_referencia.Text = "";
            id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, textBox_referencia);
        }


        /// <summary>
        /// Función que elimina una clase de vino.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea eliminar el registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
           
                if (referencia != "")
                {
                    Consultas consultas = new Consultas();
                    int id = consultas.obtenerCualquierId(id_tabla, tabla, "ref", referencia);

                    Class_Articulo articulo = new Class_Articulo();
                    int existencias = articulo.existeArticuloConCaracteristica("id_articulo", "articulo", id_tabla, id);

                    if (existencias > 0)
                    {
                        MessageBox.Show(existencias + ClaseCompartida.msgArticulosTipo);
                    }
                    else
                    {
                        consultas.eliminarCaracteristica(tabla, "ref", referencia);
                        limpiarCampos('0');
                    }
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox_nombre.Text != "" || textBox_referencia.Text != "")
            {  
                DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea guardar el registro?", "Aviso", MessageBoxButtons.YesNo);
                if (opcionSeleccionada == DialogResult.Yes)
                {
                    consultas.modificarCualquierTabla(tabla, textBox_referencia.Text, textBox_nombre.Text, "ref", referencia, listView1);
                    limpiarCampos('1');
                }
                else {
                    MessageBox.Show("Tenga cuidado!");
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (textBox_nombre.Text != "" && textBox_referencia.Text != "")
            {

                DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea guardar el registro?", "Aviso", MessageBoxButtons.YesNo);
                if (opcionSeleccionada == DialogResult.Yes)
                {
                    bool insertado = consultas.insertTablaCaracteristicasDinamico(tabla, id_tabla, id_predeterminado, textBox_referencia.Text, textBox_nombre.Text);

                    if (insertado == true)
                        {
                            limpiarCampos('1');
                            id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, textBox_referencia);
                        }
                        else
                        {
                            MessageBox.Show(ClaseCompartida.msgErrorGeneral);
                        }
                    }
                    else
                    {
                       MessageBox.Show("Tenga cuidado!");
                    }
                }
                else {
                MessageBox.Show("No ha seleccionado ninguna referencia");
                }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cumplimentarTextos == true)
            {
                referencia = listView1.Items[e.Item.Index].SubItems[0].Text;

                textBox_referencia.Text = referencia;
                textBox_nombre.Text = listView1.Items[e.Item.Index].SubItems[1].Text;

                textBox_referencia.Text = referencia;
                textBox_nombre.Text = listView1.Items[e.Item.Index].SubItems[1].Text;
            }
        }

        private void radioButton_habilitado_CheckedChanged(object sender, EventArgs e)
        {
            habilitarDeshabilitarEnlaces(true, false, true, false, true, true);
            groupBox1.Enabled = true;
            limpiarCampos('1');
        }


        private void habilitarDeshabilitarEnlaces(bool v1, bool v2, bool v3, bool v4, bool v5, bool v6)
        {
            actualizarToolStripMenuItem.Enabled = v1;
            habilitarToolStripMenuItem.Enabled = v2;
            deshabilitarToolStripMenuItem.Enabled = v3;
            eliminarToolStripMenuItem.Enabled = v4;
            saveToolStripMenuItem.Enabled = v5;
            newToolStripMenuItem.Enabled = v6;
        }


        private void radioButton_deshabilitado_CheckedChanged(object sender, EventArgs e)
        {
            habilitarDeshabilitarEnlaces(false, true, false, true, false, false);
            groupBox5.Enabled = false;
            limpiarCampos('0');
        }
    }
}
