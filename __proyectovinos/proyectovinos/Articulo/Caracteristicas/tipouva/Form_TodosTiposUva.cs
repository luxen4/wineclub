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
using proyectovinos.Caracteristicas.variedaduva;

namespace proyectovinos.Caracteristicas.tipouva
{
    public partial class Form_TodosTiposUva : Form
    {
        public Form_TodosTiposUva()
        {
            InitializeComponent();
        }

        Class_TipoUvaAperturaForms tipoUvaAperturaForms = new Class_TipoUvaAperturaForms();
        Class_TipoUva tipoUva = new Class_TipoUva();
        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();
        CumplimentarComboboxes cump = new CumplimentarComboboxes();

        private int id_tipouva = 0;
        private bool cargaLista = true;

        private string id_tabla = "id_tipouva";
        private string tabla = "tipouva";

        private string referencia = "", nombre = "";

        private bool cumplimentarTextos = true;

        
        /// <summary>
        /// Función que crea.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text_nombre.Text != "" && text_referencia.Text != "")
            {
                if (combo_variedaduva.Text == "Seleccione")
                {
                    MessageBox.Show("Seleccione la variedad de uva");
                }
                else
                {
                    string nombreVariedadUva = combo_variedaduva.Text;
                    int id_variedaduva = consultas.obtenerCualquierId("id_variedaduva", "variedaduva", "nombre", nombreVariedadUva);

                    bool insertado=tipoUva.insertTipoUva(id_tipouva, text_referencia.Text, text_nombre.Text, id_variedaduva, '1');
                    if (insertado==true) { 
                        limpiarCampos('1');
                    }
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        /// <summary>
        /// Función que pone los campos en modo predeterminado.
        /// </summary>
        /// <param name="activo">The activo.</param>
        private void limpiarCampos(char activo)
        {
            cumplimentarTextos = false;
            tipoUva.cumplimentarListaTipoUva(listView1, activo);// No tocar que tiene estructura propia
            cumplimentarTextos = true;

            referencia = "";
            text_nombre.Text = "";
            text_referencia.Text = "";
            combo_variedaduva.Text = "Seleccione";

            cump.refrescarCombo("nombre", "variedaduva", combo_variedaduva);
            id_tipouva = consultas.referenciaPredeterminada(id_tabla, tabla, "TU", text_referencia);
        }


               
        /// <summary>
        /// Función para actualizar los tipos de uva.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarCampos('1');
        }

        private void Form_TodosTiposUvaII_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = this.Top + 19;
            //enlacesHabilitados();
            habilitarDeshabilitarEnlaces(true, false, true, false, true, true);
            groupBox1.Enabled = true;
            limpiarCampos('1');
        }

      
        /// <summary>
        /// Función para habilitar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea habilitar el registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                ut.habilitarOnOff_Caracteristica(tabla, "ref", referencia, '1');
                limpiarCampos('0');
            }
        }

               
        /// <summary>
        /// Función para deshabilitar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
        /// Función para eliminar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea eliminar el registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                if (referencia != "")
                {
                    Consultas consultas = new Consultas();
                    int id = consultas.obtenerCualquierId(id_tabla, tabla, "ref", text_referencia.Text);

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
            }
        }

        /// <summary>
        /// Handles the Click event of the saveToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text_referencia.Text != "" && text_nombre.Text !="" && combo_variedaduva.Text != "Seleccione")
            {
                int id_variedaduva = consultas.obtenerCualquierId("id_variedaduva", "variedaduva", "nombre", combo_variedaduva.Text);
                bool modificado=tipoUva.modificarTipoUva(text_referencia.Text, text_nombre.Text, id_variedaduva, referencia, listView1);
                ut.limpiarCamposModificar(text_referencia, text_nombre, text_referencia);

                if (modificado==true) { 
                    limpiarCampos('1');
                }
               
            }
            else {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        /// <summary>
        /// Handles the ItemChecked event of the listView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemCheckedEventArgs"/> instance containing the event data.</param>
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cumplimentarTextos == true) { 
                
                referencia = e.Item.Text;
                nombre = listView1.Items[e.Item.Index].SubItems[1].Text;

                text_referencia.Text = referencia;
                text_nombre.Text = nombre;
                ut.checkMarcadoTodos(cargaLista, e, text_referencia, tabla, text_nombre);
            }
        }

        /// <summary>
        /// Función-controlador que se ejecuta al marcar el radio habilitados.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radio_habilitados_CheckedChanged(object sender, EventArgs e)
        {
            habilitarDeshabilitarEnlaces(true, false, true, false, true, true);
            groupBox1.Enabled = true;
            limpiarCampos('1');
        }


        /// <summary>
        /// Función-controlador que se ejecuta al marcar el radio deshabilitados.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radio_deshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            habilitarDeshabilitarEnlaces(false, true, false, true, false, false);
            groupBox1.Enabled = false;
            limpiarCampos('0');
        }

        /// <summary>
        /// Función que habilita o deshabilita enlaces.
        /// </summary>
        /// <param name="v1">if set to <c>true</c> [v1].</param>
        /// <param name="v2">if set to <c>true</c> [v2].</param>
        /// <param name="v3">if set to <c>true</c> [v3].</param>
        /// <param name="v4">if set to <c>true</c> [v4].</param>
        /// <param name="v5">if set to <c>true</c> [v5].</param>
        /// <param name="v6">if set to <c>true</c> [v6].</param>
        private void habilitarDeshabilitarEnlaces(bool v1, bool v2, bool v3, bool v4, bool v5, bool v6)
        {   
            actualizarToolStripMenuItem.Enabled = v1;
            habilitarToolStripMenuItem.Enabled = v2;
            deshabilitarToolStripMenuItem.Enabled = v3;
            eliminarToolStripMenuItem.Enabled = v4;
            saveToolStripMenuItem.Enabled = v5;
            newToolStripMenuItem.Enabled = v6;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Class_VariedadUvaAperturaForms variedad = new Class_VariedadUvaAperturaForms();
            variedad.todasVariedadesUva();
        }
    }
}
