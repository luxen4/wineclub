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
    public partial class Form_EliminarProveedor : Form
    {
        public Form_EliminarProveedor()
        {
            InitializeComponent();
        }
        private string tabla = "proveedor";
        private string nombreId = "id_proveedor";
        private string referencia = "";
        private bool cargarlista = false;

        Consultas consultas = new Consultas();
        Utilidades ut = new Utilidades();
        Class_Proveedor prov = new Class_Proveedor();
        CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();


        private void Form_EliminarProveedor_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            prov.cumplimentarListaProveedores(listView1, '0');
            cargarlista = true;
        }

        private int id_proveedor = 0;
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cargarlista == true)
            {
                referencia = e.Item.Text;
                id_proveedor = consultas.obtenerCualquierId(nombreId, tabla, "ref", referencia);
                string nombreProveedor = consultas.obtenerCualquierRefDesdeNombre("nombre", tabla, "ref", referencia);
                text_nombreeliminar.Text = nombreProveedor;
                text_referenciaeliminar.Text = referencia;
                cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox1);
            }
        }

        // Eliminar carpeta de Proveedor
        private void button2_Click(object sender, EventArgs e)
        {
            bool eliminado = ut.controladorEliminarCaracteristica(check_seguroeliminar, text_referenciaeliminar, text_nombreeliminar, nombreId, tabla, listView1);

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

                ut.limpiarCamposEliminar(text_referenciaeliminar, text_nombreeliminar, check_seguroeliminar);
                prov.cumplimentarListaProveedores(listView1, '0');
            }
            else {
                MessageBox.Show("No se ha eliminado, consulte con el administrador!");
            }
        }
    }
}
