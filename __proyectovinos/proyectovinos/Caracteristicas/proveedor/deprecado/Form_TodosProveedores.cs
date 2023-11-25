using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos;
using proyectovinos.Caracteristicas.proveedor;

namespace proyectovinos
{
    public partial class Form_TodosProveedores : Form
    {
        public Form_TodosProveedores()
        {
            InitializeComponent();
        }

        private string referencia = "";

        Consultas consultas = new Consultas();
        Class_ProveedorAperturaForms proveedorAperturaForms = new Class_ProveedorAperturaForms();
        Class_Proveedor prov = new Class_Proveedor();
        CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();

        private bool cargarlista = false;
        private string nombreId = "id_proveedor";
        private string tabla = "proveedor";
        private int id_proveedor = 0;

        private void Form_TodosProveedores_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            prov.cumplimentarListaProveedores(listView1, '1');
            cargarlista = true;
        }


        // Deshabilitar
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox_nombreproveedor.Text != "")
            {
                if (check_seguro.Checked)
                {
                   // string nombre = textBox_nombreproveedor.Text;
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '0');
                    prov.cumplimentarListaProveedores(listView1, '1');
                    prov.limpiezaCampos(check_seguro, textBox_nombreproveedor, pictureBox1);
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


        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (cargarlista==true) { 
                referencia = e.Item.Text;
                id_proveedor = consultas.obtenerCualquierId(nombreId, tabla,"ref",referencia);

                string nombreProveedor = consultas.obtenerCualquierRefDesdeNombre("nombre", tabla, "ref", referencia);
                textBox_nombreproveedor.Text = nombreProveedor;

                cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox1);
            }
        }






        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proveedorAperturaForms.nuevoProveedor();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proveedorAperturaForms.modificarProveedor(); this.Close();
        }

        private void habilitarEliminadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proveedorAperturaForms.hablilitarProveedoresEliminados();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proveedorAperturaForms.eliminarProveedor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
