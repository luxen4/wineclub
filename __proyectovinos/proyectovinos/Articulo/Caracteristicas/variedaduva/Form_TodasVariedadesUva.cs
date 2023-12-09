using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.ArticuloVino;

namespace proyectovinos.Caracteristicas.variedaduva
{
    public partial class Form_TodasVariedadesUva : Form
    {
        public Form_TodasVariedadesUva()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Consultas consultas = new Consultas();

        private string referencia = "";
        private int id_predeterminado = 0;
        private string tabla = "variedaduva";
        private string id_tabla = "id_variedaduva";
        private string refPredeterminada = "VU";

        public bool cargarLista = false;

        private void Form_TodasVariedadesUvaIII_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            habilitarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = false;
        }


        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, textBox_referencia);
            cargarLista = true;
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            cargarLista = false;
            limpiarCampos();
        }



        // Función para habilitar
        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox_referencia.Text != "")
            {
                DialogResult opcionSeleccionada = MessageBox.Show("¿Seguro que quiere modificar?", "Aviso", MessageBoxButtons.YesNo);
                if (opcionSeleccionada == DialogResult.Yes)
                {
                    ut.habilitarOnOff_Caracteristica(tabla, "ref", textBox_referencia.Text, '1');
                    CumplimentarListas cumplimentarListas = new CumplimentarListas();
                    listView1.Items.Clear();
                    referencia = "";
                    cargarLista=true;
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
                    cargarLista=false;
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("Seleccione una referencia");
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado una referencia");
            }
        }


        // Función para deshabilitar variedades de ucva
        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox_referencia.Text != "") {
                DialogResult opcionSeleccionada = MessageBox.Show("¿Seguro que quiere modificar?", "Aviso", MessageBoxButtons.YesNo);
                if (opcionSeleccionada == DialogResult.Yes)
                {
                    ut.habilitarOnOff_Caracteristica(tabla, "ref", textBox_referencia.Text, '0');
                    CumplimentarListas cumplimentarListas = new CumplimentarListas();
                    listView1.Items.Clear();
                    referencia = "";
                    cargarLista=true;
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                    cargarLista = false;
                    limpiarCampos();
                }else
                {
                    MessageBox.Show("Tenga cuidado");
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado una referencia");
            }
        }

        private void limpiarCampos()
        {
            textBox_referencia.Text = "";
            textBox_nombre.Text = "";
        }

        // Función que elimina
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (textBox_referencia.Text != "")
            {
                DialogResult opcionSeleccionada = MessageBox.Show("¿Seguro que quiere eliminar?", "Aviso", MessageBoxButtons.YesNo);
                if (opcionSeleccionada == DialogResult.Yes)
                {                    
                    Consultas consultas = new Consultas();
                    int id = consultas.obtenerCualquierId(id_tabla, tabla, "ref", textBox_referencia.Text);

                    Class_Articulo articulo = new Class_Articulo();
                    int existencias = articulo.existeArticuloConCaracteristica("id_variedaduva", "tipouva", id_tabla, id);
                    if (existencias > 0)
                    {
                        MessageBox.Show(existencias + " tipos de uva dependen de esta variedad, \n no se puede eliminar");
                        
                        // Recorrer todos los controles en el formulario
                        foreach (Control control in Controls)
                        {
                            // Verificar si el control es un CheckBox
                            if (control is CheckBox checkBox)
                            {
                                // Establecer la propiedad Checked en false para deseleccionarlo
                                checkBox.Checked = false;
                            }
                        }
                    }
                    else
                    {
                        consultas.eliminarCaracteristica(tabla, "ref", textBox_referencia.Text);
                        referencia = "";
                        cargarLista = true;
                        cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
                        cargarLista = false;
                    }

                }
                else {
                    MessageBox.Show("Tenga cuidado!");
                }
            }else
            {
                MessageBox.Show("Seleccione una referencia en eliminar");
            }
                limpiarCampos();
      
        }

        // Función que modifica
        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox_nombre.Text != "" || referencia != "")
            {    
                DialogResult opcionSeleccionada = MessageBox.Show("¿Seguro que quiere guardar?", "Aviso", MessageBoxButtons.YesNo);
                if (opcionSeleccionada == DialogResult.Yes)
                {
                    consultas.modificarCualquierTabla(tabla, textBox_referencia.Text, textBox_nombre.Text, "ref", referencia, listView1);
                    referencia = "";
                    cargarLista = true;
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                    cargarLista=false;
                    limpiarCampos();
                }
                else {
                    MessageBox.Show("Tenga ciudado!");
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        private void button_nueva_Click(object sender, EventArgs e)
        {
            // Modelo a meter en otros
            if (textBox_nombre.Text != "" && textBox_referencia.Text != "")
            {
                DialogResult opcionSeleccionada = MessageBox.Show("¿Seguro que quiere crear un registro nuevo?", "Aviso", MessageBoxButtons.YesNo);
                if (opcionSeleccionada == DialogResult.Yes)
                { 
                    bool insertado = consultas.insertTablaCaracteristicasDinamico(tabla, id_tabla, id_predeterminado, textBox_referencia.Text, textBox_nombre.Text);

                    if (insertado == true)
                    {
                        limpiarCampos();
                        referencia = "";
                        cargarLista = true;
                        cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                        cargarLista = false;
                        id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, textBox_referencia);
                    }
                    else
                    {
                        MessageBox.Show(ClaseCompartida.msgErrorGeneral);
                    }
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }    
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }

        }

        private void radioButton_habilitado_CheckedChanged(object sender, EventArgs e)
        {
            cargarLista = true;
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            cargarLista = false;
            actualizarToolStripMenuItem.Enabled = true;
            habilitarToolStripMenuItem.Enabled = false;
            deshabilitarToolStripMenuItem.Enabled = true;
            eliminarToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = true;
            newToolStripMenuItem.Enabled = true;
        }

        private void radioButton_deshabilitado_CheckedChanged(object sender, EventArgs e)
        {
            cargarLista = true;
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
            cargarLista = false;
            actualizarToolStripMenuItem.Enabled = false;
            habilitarToolStripMenuItem.Enabled = true;
            deshabilitarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = false;
            newToolStripMenuItem.Enabled = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cargarLista == false) { 
                referencia = e.Item.Text;
                textBox_referencia.Text = referencia;
                textBox_nombre.Text = consultas.obtenerCualquierRefDesdeNombre("nombre", tabla, "ref", referencia);
            }
        }



        // Función que crea una nueva variedad
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Modelo a meter en otros
            if (textBox_nombre.Text != "" && textBox_referencia.Text != "")
            {
                bool insertado = consultas.insertTablaCaracteristicasDinamico(tabla, id_tabla, id_predeterminado, textBox_referencia.Text, textBox_nombre.Text);

                if (insertado == true)
                {
                    id_predeterminado = consultas.referenciaPredeterminada(id_tabla, tabla, refPredeterminada, textBox_referencia);
                    cargarLista = true;
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                    cargarLista = false;
                    referencia = "";
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgErrorGeneral);
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }
    }
}
