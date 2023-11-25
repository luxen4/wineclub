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

namespace proyectovinos.Caracteristicas.proveedor
{
    public partial class Form_HabilitarProveedores : Form
    {
        public Form_HabilitarProveedores()
        {
            InitializeComponent();
        }

        private string referencia = "";

        CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();
        Consultas consultas = new Consultas();
        Utilidades ut = new Utilidades();
        Class_Proveedor prov = new Class_Proveedor();

        private int id_proveedor = 0;
        private string tabla = "proveedor";
        private string nombreId = "id_proveedor";

        private void Form_HabilitarProveedores_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            prov.cumplimentarListaProveedores(listView1, '0');
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_nombreproveedor.Text != "")
            {
                if (check_seguro.Checked)
                {
                    string nombre = textBox_nombreproveedor.Text;
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '1');
                    prov.cumplimentarListaProveedores(listView1, '0');

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
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }

        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            referencia = e.Item.Text;
            string nombreProveedor = consultas.obtenerCualquierRefDesdeNombre("nombre", tabla, "ref", referencia);
            textBox_nombreproveedor.Text = nombreProveedor;

            id_proveedor = consultas.obtenerCualquierId(nombreId, tabla, "ref", referencia);
            cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox1);
        }


    }
}
