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

namespace proyectovinos.Caracteristicas.proveedor
{
    public partial class Form_TodosProveedoresII : Form
    {
        public Form_TodosProveedoresII()
        {
            InitializeComponent();
        }

        private string tabla = "proveedor";
        private string nombreId = "id_proveedor";
        private string referencia = "";
        private bool cargarlista = false;


        private int id_proveedor = 0;

        Consultas consultas = new Consultas();
        Utilidades ut = new Utilidades();
        Class_Proveedor prov = new Class_Proveedor();
        CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();
        Class_ProveedorAperturaForms proveedorAperturaForms = new Class_ProveedorAperturaForms();


        private void PruebaTodos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            prov.cumplimentarListaProveedores(listView1, '1');
            cargarlista = true;
        }



        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cargarlista == true)
            {
                referencia = e.Item.Text;
                id_proveedor = consultas.obtenerCualquierId(nombreId, tabla, "ref", referencia);
                string nombreProveedor = consultas.obtenerCualquierRefDesdeNombre("nombre", tabla, "ref", referencia);
                text_nombre.Text = nombreProveedor;
                text_referenciaeliminar.Text = referencia;
                cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox1);
            }
        }


        // Eliminar carpeta proveedor
        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool eliminado = ut.controladorEliminarCaracteristica(check_seguro, text_referenciaeliminar, 
                text_nombre, nombreId, tabla, listView1);

            // Eliminar su carpeta
            if (eliminado == true)
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor;
                try
                {
                    Directory.Delete(folderPath, true);
                    MessageBox.Show("Directorio eliminado: " + folderPath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("The process failed: {0}", ex.Message);
                }

                ut.limpiarCamposEliminar(text_referenciaeliminar, text_nombre, check_seguro);
                prov.cumplimentarListaProveedores(listView1, '0');
            }
            else
            {
                MessageBox.Show("No se ha eliminado, consulte con el administrador!");
            }
        }


        // Seleccionar radiobutton de habilitar
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {   // Cuando se seleccione el radiobutton que muestre los habilitados
            prov.cumplimentarListaProveedores(listView1, '1');
            habilitarToolStripMenuItem.Enabled = false;
            desahilitarToolStripMenuItem.Enabled = true;
            actualizarToolStripMenuItem.Enabled = true;
            eliminarToolStripMenuItem1.Enabled = false;
            cargarlista = true;
        }


        // Seleccionar radiobutton de deshabilitar
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Cuando se seleccione el radiobutton que muestre los deshabilitados
            prov.cumplimentarListaProveedores(listView1, '0');
            eliminarToolStripMenuItem1.Enabled = true;
            habilitarToolStripMenuItem.Enabled=true;
            desahilitarToolStripMenuItem.Enabled = false;
            cargarlista = true;
        }

        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prov.cumplimentarListaProveedores(listView1, '1');
            desahilitarToolStripMenuItem.Enabled = true;
            cargarlista = true;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text_nombre.Text != "")
            {
                if (check_seguro.Checked)
                {
                    // string nombre = textBox_nombreproveedor.Text;
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '0');
                    prov.cumplimentarListaProveedores(listView1, '1');
                    prov.limpiezaCampos(check_seguro, text_nombre, pictureBox1);
                    check_seguro.Checked = false;
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgSelectRegistro);
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text_nombre.Text != "")
            {
                if (check_seguro.Checked)
                {
                    string nombre = text_nombre.Text;
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '1');
                    prov.cumplimentarListaProveedores(listView1, '0');

                    prov.limpiezaCampos(check_seguro, text_nombre, pictureBox1);

                    check_seguro.Checked = false;
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
                }

            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            proveedorAperturaForms.nuevoProveedor();
        }

        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            proveedorAperturaForms.modificarProveedor(); this.Close();
        }
    }
}
