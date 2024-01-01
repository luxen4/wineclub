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

namespace proyectovinos.Roles
{
    public partial class Form_TodosCargos : Form
    {
        public Form_TodosCargos()
        {
            InitializeComponent();
        }

        Utilidades ut = new Utilidades();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        Consultas consultas = new Consultas();

        private int id_predeterminado = 0;
        private string tabla = "rollempleado";
        private string nombreId = "id_rollempleado";
        private string refPredeterminada = "Roll";
        private string referencia = "";

        private bool cumplimentarTextos = false;

        private void Form_TodosRolesII_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = this.Top + 40;
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            enlacesHabilitados();
            limpiarCampos();
        }

      
        /// <summary>
        /// Función que actualiza la lista de cargos 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencia);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            limpiarCampos();
        }
     
        /// <summary>
        /// Función que habilita un cargo  
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea habilitar un registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {  
                if (referencia != "")
                {
                    ut.habilitarOnOff_Caracteristica(tabla, "ref", text_referencia.Text, '1');
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
                    limpiarCampos();
                }
                else
                {
                  MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
            else
            {
                MessageBox.Show("Tenga cuidado!");
            }
        }
      
        /// <summary>
        /// Función que habilita un cargo de la vinoteca.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea deshabilitar un registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                if (referencia != "")
                {
                    ut.habilitarOnOff_Caracteristica(tabla, "ref", text_referencia.Text, '0');
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
            else
            {
                MessageBox.Show("Tenga cuidado!");
            }
        }
     
        /// <summary>
        /// Función que elimina un cargo  .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea eliminar un registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                if (referencia != "")
                {

                    int id_rollempleado = consultas.obtenerCualquierId(nombreId, tabla, "ref", text_referencia.Text);

                    Class_Articulo articulo = new Class_Articulo();
                    int existencias = articulo.existeArticuloConCaracteristica("id_empleado", "empleado", nombreId, id_rollempleado);

                    if (existencias > 0)
                    {
                        MessageBox.Show(existencias + ClaseCompartida.msgArticulosTipo);
                    }
                    else
                    {
                        consultas.eliminarCaracteristica(tabla, "ref", text_referencia.Text);
                        cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
                        limpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
            else
            {
                MessageBox.Show("Tenga cuidado!");
            }
        }

        /// <summary>
        /// Función que modifica un registro de cargo.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea guardar un registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                if (text_nombre.Text != "" && text_referencia.Text != "")
                {
                    string nuevoNombre = text_nombre.Text;
                    string nuevaReferencia = text_referencia.Text;

                    consultas.modificarCualquierTabla(tabla, nuevaReferencia, nuevoNombre, "ref", referencia, listView1);
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("Campos vacios");
                }
            }
            else
            {
                MessageBox.Show("Tenga cuidado!");
            }
        }



        /// <summary>
        /// Al seleccionar un check de la lista  .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemCheckedEventArgs"/> instance containing the event data.</param>
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cumplimentarTextos == true) { 
                referencia = e.Item.Text;
                text_referencia.Text = referencia;

                Consultas consultas = new Consultas();
                string nombre = consultas.obtenerCualquierRefDesdeNombre("nombre", tabla, "ref", referencia);
                text_nombre.Text = nombre;
            }
        }


        /// <summary>
        /// Función que crea roles nuevos .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea crear un registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                if (text_nombre.Text != "" && text_referencia.Text != "")
                {
                    consultas.insertTablaCaracteristicasDinamico(tabla, nombreId, id_predeterminado, text_referencia.Text, text_nombre.Text);
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                    limpiarCampos();

                }
                else {
                    MessageBox.Show("Campos vacios");
                }
            }
            else {
                MessageBox.Show("Tenga cuidado!");
            }
        }


        private void radio_habilitados_CheckedChanged(object sender, EventArgs e)
        {
            enlacesHabilitados();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            limpiarCampos();
        }

        private void radio_deshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            enlacesDeshabilitados();
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '0');
            limpiarCampos();
        }


        private void enlacesHabilitados()
        {
            // Igual esto a un bloque junto con la implementación de radio de desabilitar
            actualizarToolStripMenuItem.Enabled = true;
            habilitarToolStripMenuItem.Enabled = false;
            deshabilitarToolStripMenuItem.Enabled = true;
            eliminarToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = true;
            newToolStripMenuItem.Enabled = true;
            //
        }
        private void enlacesDeshabilitados()
        {
            actualizarToolStripMenuItem.Enabled = false;
            habilitarToolStripMenuItem.Enabled = true;
            deshabilitarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = false;
            newToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Función que pone los campos en modo predeterminado.
        /// </summary>
        /// <param name="activo">The activo.</param>
        private void limpiarCampos()
        {
            cumplimentarTextos = false;
            //cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, activo);
            cumplimentarTextos = true;
            text_nombre.Text = "";
            text_referencia.Text = "";
        }
    }
    
}

