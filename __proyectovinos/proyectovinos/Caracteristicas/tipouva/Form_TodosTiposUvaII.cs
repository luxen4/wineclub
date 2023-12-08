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
    public partial class Form_TodosTiposUvaII : Form
    {
        public Form_TodosTiposUvaII()
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

        private string referencia = "";

        private bool cumplimentarTextos = true;


        // Función que crea...
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

                    tipoUva.insertTipoUva(id_tipouva, text_referencia.Text, text_nombre.Text, id_variedaduva, '1');
                    cumplimentarTextos = false;
                    tipoUva.cumplimentarListaTipoUva(listView1, '1');// No tocar que tiene estructura propia
                    cumplimentarTextos = true;
                    combo_variedaduva.Text = "Seleccione";

                    limpiarCampos();
                    id_tipouva = consultas.referenciaPredeterminada(id_tabla, tabla, "TU", text_referencia);
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        private void limpiarCampos()
        {
            text_nombre.Text = "";
            text_referencia.Text = "";
            combo_variedaduva.Text = "Seleccione"; 
        }


        // Función para actualizar
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cump.refrescarCombo("nombre", "variedaduva", combo_variedaduva);
            cumplimentarTextos = false;
            tipoUva.cumplimentarListaTipoUva(listView1, '1');// No tocar que tiene estructura propia
            cumplimentarTextos = true;
            id_tipouva = consultas.referenciaPredeterminada(id_tabla, tabla, "TU", text_referencia);
           
        }

        private void Form_TodosTiposUvaII_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            // Igual esto a un bloque junto con la implementación de radio de desabilitar
            actualizarToolStripMenuItem.Enabled = false;
            habilitarToolStripMenuItem.Enabled = true;
            deshabilitarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = false;
            newToolStripMenuItem.Enabled = false;
            //
        }

        // Función para habilitar...
        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text_nombre.Text == "" || text_referencia.Text == "")
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
            else
            {
                ut.habilitarOnOff_Caracteristica(tabla, "ref", text_referencia.Text, '1');
                cumplimentarTextos = false;
                tipoUva.cumplimentarListaTipoUva(listView1, '0');// No tocar que tiene estructura propia
                cumplimentarTextos = true;
            }
        }


        // Función para deshabilitar...
        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("METER LOS DIÁLOGOS QUE PREGUNTEN");
            ut.habilitarOnOff_Caracteristica(tabla, "ref", text_referencia.Text, '0');
            cumplimentarTextos = false;
            tipoUva.cumplimentarListaTipoUva(listView1, '1');// No tocar que tiene estructura propia
            cumplimentarTextos = true;
            limpiarCampos();
            
        }

        // Función para eliminar
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (text_referencia.Text != "")
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
                    consultas.eliminarCaracteristica(tabla, "ref", text_referencia.Text);
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
            limpiarCampos();
            cumplimentarTextos = false;
            tipoUva.cumplimentarListaTipoUva(listView1, '0');// No tocar que tiene estructura propia
            cumplimentarTextos = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_variedaduva = consultas.obtenerCualquierId("id_variedaduva", "variedaduva", "nombre", combo_variedaduva.Text);
            tipoUva.modificarTipoUva(text_referencia.Text, text_nombre.Text, id_variedaduva, referencia, listView1);
            cumplimentarTextos = false;
            tipoUva.cumplimentarListaTipoUva(listView1, '1');// No tocar que tiene estructura propia
            cumplimentarTextos = true;
            ut.limpiarCamposModificar(text_referencia, text_nombre, text_referencia);
            combo_variedaduva.Text = "Seleccione";
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cumplimentarTextos == true) { 
                referencia = e.Item.Text; 
                ut.checkMarcadoTodos(cargaLista, e, text_referencia, tabla, text_nombre);
            }
        }

        private void radio_habilitados_CheckedChanged(object sender, EventArgs e)
        {
            actualizarToolStripMenuItem.Enabled = true;
            habilitarToolStripMenuItem.Enabled = false;
            deshabilitarToolStripMenuItem.Enabled = true;
            eliminarToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = true;
            newToolStripMenuItem.Enabled=true;
            cumplimentarTextos = false;
            tipoUva.cumplimentarListaTipoUva(listView1, '1');// No tocar que tiene estructura propia
            cumplimentarTextos = true;
        }

     

        private void radio_deshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            actualizarToolStripMenuItem.Enabled = false;
            habilitarToolStripMenuItem.Enabled = true;
            deshabilitarToolStripMenuItem.Enabled =  false;
            eliminarToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = false;
            newToolStripMenuItem.Enabled = false;
            cumplimentarTextos = false;
            tipoUva.cumplimentarListaTipoUva(listView1, '0');// No tocar que tiene estructura propia
            cumplimentarTextos = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Class_VariedadUvaAperturaForms variedad = new Class_VariedadUvaAperturaForms();
            variedad.todasVariedadesUvaIII();
            //variedad.todasVariedadesUvaII();
        }
    }
}
